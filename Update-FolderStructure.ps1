.\cookie.ps1
$date = Get-Date

foreach ($year in @(2015..$date.Year))
{
    if (!(Test-Path $year))
    {
        $null = New-Item -ItemType Directory -Path $year
    }
    foreach ($day in @(1..25))
    {
        if (!(Test-Path "$year\$day"))
        {
            $null = New-Item -ItemType Directory -Path "$year\$day"
        }
        if (!(Test-Path "$year\$day\input.txt"))
        {
            if ($year -lt $date.Year -or ($date.Month -eq 12 -and $day -le $date.Day))
            {
                [System.IO.File]::WriteAllText("$year\$day\input.txt", ((Invoke-WebRequest -Uri "https://adventofcode.com/$year/day/$day/input" -WebSession $session).Content))
            }
        }
        if (!(Test-Path "$year\$day\sample.txt"))
        {
            [System.IO.File]::WriteAllText("$year\$day\sample.txt",'')
        }
        $parts = "part1", "part2"
        foreach ($part in $parts)
        {
            if (!(Test-Path "$year\$day\$part"))
            {
                [System.IO.File]::WriteAllText("$year\$day\$part.ps1","# https://adventofcode.com/$year/day/$day")
                [System.IO.File]::AppendAllText("$year\$day\$part.ps1",'')
                [System.IO.File]::AppendAllText("$year\$day\$part.ps1",'$input = Get-Content -Path "sample.txt"')
                [System.IO.File]::AppendAllText("$year\$day\$part.ps1",'#$input = Get-Content -Path "input.txt"')
            }
        }
    }
}