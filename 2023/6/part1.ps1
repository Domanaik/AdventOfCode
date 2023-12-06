# https://adventofcode.com/2023/day/6

#$aoc_sample = [System.IO.File]::ReadAllLines("2023\6\sample.txt")
$aoc_sample = [System.IO.File]::ReadAllLines("2023\6\input.txt")

[int[]]$times = [Regex]::Matches($aoc_sample[0], '\d+').Value
[int[]]$distances = [Regex]::Matches($aoc_sample[1], '\d+').Value

$wins = 1
for ($i = 0; $i -lt $times.Count; $i++) {
    [int64]$p = - $times[$i]
    [int64]$q = $distances[$i]
    $x1 = [math]::Floor( - ($p / 2) - [math]::sqrt([math]::pow($p / 2, 2) - $q)) + 1
    $x2 = [math]::Ceiling( - ($p / 2) + [math]::sqrt([math]::pow($p / 2, 2) - $q))    
    $wins *= $x2 - $x1
}
$wins