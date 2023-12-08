# https://adventofcode.com/2023/day/5
# Credits an Nulz <3

using namespace System.Collections.Generic

$aoc_sample = [System.IO.File]::ReadAllLines("2023\5\sample.txt")
$aoc_sample = [System.IO.File]::ReadAllLines("2023\5\input.txt")

class Range {
    [int64]$Rangestart
    [int64]$Rangeend
    Range([int64]$rangestart, [int64]$rangelength) {
        $this.Rangestart = $rangestart
        $this.Rangeend = $rangestart + $rangelength - 1
    }
}

class ConvertionRange {
    [Range]$Destination
    [Range]$Source
    ConvertionRange([int64]$destinationrangestart, [int64]$sourcerangestart, [int64]$rangelength) {
        $this.Destination = [Range]::new($destinationrangestart, $rangelength)
        $this.Source = [Range]::new($sourcerangestart, $rangelength)
    }
}

class ConvertionDict {
    [string]$Source
    [string]$Destination
    [List[ConvertionRange]]$PossibleConvertions = @()
    ConvertionDict([string]$source, [string]$destination) {
        $this.Source = $source
        $this.Destination = $destination
        $this.PossibleConvertions = @()
    }
    initializeConvertion([List[string]]$convertionStrings) {
        foreach ($convertionString in $convertionStrings) {
            $split_conv = $convertionString.Split()
            $this.PossibleConvertions.Add([ConvertionRange]::new([int64]$split_conv[0], [int64]$split_conv[1], [int64]$split_conv[2]))
        }
    }
}

function fillRulesetGaps([ConvertionDict]$convertionDict, [Range]$range) {
    [List[ConvertionRange]]$convertionRules = $convertionDict.PossibleConvertions | Sort-Object { $_.Source.Rangestart }
    [List[ConvertionRange]]$newRules = @()
    if ($range.Rangestart -lt $convertionRules[0].Source.Rangestart) {
        $newRules.Add([ConvertionRange]::new($range.Rangestart, $range.Rangestart, $convertionRules[0].Source.Rangestart - $range.Rangestart))
    }
    if ($range.Rangeend -gt $convertionRules[-1].Source.Rangeend) {
        $newRules.Add([ConvertionRange]::new($convertionRules[-1].Source.Rangeend, $convertionRules[-1].Source.Rangeend, $range.Rangeend - $convertionRules[-1].Source.Rangeend))
    }

    for ($i = 0; $i -lt ($convertionRules.Count - 1 ); $i++) {
        if ($convertionRules[$i].Source.Rangeend + 1 -ne $convertionRules[$i + 1].Source.Rangestart) {
            $newRules.Add([ConvertionRange]::new($convertionRules[$i].Source.Rangeend + 1, $convertionRules[$i].Source.Rangeend + 1, $convertionRules[$i + 1].Source.Rangestart - $convertionRules[$i].Source.Rangeend + 1))
        }
    }
    return $convertionRules + $newRules
}

function calculateRangeConvertion([Range]$seedRange, [List[ConvertionRange]]$convertionRules) {
    [List[Range]]$newRanges = @()
    foreach ($convertionRange in $convertionRules) {
        if ($seedRange.Rangeend -lt $convertionRange.Source.Rangestart -or $seedRange.Rangestart -gt $convertionRange.Source.Rangeend) {
            continue
        }
        $newStart = ($seedRange.Rangestart, $convertionRange.Source.Rangestart | Measure-Object -Maximum).Maximum
        $newEnd = ($seedRange.Rangeend, $convertionRange.Source.Rangeend | Measure-Object -Minimum).Minimum
        $destStart = $convertionRange.Destination.Rangestart + $newStart - $convertionRange.Source.Rangestart
        $destEnd = $convertionRange.Destination.Rangestart + $newEnd - $convertionRange.Source.Rangestart
        $newRanges.Add([Range]::new($destStart, $destEnd - $destStart))
    }
    return $newRanges
}

function calculateLocationsBySeedRanges([List[Range]]$seedPairs, [List[ConvertionDict]]$convertionDicts) {
    [List[Range]]$locationRanges = @()
    foreach ($source in $seedPairs) {
        [List[Range]]$currentRanges = & { $source }
        foreach ($convertionDict in $convertionDicts) {
            [List[Range]]$newRanges = @()
            foreach ($seedRange in $currentRanges) {
                $updatedConvertionRules = fillRulesetGaps $convertionDict $seedRange
                # This will write each item to the local pipeline inside the ScriptBlock, which gets captured to the variable.
                # https://stackoverflow.com/a/55382398
                $newRanges = & {
                    $newRanges
                    [List[Range]](calculateRangeConvertion $seedRange $updatedConvertionRules)
                }
            }
            $currentRanges = $newRanges
        }
        # This will write each item to the local pipeline inside the ScriptBlock, which gets captured to the variable.
        # https://stackoverflow.com/a/55382398
        $locationRanges = & {
            $locationRanges
            $currentRanges
        }
    }
    return $locationRanges
}

[List[Range]]$initialSeeds = @()
$seeds = ([Regex]::Matches($aoc_sample[0], '\d+').Value)
for ($i = 0; $i -lt $seeds.Count / 2; $i++) {
    [void]$initialSeeds.Add([Range]::new([int64]$seeds[$i * 2], [int64]$seeds[$i * 2 + 1]))
}

[List[ConvertionDict]]$convertionDicts = @()
foreach ($line in $aoc_sample | Select-Object -Skip 2) {
    if ($line -match "map:$") {
        $split_source_dest = $line.Split("-")
        $source = $split_source_dest[0]
        $destination = $split_source_dest[2].Split()[0]
        $currentDict = [ConvertionDict]::new($source, $destination)
        $convertionStrings = @()
    }
    elseif ($line -ne '') {
        $convertionStrings += $line
    }
    else { 
        $currentDict.initializeConvertion($convertionStrings)
        $convertionDicts.Add($currentDict)
    }
}
$currentDict.initializeConvertion($convertionStrings)
$convertionDicts.Add($currentDict)

$locationRanges = calculateLocationsBySeedRanges $initialSeeds $convertionDicts
($locationRanges.Rangestart | Measure-Object -Minimum).Minimum