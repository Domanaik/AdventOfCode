# https://adventofcode.com/2023/day/1

#$aoc_sample = [System.IO.File]::ReadAllLines("2023\1\sample2.txt")
$aoc_input = [System.IO.File]::ReadAllLines("2023\1\input.txt")
$calibration_value = 0
$regex = '\d|one|two|three|four|five|six|seven|eight|nine'
function ParseDigit([string]$digit) {
    switch ($digit) {
        "one" { 1 }
        "two" { 2 }
        "three" { 3 }
        "four" { 4 }
        "five" { 5 }
        "six" { 6 }
        "seven" { 7 }
        "eight" { 8 }
        "nine" { 9 }
        Default { $digit }
    }
}

foreach ($line in $aoc_input) {
    [int]$firstDigit = ParseDigit([Regex]::Match($line, $regex).Value)
    [int]$secondDigit = ParseDigit([Regex]::Match($line, $regex, [System.Text.RegularExpressions.RegexOptions]::RightToLeft).Value)
    $calibration_value += ($firstDigit * 10 + $secondDigit)
}
$calibration_value