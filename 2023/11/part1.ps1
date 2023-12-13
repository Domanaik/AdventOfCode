# https://adventofcode.com/2023/day/11

using namespace System.Collections.Generic

$aoc_sample = [System.IO.File]::ReadAllLines("2023\11\sample.txt")
$aoc_sample = [System.IO.File]::ReadAllLines("2023\11\input.txt")

class Position {
    [int]$X
    [int]$Y
    Position([int]$x, [int]$y) {
        $this.X = $x
        $this.Y = $y
    }
}

class Data {
    [string[]]$List
    [List[Position]]$Positions
    [int]$Sum

    [void]addList([string]$row) {
        $this.List += $row
    }

    [void]expandUniverseRow([string]$row) {
        if (!($row.Contains("#"))) {
            $this.addList($row)
        }
    }
    
    [void]expandUniverseColumn() {

        for ($i = 0; $i -lt ($this.List | Sort-Object Length | Select-Object -Last 1).Length; $i++) {
            $temp = ""
            for ($j = 0; $j -lt $this.List.Length; $j++) {
                $temp += $this.List[$j][$i]
            }
            if (!($temp.Contains("#"))) {
                for ($j = 0; $j -lt $this.List.Length; $j++) {
                    $this.List[$j] = ($this.List[$j][0..$i] + "." + $this.List[$j][($i + 1)..$this.List[$j].Length]) -join ''
                }
                $i++
            }
        }
    }   

    [void]getPositions() { 
        [regex]$regex = "#"
        for ($i = 0; $i -lt $this.List.Length; $i++) {
            $match = $regex.Matches($this.List[$i])
            foreach ($index in $match.Index) {
                $pos = [Position]::new($index, $i)
                $this.Positions += $pos
            }
        }
    }

    [void]calculatePathLength() {
        for ($i = 0; $i -lt $this.Positions.Count; $i++) {
            for ($j = $i + 1; $j -lt $this.Positions.Count; $j++) {
                $this.Sum += [Math]::Abs($this.Positions[$i].X - $this.Positions[$j].X) + [Math]::Abs($this.Positions[$i].Y - $this.Positions[$j].Y)
            }
        }
    }
}

$data = [Data]::new()
foreach ($row in $aoc_sample) {
    $data.addList($row)
    $data.expandUniverseRow($row)
}
$data.expandUniverseColumn()
$data.getPositions()
$data.calculatePathLength()
$data.Sum