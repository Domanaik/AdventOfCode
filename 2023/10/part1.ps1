# https://adventofcode.com/2023/day/10

using namespace System.Collections.Generic

$global:aoc_sample = [System.IO.File]::ReadAllLines("2023\10\sample1.txt")
#$aoc_sample = [System.IO.File]::ReadAllLines("2023\10\sample2.txt")
#$aoc_sample = [System.IO.File]::ReadAllLines("2023\10\input.txt")

class Position {
    [int]$StartX
    [int]$StartY
    [int]$CurrentX
    [int]$CurrentY
    [int]$Steps
    [Direction]$Next
}

class Direction {
    [string]$Name
    [int]$X
    [int]$Y
    Direction([string]$name, [int]$x, [int]$y) {
        $this.Name = $name
        $this.X = $x
        $this.Y = $y
    }
}

class PipeShape {
    [string]$Name
    [Direction[]]$Valid
    PipeShape([string]$name, [Direction[]]$valid) {
        $this.Name = $name
        $this.Valid = $valid
    }
    PipeShape([string]$name) {
        $this.Name = $name
    }
}

function selfDetermination([Position]$start) {
    [List[PipeShape]]$self = @()
    Write-Host $nameNorth.Name => $aoc_sample[$start.CurrentY + $north.Y][$start.CurrentX + $north.X]
    Write-Host $nameEast.Name => $aoc_sample[$start.CurrentY + $east.Y][$start.CurrentX + $east.X]
    Write-Host $nameSouth.Name => $aoc_sample[$start.CurrentY + $south.Y][$start.CurrentX + $south.X]
    Write-Host $nameWest.Name => $aoc_sample[$start.CurrentY + $west.Y][$start.CurrentX + $west.X]
    if ($nameNorth.Name -contains ($aoc_sample[$start.CurrentY + $north.Y][$start.CurrentX + $north.X])) {
        $self += $nameNorth
    }
    if ($nameEast.Name -contains ($aoc_sample[$start.CurrentY + $east.Y][$start.CurrentX + $east.X])) {
        $self += $nameEast
    }
    if ($nameSouth.Name -contains ($aoc_sample[$start.CurrentY + $south.Y][$start.CurrentX + $south.X])) {
        $self += $nameSouth
    }
    if ($nameWest.Name -contains ($aoc_sample[$start.CurrentY + $west.Y][$start.CurrentX + $west.X])) {
        $self += $nameWest
    }
    return ($self | Group-Object Name | Sort-Object Count)[-1].Group[0].Valid[0]
    
}

function getNextPipe([Position]$start) {
    if ($start.StartX -eq $start.CurrentX -and $start.StartY -eq $start.CurrentY -and $start.Steps -gt 0) {
        $start.Steps
    }
    else {
        $start.Next = selfDetermination($start)
        $start.CurrentX += $start.Next.X
        $start.CurrentY += $start.Next.Y
        $start.Steps++
        getNextPipe($start)
    }
}

$north = [Direction]::new("North", 0, -1)
$east = [Direction]::new("East", 1, 0)
$south = [Direction]::new("South", 0, 1)
$west = [Direction]::new("West", -1, 0)

[List[PipeShape]]$pipeShapes = @() 
$pipeShapes.Add([PipeShape]::new("|", @($north, $south)))
$pipeShapes.Add([PipeShape]::new("-", @($east, $west)))
$pipeShapes.Add([PipeShape]::new("L", @($north, $east)))
$pipeShapes.Add([PipeShape]::new("J", @($north, $west)))
$pipeShapes.Add([PipeShape]::new("7", @($south, $west)))
$pipeShapes.Add([PipeShape]::new("F", @($south, $east)))
$pipeShapes.Add([PipeShape]::new("."))

$nameNorth = ($pipeShapes | Where-Object Valid -Contains $north)
$nameEast = ($pipeShapes | Where-Object Valid -Contains $east)
$nameSouth = ($pipeShapes | Where-Object Valid -Contains $south)
$nameWest = ($pipeShapes | Where-Object Valid -Contains $west)

[regex]$regex = "S"
$start = [Position]::new()
for ($i = 0; $i -lt ($aoc_sample.Length); $i++) {
    $match = $regex.Match($aoc_sample[$i])
    if ($match.Success) {
        $start.StartX = $match.Index
        $start.StartY = $i
        $start.CurrentX = $start.StartX
        $start.CurrentY = $start.StartY
        getNextPipe($start)
        break
    }
}