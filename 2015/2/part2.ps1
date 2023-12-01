# https://adventofcode.com/2015/day/2

#$aoc_sample = [System.IO.File]::ReadAllLines("2015\2\sample.txt")
$aoc_input = [System.IO.File]::ReadAllLines("2015\2\input.txt")

$totalribbon  = 0

foreach ($line in $aoc_input)
{
    $lwh = [Regex]::Matches($line,'\d+')
    $array = [int]$lwh[0].Value, [int]$lwh[1].Value, [int]$lwh[2].Value | Sort-Object
    $ribbon = 2*$array[0] + 2*$array[1] + $array[0]*$array[1]*$array[2] 
    $totalribbon += $ribbon
}
$totalribbon