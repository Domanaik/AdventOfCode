# https://adventofcode.com/2023/day/6

#$aoc_sample = [System.IO.File]::ReadAllLines("2023\6\sample.txt")
$aoc_sample = [System.IO.File]::ReadAllLines("2023\6\input.txt")

[int64]$p = ([Regex]::Matches($aoc_sample[0], '\d+').Value) -join ''
[int64]$q = ([Regex]::Matches($aoc_sample[1], '\d+').Value) -join ''

$x1 = - ($p / 2) - [math]::sqrt([math]::pow($p / 2, 2) - $q)
$x2 = - ($p / 2) + [math]::sqrt([math]::pow($p / 2, 2) - $q)
[int][Math]::Ceiling($x2 - $x1)