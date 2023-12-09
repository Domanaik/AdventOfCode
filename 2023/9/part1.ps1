# https://adventofcode.com/2023/day/9

using namespace System.Collections.Generic

$aoc_sample = [System.IO.File]::ReadAllLines("2023\9\sample.txt")
$aoc_sample = [System.IO.File]::ReadAllLines("2023\9\input.txt")

class Sequence {
    [List[int64]]$List
    [Sequence]$NextSequence
    [int64]$Sum

    [void]addList([List[int64]]$list) {
        $this.List = $list
    }

    [bool]isAllZeroes() {
        foreach ($value in $this.List) {
            if ($value -ne 0) {
                return $false
            }
        }
        return $true
    }

    [void]getNextSequence() {
        
        Write-Host $this.List
        if ($this.isAllZeroes()) {
            $this.List.Add(0)
            Write-Host $this.List
        }
        else {
            $sequence = [Sequence]::new()

            [List[int64]]$newList = @()
            for ($i = 0; $i -lt $this.List.Count - 1; $i++) {
                $newList.Add(($this.List[$i + 1] - $this.List[$i]))
            }
            $sequence.addList($newList)
            $sequence.getNextSequence()
            $this.NextSequence = $sequence
            $this.Sum = $this.List[-1] + $this.NextSequence.List[-1]
            $this.List.Add($this.Sum)
            Write-Host $this.List
        }
    }
}

class SequenceList {
    [List[Sequence]]$List
    [int64]$Sum

    [void]addList([Sequence]$list) {
        $this.List += $list
    }

    [void]addSum([int64]$sum) {
        $this.Sum += $sum
    }
}

$sequenceList = [SequenceList]::new()
foreach ($line in $aoc_sample) {
    $sequence = [Sequence]::new()
    $sequence.addList([Regex]::Matches($line, '\d+').Value)
    $sequence.getNextSequence()
    $sequenceList.addList($sequence)
    $sequenceList.Sum += $sequence.Sum
    ""
    pause
    ""
}

$sequenceList.Sum