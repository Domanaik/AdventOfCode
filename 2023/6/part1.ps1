# https://adventofcode.com/2023/day/4

#$aoc_sample = [System.IO.File]::ReadAllLines("2023\6\sample.txt")
$aoc_sample = [System.IO.File]::ReadAllLines("2023\6\input.txt")

$times = ([Regex]::Matches($aoc_sample[0], '\d+').Value)
$distances = ([Regex]::Matches($aoc_sample[1], '\d+').Value)

$wins = New-Object int[] $times.Count

for ($i = 0; $i -lt $times.Count; $i++) {
    for ($j = 1; $j -lt $times[$i]; $j++) {
        if (($times[$i] - $j) * $j -gt $distances[$i]) {
            $wins[$i]++
        }
    }
}
$result = 1
foreach ($win in $wins) {
    $result *= $win
}
$result