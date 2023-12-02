# https://adventofcode.com/2023/day/1

#$aoc_sample = [System.IO.File]::ReadAllLines("2023\1\sample1.txt")
$aoc_input = [System.IO.File]::ReadAllLines("2023\1\input.txt")
$calibration_value = 0
$regex = '\d'

foreach ($line in $aoc_input)
{
    $firstDigit = [Regex]::Match($line, $regex).Value
    $secondDigit = [Regex]::Match($line, $regex, [System.Text.RegularExpressions.RegexOptions]::RightToLeft).Value
    $calibration_value += ($firstDigit * 10 + $secondDigit)
}
$calibration_value