# https://adventofcode.com/2015/day/1

#$aoc_sample = [System.IO.File]::ReadAllLines("2015\1\sample.txt")
$aoc_input = [System.IO.File]::ReadAllLines("2015\1\input.txt")

$floor = 0
$position = 0
foreach ($char in $($aoc_input).ToCharArray())
{
    $position++
    switch ($char)
    {
        "(" { $floor++ }
        ")" { $floor-- }
    }
    if ($floor -eq -1)
    {
        $position
        break
    }
}