foreach ($year in @(2015..$((Get-Date).Year)))
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
    }
}