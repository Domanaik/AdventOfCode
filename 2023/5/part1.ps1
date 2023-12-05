# https://adventofcode.com/2023/day/4

$aoc_sample = [System.IO.File]::ReadAllLines("2023\5\sample.txt")
$aoc_sample = [System.IO.File]::ReadAllLines("2023\5\input.txt")

$seeds = [Regex]::Matches($aoc_sample[0], '\d+').Value
$newmap = @{}
$map = ""
$i = 0
foreach ($line in $aoc_sample | Select-Object -Skip 2) {
    if ($line -ne '') {
        if ($line -match ":$") {
            $map = $line -replace ' map:', ''
            $i = 0
            $newmap[$map] = @{}
            $newmap[$map][$i] = @{}
            $newmap[$map][$i]["destinationrangestart"] = @{}
            $newmap[$map][$i]["sourcerangestart"] = @{}
            $newmap[$map][$i]["rangelength"] = @{}
        }
        else {
            $values = $line -split " "
            $newmap[$map][$i] = @{}
            $newmap[$map][$i]["destinationrangestart"] = $values[0]
            $newmap[$map][$i]["sourcerangestart"] = $values[1]
            $newmap[$map][$i]["rangelength"] = $values[2]
            $i++
        }
    }
}

function getNextMap ($currentMap) {
    $nextMap = ""
    foreach ($key in $newmap.Keys) {
        if ($key -match "$currentMap-to-*") {
            $nextMap = ($key -split '-')[2]
        }
    }
    if ($nextMap) {
        return $nextMap
    }
    else {
        return $false
    }
}

function getSeedLocation($currentMap, $amount) {
    
    $nextMap = getNextMap($currentMap)
    if ($nextMap) {
        $map = "$currentMap-to-$nextMap"
        $mapped = @{}
        foreach ($i in $newmap[$map].Values) {
            for ($j = 0; $j -lt $i.rangelength; $j++) {
                $mapped[[int]$i.sourcerangestart + $j] = @{}
                $mapped[[int]$i.sourcerangestart + $j][$currentMap] = [int]$i.sourcerangestart + $j        
                $mapped[[int]$i.sourcerangestart + $j][$nextMap] = [int]$i.destinationrangestart + $j
            }
        }
        if ($mapped.Contains([int]$amount)) {
            $corresponds = $($mapped[[int]$amount][$nextMap])
        }
        else {
            $corresponds = $amount
        }        
        Write-Output "$currentMap number $amount corresponds to $nextMap number $corresponds"
        getSeedLocation $nextMap $corresponds
    }
    else {
        return $corresponds
    }
}

$results = @()
foreach ($seed in $seeds) {
    $results += getSeedLocation "seed" $seed 
}
($results | Measure-Object -Minimum).Minimum