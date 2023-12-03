# https://adventofcode.com/2023/day/3

$aoc_sample = [System.IO.File]::ReadAllLines("2023\3\sample.txt")
$aoc_sample = [System.IO.File]::ReadAllLines("/Dokumente und Einstellungen/Kojofl/Documents/rust_projects/advent/domme/AdventOfCode/2023/3/input.txt")
$sum_gearratios = 0

function isDigit($string) {
    if ($string -match '^\d+$') {
        return $true
    }
    return $false
}

for ($i = 0; $i -lt $aoc_sample.Length; $i++) {
    Write-Output "Durchgang $($i+1)"
    if ($($i + 1) -eq 139) {
        "check"
    }
    $match = [regex]::Matches($aoc_sample[$i], '\*')
    foreach ($success in $match) {
        $indexStart = $success.Index
        $topleft = ""
        $topright = ""
        $botleft = ""
        $botright = ""
        $gears = @()

        Write-Output "found * at index $indexStart in line $($i+1)"
        #$aoc_sample[$i - 1][$indexStart - 1] , $aoc_sample[$i - 1][$indexStart], $aoc_sample[$i - 1][$indexStart + 1] -join ''
        #$aoc_sample[$i][$indexStart - 1], "*", $aoc_sample[$i][$indexStart + 1] -join ''
        #$aoc_sample[$i + 1][$indexStart - 1], $aoc_sample[$i + 1][$indexStart], $aoc_sample[$i + 1][$indexStart + 1] -join ''

        # Left
        if (isDigit($aoc_sample[$i][$indexStart - 1])) {
            $left = ([regex]::Matches($aoc_sample[$i][0..($indexStart - 1)] -join '', '\d+$')).Value
            $gears += $left
        }
        # Right
        if (isDigit($aoc_sample[$i][$indexStart + 1])) {
            $right = ([regex]::Matches($aoc_sample[$i][($indexStart + 1)..$aoc_sample[$i].Length] -join '', '^\d+')).Value
            $gears += $right
        }
        
        # Top
        if (isDigit($aoc_sample[$i - 1][$indexStart])) {
            if ((isDigit(([regex]::Matches($aoc_sample[$i - 1][0..($indexStart - 1)] -join '', '\d+$')).Value))) {
                $start = ([regex]::Matches($aoc_sample[$i - 1][0..($indexStart - 1)] -join '', '\d+$')).Index
                $topleft = ([regex]::Matches($aoc_sample[$i - 1][$start..$aoc_sample[$i].Length] -join '', '^\d+')).Value
                $gears += $topleft
            }
            else {
                $topright = ([regex]::Matches($aoc_sample[$i - 1][$indexStart..$aoc_sample[$i].Length] -join '', '^\d+')).Value
                $gears += $topright
            }
        }
        else {
            # Topleft
            if (isDigit($aoc_sample[$i - 1][$indexStart - 1])) {
                $topleft = ([regex]::Matches($aoc_sample[$i - 1][0..($indexStart - 1)] -join '', '\d+$')).Value
                $gears += $topleft
            }
            # Topright
            if (isDigit($aoc_sample[$i - 1][$indexStart + 1])) {
                $topright = ([regex]::Matches($aoc_sample[$i - 1][($indexStart + 1)..$aoc_sample.Length] -join '', '^\d+')).Value
                $gears += $topright
            }
        }
        if (isDigit($aoc_sample[$i + 1][$indexStart])) {
            if ((isDigit(([regex]::Matches($aoc_sample[$i + 1][0..($indexStart - 1)] -join '', '\d+$')).Value))) {
                $start = ([regex]::Matches($aoc_sample[$i + 1][0..($indexStart - 1)] -join '', '\d+$')).Index
                $botleft = ([regex]::Matches($aoc_sample[$i + 1][$start..$aoc_sample[$i].Length] -join '', '^\d+')).Value
                $gears += $botleft
            }
            else {
                $botright = ([regex]::Matches($aoc_sample[$i + 1][($indexStart)..$aoc_sample[$i].Length] -join '', '^\d+')).Value
                $gears += $botright
            }
        }
        else {
            if (isDigit($aoc_sample[$i + 1][$indexStart - 1])) {
                $botleft = ([regex]::Matches($aoc_sample[$i + 1][0..($indexStart - 1)] -join '', '\d+$')).Value
                $gears += $botleft
            }
            if (isDigit($aoc_sample[$i + 1][$indexStart + 1])) {
                $botright = ([regex]::Matches($aoc_sample[$i + 1][($indexStart + 1)..$aoc_sample[$i].Length] -join '', '^\d+')).Value
                $gears += $botright
            }
        }
        if ($gears.Count -eq 2) {
            $sum_gearratios += [int]$gears[0] * [int]$gears[1]
        }
    }
}
$sum_gearratios
