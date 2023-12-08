# https://adventofcode.com/2023/day/8#part2

$aoc_sample = [System.IO.File]::ReadAllLines("2023\8\sample3.txt")
$aoc_sample = [System.IO.File]::ReadAllLines("2023\8\input.txt")

$instruction = $aoc_sample[0]
[regex]$regex = "(\w{3})\s=\s\((\w{3}),\s(\w{3})\)"
$instructions = @{}

for ($i = 0; $i -lt ($aoc_sample.Length - 2); $i++) {
    $match = $regex.Match($aoc_sample[$i + 2])
    $instructions[$match.Groups[1].Value] = @{}
    $instructions[$match.Groups[1].Value]["L"] = $match.Groups[2].Value
    $instructions[$match.Groups[1].Value]["R"] = $match.Groups[3].Value
}

$currents = @{}
foreach ($possibleStart in $instructions.Keys) {
    if ($possibleStart.EndsWith("A")) {
        $currents.Add($possibleStart, $instructions[$possibleStart])
    }
}
$allSteps = @()
foreach ($one in $currents.Keys) {
    $i = 0
    $steps = 0
    do {
        $steps++
        $direction = $instruction.ToCharArray()[$i].ToString()
        $one = $instructions[$one][$direction]
        if (++$i -ge $instruction.Length) { $i = 0 }
    } while (($one.EndsWith("Z") -eq $false))
    $allSteps += $steps
}

function ggT([int64]$a, [int64]$b) {
    while ($b -ne 0) {
        $tmp = $b
        $b = $a % $b
        $a = $tmp
    }
    return $a
}

function kgV([int64]$a, [int64]$b) {
    return ($a / (ggt $a $b) * $b)
}

$result = 1
for ($i = 0; $i -lt $allSteps.Length; $i++) {
    $result = kgV $allSteps[$i] $result
}
$result