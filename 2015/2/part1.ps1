# https://adventofcode.com/2015/day/2

#$aoc_sample = [System.IO.File]::ReadAllLines("2015\2\sample.txt")
$aoc_input = [System.IO.File]::ReadAllLines("2015\2\input.txt")

$squarefeet = 0

foreach ($line in $aoc_input)
{
    $lwh = [Regex]::Matches($line,'\d+')
    $l = [int]$lwh[0].Value
    $w = [int]$lwh[1].Value
    $h = [int]$lwh[2].Value
    $lw = $l*$w
    $wh = $w*$h
    $hl = $h*$l
    $minimum = ($lw,$wh,$hl | Measure-Object -Minimum).Minimum
    $squarefeet += (2*$lw + 2*$wh + 2*$hl + $minimum)
}
$squarefeet