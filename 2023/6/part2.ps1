# https://adventofcode.com/2023/day/6

#$aoc_sample = [System.IO.File]::ReadAllLines("2023\6\sample.txt")
$aoc_sample = [System.IO.File]::ReadAllLines("2023\6\input.txt")

[int64]$time = ([Regex]::Matches($aoc_sample[0], '\d+').Value) -join ''
[int64]$distance = ([Regex]::Matches($aoc_sample[1], '\d+').Value) -join ''

for ($i = 1; $i -lt $time; $i++) {
    if (($time - $i) * $i -gt $distance) {
        $time - 2 * $i + 1
        break
    }
}