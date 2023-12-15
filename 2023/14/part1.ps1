# https://adventofcode.com/2023/day/14

$aoc_sample = [System.IO.File]::ReadAllLines("2023\14\sample.txt")
$aoc_sample = [System.IO.File]::ReadAllLines("2023\14\input.txt")

for ($h = 1; $h -lt $aoc_sample.Length; $h++) {
    for ($i = 1; $i -lt $aoc_sample.Length; $i++) {
        for ($j = 0; $j -lt $aoc_sample[$i].Length; $j++) {
            if ($aoc_sample[$i][$j] -eq "O") {
                if ($aoc_sample[$i - 1][$j] -eq ".") {
                    $aoc_sample[$i - 1] = $aoc_sample[$i - 1].Remove($j, 1).Insert($j, "O")
                    $aoc_sample[$i] = $aoc_sample[$i].Remove($j, 1).Insert($j, ".")
                }
            }
        }
    }
}

$sum = 0
$weight = $aoc_sample.Length
foreach ($line in $aoc_sample) {
    $sum += $weight-- * ([regex]::matches($line, "O").count)
}
""
$sum