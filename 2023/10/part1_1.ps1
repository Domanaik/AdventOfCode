# https://adventofcode.com/2023/day/10

using namespace System.Collections.Generic

$aoc_sample = [System.IO.File]::ReadAllLines("2023\10\sample1.txt")
#$aoc_sample = [System.IO.File]::ReadAllLines("2023\10\sample2.txt")
#$aoc_sample = [System.IO.File]::ReadAllLines("2023\10\input.txt")

class Position {
    [int]$StartX
    [int]$StartY
    [int]$CurrentX
    [int]$CurrentY
    [int]$Steps
    [Pipe]$Pipe
    [Direction]$CurrentDirection
    [Direction]$PreviousDirection
}

class Direction {
    [string]$Name
    [int]$X
    [int]$Y
    Direction($name, $x, $y) {
        $this.Name = $name
        $this.X = $x
        $this.Y = $y
    }
}

class Pipe {
    [string]$Name
    [Direction]$A
    [Direction]$B
    Pipe($name, $a, $b) {
        $this.Name = $name
        $this.A = $a
        $this.B = $b
    }
}

$global:directions = @{}
$directions["North"] = [Direction]::new("North", 0, -1)
$directions["East"] = [Direction]::new("East", 1, 0)
$directions["South"] = [Direction]::new("South", 0, 1)
$directions["West"] = [Direction]::new("West", -1, 0)

$global:pipes = @{}
$pipes["|"] = [Pipe]::new("|", $directions.North, $directions.South)
$pipes["-"] = [Pipe]::new("-", $directions.East, $directions.West)
$pipes["L"] = [Pipe]::new("L", $directions.North, $directions.East)
$pipes["J"] = [Pipe]::new("J", $directions.North, $directions.West)
$pipes["7"] = [Pipe]::new("7", $directions.South, $directions.West)
$pipes["F"] = [Pipe]::new("F", $directions.South, $directions.East)

function selfDetermination([Position]$currentStart) {
    $self = @()
    Write-Host $aoc_sample[$currentStart.CurrentY + $directions.North.Y][$currentStart.CurrentX + $directions.North.X]
    if ($pipes.'|'.Name, $pipes.L.Name, $pipes.J.Name -contains $aoc_sample[$currentStart.CurrentY + $directions.North.Y][$currentStart.CurrentX + $directions.North.X]) {
        $self += $pipes.'|', $pipes.L, $pipes.J
    }
    Write-Host $aoc_sample[$currentStart.CurrentY + $directions.East.Y][$currentStart.CurrentX + $directions.East.X]
    if ($pipes.'-'.Name, $pipes.L.Name, $pipes.F.Name -contains $aoc_sample[$currentStart.CurrentY + $directions.East.Y][$currentStart.CurrentX + $directions.East.X]) {
        $self += $pipes.'-', $pipes.L, $pipes.F
    }
    Write-Host $aoc_sample[$currentStart.CurrentY + $directions.South.Y][$currentStart.CurrentX + $directions.South.X]
    if ($pipes.'|'.Name, $pipes.'7'.Name, $pipes.F.Name -contains $aoc_sample[$currentStart.CurrentY + $directions.South.Y][$currentStart.CurrentX + $directions.South.X]) {
        $self += $pipes.'|', $pipes.'7', $pipes.F
    }
    Write-Host $aoc_sample[$currentStart.CurrentY + $directions.West.Y][$currentStart.CurrentX + $directions.West.X]
    if ($pipes.'-'.Name, $pipes.J.Name, $pipes.'7'.Name -contains $aoc_sample[$currentStart.CurrentY + $directions.West.Y][$currentStart.CurrentX + $directions.West.X]) {
        $self += $pipes.'-', $pipes.J, $pipes.'7'
    }
    return ($self | Group-Object Name | Sort-Object Count)[-1].Group[0]
}

function getNextPipe([Position]$currentStart) {
    if ($currentStart.StartX -eq $currentStart.CurrentX -and $currentStart.StartY -eq $currentStart.CurrentY -and $currentStart.Steps -gt 0) {
        $currentStart.Steps
    }
    else {
        $currentStart.CurrentX += $currentStart.Pipe.A.X
        $currentStart.CurrentY += $currentStart.Pipe.A.Y
        $currentStart.Steps++
        $currentStart.Pipe = getNextPipe $currentStart
    }
}

[regex]$regex = "S"
$start = [Position]::new()
for ($i = 0; $i -lt ($aoc_sample.Length); $i++) {
    $match = $regex.Match($aoc_sample[$i])
    if ($match.Success) {
        $start.StartX = $match.Index
        $start.StartY = $i
        $start.CurrentX = $start.StartX
        $start.CurrentY = $start.StartY
        $start.Pipe = selfDetermination $currentStart
        getNextPipe $start
        break
    }
}