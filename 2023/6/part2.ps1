# https://adventofcode.com/2023/day/4

#$aoc_sample = [System.IO.File]::ReadAllLines("2023\6\sample.txt")
$aoc_sample = [System.IO.File]::ReadAllLines("2023\6\input.txt")

$time = ([Regex]::Matches($aoc_sample[0], '\d+').Value) -join ''
$distance = ([Regex]::Matches($aoc_sample[1], '\d+').Value) -join ''

$wins = 0

for ($i = 1; $i -lt $time; $i++) {
    if (($time - $i) * $i -gt $distance) {
        $wins++
    }
}

$wins