# https://adventofcode.com/2023/day/9#part2

using namespace System.Collections.Generic

$aoc_sample = [System.IO.File]::ReadAllLines("2023\9\sample.txt")
$aoc_sample = [System.IO.File]::ReadAllLines("2023\9\input.txt")

class Sequence {
    [List[int64]]$List

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
        if ($this.isAllZeroes()) {
            $this.List.Add(0)
        }
        else {
            $sequence = [Sequence]::new()
            [List[int64]]$newList = @()
            for ($i = 0; $i -lt $this.List.Count - 1; $i++) {
                $newList.Add(($this.List[$i + 1] - $this.List[$i]))
            }
            $sequence.addList($newList)
            $sequence.getNextSequence()
            $this.List = , ($this.List[0] - $sequence.List[0]) + $this.List
        }
    }
}

$sum = 0
foreach ($line in $aoc_sample) {
    $sequence = [Sequence]::new()
    $sequence.addList([Regex]::Matches($line, '-?\d+').Value)
    $sequence.getNextSequence()
    $sum += $sequence.List[0]
}
$sum