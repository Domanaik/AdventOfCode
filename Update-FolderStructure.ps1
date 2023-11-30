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
                (Invoke-WebRequest -Uri "https://adventofcode.com/$year/day/$day/input" -WebSession $session).Content | Out-File -FilePath "$year\$day\input.txt"
            }
        }
        if (!(Test-Path "$year\$day\sample.txt"))
        {
            New-Item -ItemType File -Path "$year\$day\sample.txt"
        }
        $parts = "part1", "part2"
        foreach ($part in $parts)
        {
            if (!(Test-Path "$year\$day\$part"))
            {
                "# https://adventofcode.com/$year/day/$day" | Out-File -FilePath "$year\$day\$part.ps1"
                '' | Out-File -FilePath "$year\$day\$part.ps1" -Append
                '$input = Get-Content -Path "sample.txt"' | Out-File -FilePath "$year\$day\$part.ps1" -Append
                '#$input = Get-Content -Path "input.txt"' | Out-File -FilePath "$year\$day\$part.ps1" -Append
            }
        }
    }
}