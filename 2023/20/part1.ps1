# https://adventofcode.com/2023/day/20

using namespace System.Collections.Generic

#$aoc_sample = [System.IO.File]::ReadAllLines("2023\20\sample1.txt")
#$aoc_sample = [System.IO.File]::ReadAllLines("2023\20\sample2.txt")
$aoc_sample = [System.IO.File]::ReadAllLines("2023\20\input.txt")

enum Pulse {
    high
    low
}
enum State {
    on
    off
}

class Module {
    [String]$Name
    [string[]]$DestinationModules
}

class Flipflop : Module {
    [State]$State
    Flipflop([string]$name, [string[]]$destinations) {
        $this.Name = $name
        $this.DestinationModules += $destinations
        $this.State = [State]::off
        $Global:moduleConfiguration += $this
    }

    rx([Module]$source, [Pulse]$pulse) {
        if ($pulse -eq [Pulse]::low) {
            if ($this.State -eq [State]::off) {
                $this.State = [State]::on
                addPulseToTxQueue $this ([Pulse]::high) $this.DestinationModules
            }
            else {
                $this.State = [State]::off
                addPulseToTxQueue $this ([Pulse]::low) $this.DestinationModules
            }
        }
    }
}
class Conjunction : Module {
    $SourcePulses = @{}
    $initialized = $false
    Conjunction([string]$name, [string[]]$destinations) {
        $this.Name = $name
        $this.DestinationModules += $destinations
        $Global:moduleConfiguration += $this
    }

    init() {
        foreach ($module in ($Global:moduleConfiguration | Where-Object DestinationModules -Contains $this.Name)) {
            $this.SourcePulses.Add($module.Name, [Pulse]::low)
        }
        $this.initialized = $true
    }

    rx([Module]$source, [Pulse]$pulse) {
        $this.SourcePulses[$source.Name] = $pulse
        $tempPulse = [Pulse]::low
        foreach ($h in $this.SourcePulses.GetEnumerator()) {
            if ($h.Value -eq [Pulse]::low) {
                $tempPulse = [Pulse]::high
            }
        }
        addPulseToTxQueue $this $tempPulse $this.DestinationModules
    }
}
class Broadcast : Module {
    Broadcast([string[]]$destinations) {
        $this.Name = "broadcaster"
        [Button]::new()
        $this.DestinationModules += $destinations
        $Global:moduleConfiguration += $this
    }
    rx([Button]$source, [Pulse]$pulse) {
        addPulseToTxQueue $this $pulse $this.DestinationModules
    }
}

class Button : Module {
    Button() {
        $this.Name = "button"
        $Global:moduleConfiguration += $this
        $this.DestinationModules += "broadcaster"
    }
    aptly() {
        addPulseToTxQueue $this ([Pulse]::low) $this.DestinationModules
    }
}

$txQueue = @()
$lowPulses = 0
$highPulses = 0
function addPulseToTxQueue($source, [Pulse]$pulse, $destinations) {
    foreach ($destination in $destinations) {
        $tx = New-Object PSObject -Property @{
            Source      = $source
            Pulse       = $pulse
            Destination = $destination
        }
        if ($pulse -eq [Pulse]::low) {
            $Global:lowPulses++
        }
        else {
            $Global:highPulses++
        }
        $Global:txQueue += $tx
    }
}

$moduleConfiguration = @()
foreach ($line in $aoc_sample) {
    $match = [Regex]::Match($line, "^(.*)\s->\s(.*)$")
    if ($match.Groups[1].Value -eq "broadcaster") {
        [void][Broadcast]::new($match.Groups[2].Value.Split(', '))
    }
    elseif ($match.Groups[1].Value.StartsWith('%')) {
        [void][Flipflop]::new($match.Groups[1].Value.Remove(0, 1), $match.Groups[2].Value.Split(', '))
    }
    elseif ($match.Groups[1].Value.StartsWith('&')) {
        [void][Conjunction]::new($match.Groups[1].Value.Remove(0, 1), $match.Groups[2].Value.Split(', '))
    }
}

foreach ($toInit in ($moduleConfiguration | Where-Object initialized -eq $false)) {
    $toInit.init()
}
$pushes = 1
$runs = 1000
do {
    ($moduleConfiguration | Where-Object Name -eq "button").aptly()
    do {
        foreach ($task in $Global:txQueue) {
            #Write-Host "$($task.Source.Name) -$($task.Pulse)-> $($task.Destination)"
            $source = $moduleConfiguration | Where-Object Name -eq $task.Destination
            if ($source.rx) {
                $source.rx($task.Source, $task.Pulse)
            }
            $Global:txQueue = @($Global:txQueue | Select-Object -Skip 1)
        }
    } while ($Global:txQueue.Count -gt 0)
} while ($pushes++ -lt $runs)
"low $lowPulses, high $highPulses, total $($lowPulses * $highPulses)"