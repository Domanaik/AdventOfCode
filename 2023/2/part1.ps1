# https://adventofcode.com/2023/day/2

#$aoc_sample = [System.IO.File]::ReadAllLines("2023\2\sample.txt")
$aoc_input = [System.IO.File]::ReadAllLines("2023\2\input.txt")

$sum_games = 0
$red_cubes = 12
$green_cubes = 13
$blue_cubes = 14

foreach ($line in $aoc_input)
{
    $parts = $line -split ":" -split ";"
    $possible = $true
    foreach ($reveal in ($parts | Select-Object -Skip 1))
    {
        foreach ($color in ($reveal -split ","))
        {
            $color = $color -split " "
            switch ($color[2])
            {
                "red" { 
                    if ([int]$color[1] -gt $red_cubes) {
                        $possible = $false
                    }
                }
                "green" { 
                    if ([int]$color[1] -gt $green_cubes) {
                        $possible = $false
                    }
                }
                "blue" { 
                    if ([int]$color[1] -gt $blue_cubes) {
                        $possible = $false
                    }
                }
            }
        }
    }
    if ($possible)
    {
        $sum_games += ($parts[0] -split ' ','')[1]
    }
}
$sum_games