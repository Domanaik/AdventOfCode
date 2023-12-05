# https://adventofcode.com/2023/day/4

#$aoc_sample = [System.IO.File]::ReadAllLines("2023\5\sample.txt")
$aoc_sample = [System.IO.File]::ReadAllLines("2023\5\input.txt")

$seeds = ([Regex]::Matches($aoc_sample[0], '\d+').Value)
$newseeds = @()
for ($i = 0; $i -lt $seeds.Count; $i = $i + 2) {
    for ($j = 1; $j -lt $seeds[$i + 1]; $j++) {
        $newseeds += [int64]$seeds[$i] + $j
    }
}
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
            [bigint]$newmap[$map][$i]["destinationrangestart"] = @{}
            [bigint]$newmap[$map][$i]["sourcerangestart"] = @{}
            [bigint]$newmap[$map][$i]["rangelength"] = @{}
        }
        else {
            $values = $line -split " "
            $newmap[$map][$i] = @{}
            [bigint]$newmap[$map][$i]["destinationrangestart"] = $values[0]
            [bigint]$newmap[$map][$i]["sourcerangestart"] = $values[1]
            [bigint]$newmap[$map][$i]["rangelength"] = $values[2]
            $i++
        }
    }
}

function getNextMap ($currentMap) {
    $nextMap = ""
    foreach ($key in $newmap.Keys) {
        if ($key -match "$currentMap-to-*") {
            $nextMap = ($key -split '-')[2]
            return $nextMap
        }
    }
    if (!$nextMap) {
        return $false
    }
}
function getSeedLocation($currentMap, [int64]$amount) {
    $nextMap = getNextMap($currentMap)
    if ($nextMap) {
        foreach ($i in $newmap["$currentMap-to-$nextMap"].Values) {
            $corresponds = $amount
            if ($amount -ge $i.sourcerangestart -and $amount -lt ($i.sourcerangestart + $i.rangelength)) {
                $corresponds += $i.destinationrangestart - $i.sourcerangestart
                break
            }
        }
        getSeedLocation $nextMap $corresponds
    }
    else {
        return $corresponds
    }
}

$results = @()
foreach ($seed in $newseeds) {
    $results += getSeedLocation "seed" $seed
}
($results | Measure-Object -Minimum).Minimum