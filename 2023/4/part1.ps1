# https://adventofcode.com/2023/day/4

#$aoc_sample = [System.IO.File]::ReadAllLines("2023\4\sample.txt")
$aoc_sample = [System.IO.File]::ReadAllLines("2023\4\input.txt")

$regex = '\d+'
$totalpoints = 0
foreach ($line in $aoc_sample) {
    $cards = $line -split ":" -split "\|"
    $numbersyouhave = [Regex]::Matches($cards[1], $regex).Value
    $winningnumbers = [Regex]::Matches($cards[2], $regex).Value
    $points = 0
    foreach ($numberyouhave in $numbersyouhave) {
        if ($winningnumbers -contains $numberyouhave) {
            $points++
        }
    }
    if ($points -ge 1) {
        $totalpoints += [System.Math]::Pow(2, $points - 1)
    }
}
$totalpoints