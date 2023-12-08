# https://adventofcode.com/2023/day/8

#$aoc_sample = [System.IO.File]::ReadAllLines("2023\8\sample1.txt")
#$aoc_sample = [System.IO.File]::ReadAllLines("2023\8\sample2.txt")
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

$current = "AAA"
$i = 0
$steps = 0
do {
    $current = $instructions[$current][($instruction.ToCharArray()[$i].ToString())]
    if (++$i -ge $instruction.Length) { $i = 0 }
    $steps++
} while ($current -ne "ZZZ")
$steps