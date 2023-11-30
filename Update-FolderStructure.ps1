.\cookie.ps1
$date = Get-Date

foreach ($year in @(2015..$date.Year))
{
    if (!(Test-Path $year))
    {
        New-Item -ItemType Directory -Path $year
    }
    if (!(Test-Path "$year\day"))
    {
        New-Item -ItemType Directory -Path "$year\day"
    }
    foreach ($day in @(1..25))
    {
        if (!(Test-Path "$year\day\$day"))
        {
            New-Item -ItemType Directory -Path "$year\day\$day"
        }
        if (!(Test-Path "$year\day\$day\input"))
        {
            New-Item -ItemType Directory -Path "$year\day\$day\input"
        }
        if (!(Test-Path "$year\day\$day\input\input.txt"))
        {
            if ($year -lt $date.Year -or ($date.Month -eq 12 -and $day -le $date.Day))
            {
                (Invoke-WebRequest -Uri "https://adventofcode.com/$year/day/$day/input" -WebSession $session).Content | Out-File -FilePath "$year\day\$day\input\input.txt"
            }
            else {
                Write-Output "skip, $($date.Month) -ne 12 or $day -le $($date.Day)"
            }
        }
    }
}