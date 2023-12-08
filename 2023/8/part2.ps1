# https://adventofcode.com/2023/day/8#part2

$aoc_sample = [System.IO.File]::ReadAllLines("2023\8\sample3.txt")
$aoc_sample = [System.IO.File]::ReadAllLines("2023\8\input.txt")

$instruction = $aoc_sample[0]
[regex]$regex = "(\w{3})\s=\s\((\w{3}),\s(\w{3})\)"
$instructions = @{}

for ($i = 0; $i -lt ($aoc_sample.Length - 2); $i++) {
    $match = $regex.Match($aoc_sample[$i + 2])
    $instructions[$match.Groups[1].Value] = @{}
    $instructions[$match.Groups[1].Value]["L"] = $match.Groups[2].Value
    $instructions[$match.Groups[1].Value]["R"] = $match.Groups[3].Value
}

$current = @{}
foreach ($possibleStart in $instructions.Keys) {
    if ($possibleStart.EndsWith("A")) {
        $current.Add($possibleStart, $instructions[$possibleStart])
    }
}

$i = 0
$steps = 0
do {
    $steps++
    $nextRun = @{}
    foreach ($start in $current.Keys) {
        #"run $steps, $start, left $($current[$start]["L"]), right $($current[$start]["R"])"
        $nextRun.Add($instructions[$start][($instruction.ToCharArray()[$i].ToString())], $instructions[$instructions[$start][($instruction.ToCharArray()[$i].ToString())]])
    }
    $current = $nextRun
    $allEndWithZ = $true
    foreach ($end in $current.Keys) {
        if (!($end.EndsWith("Z"))) { $allEndWithZ = $false }
    } 
    if (++$i -ge $instruction.Length) { $i = 0 }
} while ($allEndWithZ -eq $false)
$steps