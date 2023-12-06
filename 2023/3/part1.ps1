# https://adventofcode.com/2023/day/3

#$aoc_sample = [System.IO.File]::ReadAllLines("2023\3\sample.txt")
$aoc_sample = [System.IO.File]::ReadAllLines("2023\3\input.txt")

$sum_partnumbers = 0
for ($i = 0; $i -lt $aoc_sample.Length; $i++) {
    $match = [regex]::Matches($aoc_sample[$i], '\d+')
    foreach ($success in $match) {
        $indexStart = $success.Index
        $indexEnd = $success.Length + $indexStart
        $number = [int](($aoc_sample[$i][$indexStart..($indexEnd - 1)]) -join '')
        $adjacent_symbols = @()
        if ($indexStart -gt 0) { 
            $indexStart--
            $adjacent_symbols += $aoc_sample[$i][($indexStart)]
        }
        if ($indexEnd -lt $($aoc_sample[$i].Length)) { 
            $adjacent_symbols += $aoc_sample[$i][$indexEnd]
        }
        if ($i -gt 0) {
            $adjacent_symbols += $aoc_sample[$i - 1][$indexStart..$indexEnd] 
        }
        if ($i -lt $aoc_sample.Length - 1) { 
            $adjacent_symbols += $aoc_sample[$i + 1][$indexStart..$indexEnd] 
        }
        if ($adjacent_symbols -join '' -notmatch '^\.*$') { 
            $sum_partnumbers += $number 
        }
    }
}
$sum_partnumbers