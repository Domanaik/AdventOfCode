# https://adventofcode.com/2023/day/19

using namespace System.Collections.Generic

$aoc_sample = [System.IO.File]::ReadAllLines("2023\19\sample.txt")
#$aoc_sample = [System.IO.File]::ReadAllLines("2023\19\input.txt")

class Workflow {
    [string]$Name
    [List[Rule]]$Rules
}

class Rule {
    [string]$Variable
    [string]$Comparison
    [int]$Value
    [string]$Destination

    Rule([string]$rule) {
        if ($rule.Contains('<')) {
            $this.Comparison = "lt"
            $this.Variable = $rule.Split('<')[0]
            $this.Value = $rule.Split('<')[1].Split(':')[0]
            $this.Destination = $rule.Split(':')[1]
            return
        }
        elseif ($rule.Contains('>')) {
            $this.Comparison = "gt"
            $this.Variable = $rule.Split('>')[0]
            $this.Value = $rule.Split('>')[1].Split(':')[0]
            $this.Destination = $rule.Split(':')[1]
            return
        }
        else {
            $this.Destination = $rule
            return
        }
    }
}

class Part {
    [int]$X
    [int]$M
    [int]$A
    [int]$S
    [int]$Rating
    [bool]$Accepted
    [bool]$Rejected 

    Part([int]$x, [int]$m, [int]$a, [int]$s) {
        $this.X = $x
        $this.M = $m
        $this.A = $a
        $this.S = $s
        $this.Rating = $this.X + $this.M + $this.A + $this.S
    }
}

function checkPartAgainstWorkflow([Part]$part, [Workflow]$workflow) {
    foreach ($rule in $workflow.Rules) {
        if ($part.Accepted -or $part.Rejected) { break }
        if ($rule.Comparison -eq 'lt') {
            if ($($part.$($rule.Variable)) -ge $rule.Value) {
                continue
            }
        }
        elseif ($rule.Comparison -eq 'gt') {
            if ($($part.$($rule.Variable)) -le $rule.Value) {
                continue
            }
        }
        if ($rule.Destination -eq "A") {
            $part.Accepted = $true
            return
        }
        elseif ($rule.Destination -eq "R") {
            $part.Rejected = $true
            return
        }
        else {
            checkPartAgainstWorkflow $part $($workflows | Where-Object Name -eq $rule.Destination)
        }
    }
}

[List[Workflow]]$workflows = @()
foreach ($line in $aoc_sample) {
    $match = [Regex]::Match($line, "^(.*){(.*)}$")
    if ($match.Groups[1].Value -ne "") {
        $workflow = [Workflow]::new()
        $workflow.Name = $match.Groups[1].Value
        $workflow.Rules = @()
        $ruleAsString = $match.Groups[2].Value.Split(',')
        foreach ($rule in $ruleAsString) {
            $rules = [Rule]::new($rule)
            $workflow.Rules.Add($rules)
        }
        $workflows.Add($workflow)
    }
}

[List[Part]]$parts = @()

[int]$min = 1
[int]$max = 4000
for ($x = $min; $x -le $max; $x++) {
    for ($m = $min; $m -le $max; $m++) {
        for ($a = $min; $a -le $max; $a++) {
            for ($s = $min; $s -le $max; $s++) {
                Write-Host "x $x, m $m, a $a, s $s"
                $part = [Part]::new($x, $m, $a, $s)
            }
        }
    }
}
$sum = 0
foreach ($part in $parts) {
    checkPartAgainstWorkflow $part ($workflows | Where-Object Name -eq "in")
    if ($part.Accepted) {
        $sum++
    }
}
$sum