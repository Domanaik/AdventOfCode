# https://adventofcode.com/2023/day/4

#$aoc_sample = [System.IO.File]::ReadAllLines("2023\4\sample.txt")
$aoc_sample = [System.IO.File]::ReadAllLines("2023\4\input.txt")

$copies = New-Object int[] ($aoc_sample.Length + 1)
foreach ($line in $aoc_sample) {
    $cards = $line -split ":" -split "\|"
    $card = [int][Regex]::Matches($cards[0], '\d+').Value
    $copies[$card]++
    $numbersyouhave = [Regex]::Matches($cards[1], '\d+').Value
    $winningnumbers = [Regex]::Matches($cards[2], '\d+').Value
    $matchingnumbers = 0
    foreach ($numberyouhave in $numbersyouhave) {
        if ($winningnumbers -contains $numberyouhave) {
            $matchingnumbers++
        }
    }
    for ($i = 1; $i -le $matchingnumbers; $i++) {
        $copies[$card + $i] += $copies[$card]
    }
}
($copies | Measure-Object -Sum).Sum