# https://adventofcode.com/2023/day/3

$aoc_sample = [System.IO.File]::ReadAllLines("2023\3\sample.txt")
$aoc_sample = [System.IO.File]::ReadAllLines("2023\3\input.txt")
$sum_gearratios = 0

function isDigit($string)
{
    if ($string -match '^\d+$')
    {
        return $true
    }
    return $false
}

for ($i = 0; $i -lt $aoc_sample.Length; $i++)
{
    Write-Output "Durchgang $($i+1)"
    if ($($i + 1) -eq 139)
    {
        "check"
    }
    $match = [regex]::Matches($aoc_sample[$i], '\*')
    foreach ($success in $match)
    {
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

        if (isDigit($aoc_sample[$i][$indexStart - 1]))
        {
            $left = ([regex]::Matches($aoc_sample[$i][0..($indexStart - 1)] -join '', '\d+$')).Value
            Write-Output "left $left"
            $gears += $left
        }
        if (isDigit($aoc_sample[$i][$indexStart + 1]))
        {
            $right = ([regex]::Matches($aoc_sample[$i][($indexStart + 1)..$aoc_sample.Length] -join '', '^\d+')).Value
            Write-Output "right $right"
            $gears += $right
        }
        
        if (isDigit($aoc_sample[$i - 1][$indexStart]))
        {
            $top = ([regex]::Matches($aoc_sample[$i - 1][0..$aoc_sample.Length] -join '', '\d+')).Value
            if ((isDigit(([regex]::Matches($aoc_sample[$i - 1][0..($indexStart - 1)] -join '', '\d+$')).Value)) -and (isDigit(([regex]::Matches($aoc_sample[$i - 1][($indexStart + 1)..$aoc_sample.Length] -join '', '^\d+')).Value)))
            {
                $topleft = ([regex]::Matches($aoc_sample[$i - 1][0..($indexStart)] -join '', '\d+$')).Value
                Write-Output "top $top"
                $gears += $top
            }
            elseif (isDigit(([regex]::Matches($aoc_sample[$i - 1][0..($indexStart - 1)] -join '', '\d+$')).Value))
            {
                $topleft = ([regex]::Matches($aoc_sample[$i - 1][0..($indexStart)] -join '', '\d+$')).Value
                Write-Output "topleft $topleft"
                $gears += $topleft
            }
            elseif (isDigit(([regex]::Matches($aoc_sample[$i - 1][($indexStart + 1)..$aoc_sample.Length] -join '', '^\d+')).Value))
            {
                $topright = ([regex]::Matches($aoc_sample[$i - 1][($indexStart)..$aoc_sample.Length] -join '', '^\d+')).Value
                Write-Output "topright $topright"
                $gears += $topright
            }
        }
        else
        {
            if (isDigit($aoc_sample[$i - 1][$indexStart - 1]))
            {
                $topleft = ([regex]::Matches($aoc_sample[$i - 1][0..($indexStart - 1)] -join '', '\d+')).Value
                Write-Output "topleft $topleft"
                $gears += $topleft
            }
            if (isDigit($aoc_sample[$i - 1][$indexStart + 1]))
            {
                $topright = ([regex]::Matches($aoc_sample[$i - 1][($indexStart + 1)..$aoc_sample.Length] -join '', '\d+')).Value
                Write-Output "topright $topright"
                $gears += $topright
            }
        }
        if (isDigit($aoc_sample[$i + 1][$indexStart]))
        {
            $bot = ([regex]::Matches($aoc_sample[$i + 1][0..$aoc_sample.Length] -join '', '\d+')).Value
            if ((isDigit(([regex]::Matches($aoc_sample[$i + 1][0..($indexStart - 1)] -join '', '\d+$')).Value)) -and (isDigit(([regex]::Matches($aoc_sample[$i + 1][($indexStart + 1)..$aoc_sample.Length] -join '', '^\d+')).Value)))
            {
                $botleft = ([regex]::Matches($aoc_sample[$i + 1][0..($indexStart)] -join '', '\d+$')).Value
                Write-Output "bot $bot"
                $gears += $bot
            }
            elseif (isDigit(([regex]::Matches($aoc_sample[$i + 1][0..($indexStart - 1)] -join '', '\d+$')).Value))
            {
                $botleft = ([regex]::Matches($aoc_sample[$i + 1][0..($indexStart)] -join '', '\d+$')).Value
                Write-Output "botleft $botleft"
                $gears += $botleft
            }
            elseif (isDigit(([regex]::Matches($aoc_sample[$i + 1][($indexStart + 1)..$aoc_sample.Length] -join '', '^\d+')).Value))
            {
                $botright = ([regex]::Matches($aoc_sample[$i + 1][($indexStart)..$aoc_sample.Length] -join '', '^\d+')).Value
                Write-Output "botright $botright"
                $gears += $botright
            }
        }
        else
        {
            if (isDigit($aoc_sample[$i + 1][$indexStart - 1]))
            {
                $botleft = ([regex]::Matches($aoc_sample[$i + 1][0..($indexStart - 1)] -join '', '\d+')).Value
                Write-Output "botleft $botleft"
                $gears += $botleft
            }
            if (isDigit($aoc_sample[$i + 1][$indexStart + 1]))
            {
                $botright = ([regex]::Matches($aoc_sample[$i + 1][($indexStart + 1)..$aoc_sample.Length] -join '', '\d+')).Value
                Write-Output "botright $botright"
                $gears += $botright
            }
        }
        if ($gears.Count -eq 2)
        {
            $sum_gearratios += [int]$gears[0] * [int]$gears[1]
        }
    }
}
$sum_gearratios