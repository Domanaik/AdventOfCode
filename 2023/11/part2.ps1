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
    [int64]$Sum

    [void]addList([string]$row) {
        $this.List += $row
    }

    [void]getPositions() { 
        [regex]$regex = "#"
        for ($i = 0; $i -lt $this.List.Length; $i++) {
            $match = $regex.Matches($this.List[$i])
            foreach ($index in $match.Index) {
                $position = [Position]::new($index, $i)
                $this.Positions += $position
            }
        }
    }

    [void]expandUniverse([int]$multiplier) {
        foreach ($position in $this.Positions) {
            $countX = 0
            $countY = 0
            for ($x = 0; $x -lt $position.X; $x++) {
                $temp = ""
                for ($y = 0; $y -lt $this.List.Length; $y++) {
                    $temp += $this.List[$y][$x]
                }
                if (!($temp.Contains("#"))) {
                    $countX += $multiplier
                }
            }
            for ($y = 0; $y -lt $position.Y; $y++) {
                $temp = $this.List[$y]
                if (!($temp.Contains("#"))) {
                    $countY += $multiplier
                }
            }
            $position.X += $countX
            $position.Y += $countY
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
}
$data.getPositions()
$data.expandUniverse(999999)
$data.calculatePathLength()
$data.Sum