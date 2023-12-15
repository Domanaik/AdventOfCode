# https://adventofcode.com/2023/day/15

$aoc_sample = [System.IO.File]::ReadAllLines("2023\15\sample.txt")
$aoc_sample = [System.IO.File]::ReadAllLines("2023\15\input.txt")

$matchs = ([Regex]::Matches($aoc_sample, '([^,]+)').Value)
$sum = 0
foreach ($match in $matchs) {
    $currentvalue = 0
    foreach ($currentcharacter in $match.ToCharArray()) {
        $currentvalue += [byte][char]$currentcharacter
        $currentvalue *= 17
        $currentvalue %= 256
    }
    $sum += $currentvalue
}
$sum