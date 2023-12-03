# https://adventofcode.com/2023/day/2

#$aoc_sample = [System.IO.File]::ReadAllLines("2023\2\sample.txt")
$aoc_input = [System.IO.File]::ReadAllLines("/Dokumente und Einstellungen/Kojofl/Documents/rust_projects/advent/domme/AdventOfCode/2023\2\input.txt")

$sum_power = 0

foreach ($line in $aoc_input) {
    $red_cubes = 0
    $green_cubes = 0
    $blue_cubes = 0
    $parts = $line -split ":" -split ";"
    foreach ($reveal in ($parts | Select-Object -Skip 1)) {
        foreach ($color in ($reveal -split ",")) {
            $color = $color -split " "
            switch ($color[2]) {
                "red" { 
                    if ($red_cubes -lt [int]$color[1]) {
                        $red_cubes = [int]$color[1]
                    }
                }
                "green" { 
                    if ($green_cubes -lt [int]$color[1]) {
                        $green_cubes = [int]$color[1]
                    }
                }
                "blue" { 
                    if ($blue_cubes -lt [int]$color[1]) {
                        $blue_cubes = [int]$color[1]
                    }
                }
            }
        }
    }
    $sum_power += $red_cubes * $green_cubes * $blue_cubes
}
$sum_power
