# https://adventofcode.com/2023/day/12

$aoc_sample = [System.IO.File]::ReadAllLines("2023\12\sample.txt")
#$aoc_sample = [System.IO.File]::ReadAllLines("2023\12\input.txt")

<#
    ???.###     1,1,3
    .??..??...?##.  1,1,3
    ?#?#?#?#?#?#?#?     1,3,1,6
    ????.#...#...       4,1,1
    ????.######..#####. 1,6,5
    ?###????????        3,2,1
#>

[regex]$regex = "^([.#?]*)\s([\d,]*)$"
[regex]$regex1 = "^(\.+)+|(\#+)+|(\?+)$"
[regex]$regex2 = "\d+"


foreach ($line in $aoc_sample) {
    $match = $regex.Match($line)
    $match.Groups[1].Value
    $newmatch1 = $regex1.Matches($match.Groups[1].Value)
    $newmatch1

    $match.Groups[2].Value
    $newmatch2 = $regex2.Matches($match.Groups[2].Value)
    $newmatch2
}