# https://adventofcode.com/2023/day/3

#$aoc_sample = [System.IO.File]::ReadAllLines("2023\3\sample.txt")
$aoc_sample = [System.IO.File]::ReadAllLines("2023\3\input.txt")
$sum_partnumbers = 0

for ($i = 0; $i -lt $aoc_sample.Length; $i++)
{
    Write-Output "Durchgang $($i+1)"
    $match = [regex]::Matches($aoc_sample[$i], '\d+')
    foreach ($success in $match)
    {
        $successLength = $success.Length
        $indexStart = $success.Index
        $indexEnd = $indexStart + $successLength
        $previousLine = ""
        $previousChar = ""
        $nextChar = ""
        $nextLine = ""

        $number = [int](($aoc_sample[$i][$indexStart..($indexEnd - 1)]) -join '')
        Write-Output "found $number at index $indexStart with length $successLength"
      
        $adjacent_symbols = @()
        if ($indexStart -gt 0)
        { 
            # Index is greater 0, we can check one more position in front"
            $indexStart--
            $previousChar = $($aoc_sample[$i][($indexStart)])
            $adjacent_symbols += $aoc_sample[$i][($indexStart)]
        }
        if ($indexEnd -lt $($aoc_sample[$i].Length))
        { 
            $nextChar = $($aoc_sample[$i][$indexEnd])
            $adjacent_symbols += $aoc_sample[$i][$indexEnd]
        }
        
        if ($i -gt 0)
        {
            $previousLine = $($aoc_sample[$i - 1][$indexStart..$indexEnd] -join '')
            $adjacent_symbols += $aoc_sample[$i - 1][$indexStart..$indexEnd] 
        }
        
        if ($i -lt $aoc_sample.Length - 1)
        { 
            $nextLine = $($aoc_sample[$i + 1][$indexStart..$indexEnd] -join '')
            $adjacent_symbols += $aoc_sample[$i + 1][$indexStart..$indexEnd] 
        }
        $previousLine
        $previousChar, $number, $nextChar -join ''
        $nextLine

        if ($adjacent_symbols -join '' -notmatch '^\.*$') { $sum_partnumbers += $number }
        ""
    }
}
$sum_partnumbers