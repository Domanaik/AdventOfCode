# https://adventofcode.com/2023/day/15#part2

using namespace System.Collections.Generic

$aoc_sample = [System.IO.File]::ReadAllLines("2023\15\sample.txt")
$aoc_sample = [System.IO.File]::ReadAllLines("2023\15\input.txt")

class Lens {
    [String]$Label
    [int]$Focallength
    [int]$Hash
}

class Box {
    [int]$Number
    [List[Lens]]$Lenses
}

$matchs = ([Regex]::Matches($aoc_sample, '([^,]+)').Value)

[List[Box]]$boxes = @()
for ($i = 0; $i -lt 256; $i++) {
    $box = [Box]::new()
    $box.Number = $i
    $box.Lenses = @()
    $boxes.Add($box)
}

foreach ($match in $matchs) {
    $lens = [Lens]::new()
    $lens.Label = $match.Split("-").Split("=")[0]
    $lens.Hash = 0
    foreach ($currentcharacter in $lens.Label.ToCharArray()) {
        $lens.Hash += [byte][char]$currentcharacter
        $lens.Hash *= 17
        $lens.Hash %= 256
    }
    
    if ($match.ToCharArray() -contains "-") {
        $boxes[$lens.Hash].Lenses = ($boxes[$lens.Hash].Lenses | Where-Object Label -ne $lens.Label)
        if ($null -eq $boxes[$lens.Hash].Lenses) {
            $boxes[$lens.Hash].Lenses = @()
        }
    }
    elseif ($match.ToCharArray() -contains "=") {
        $lens.Focallength = $match.Split("=")[1]

        if ($boxes[$lens.Hash].Lenses | Where-Object Label -eq $lens.Label) {
            ($boxes[$lens.Hash].Lenses | Where-Object Label -eq $lens.Label).Focallength = $lens.Focallength
        }
        else {
            $boxes[$lens.Hash].Lenses.Add($lens)
        }
    }
}

$sum = 0
foreach ($box in $boxes | Where-Object Lenses -ne "" ) {
    $slot = 1
    foreach ($lense in $box.Lenses) {
        $sum += ($lense.Hash + 1) * $slot * $lense.Focallength    
        $slot++
    }
}
$sum