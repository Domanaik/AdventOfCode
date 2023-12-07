# https://adventofcode.com/2023/day/7#part2

$aoc_sample = [System.IO.File]::ReadAllLines("2023\7\sample.txt")
$aoc_sample = [System.IO.File]::ReadAllLines("2023\7\input.txt")

[regex]$regex = "^(\w{5})\s(\d+)$"

class Card {
    [string]$Name
    [int]$Value

    [void]addCard([string]$name, [int]$value) {
        $this.Name = $name
        $this.Value = $value
    }
}

class HandType {
    [string]$Name
    [int]$Value

    [void]addHandType([string]$name, [int]$value) {
        $this.Name = $name
        $this.Value = $value
    }
}

class Hand {
    [Card[]]$Cards
    [Card[]]$CardsWithoutJoker
    [int]$Bid
    [HandType]$HandType
    [int]$Value
    [int]$ValueWithoutJoker

    [void]addCardToHand([Card]$cards) {
        $this.Cards += $cards
    }
    [void]addBid([int]$bid) {
        $this.Bid = $bid
    }
    [void]addHandType([HandType]$handType) {
        $this.HandType = $handType
    }
    [void]replaceJoker() {
        foreach ($card in $this.Cards) {
            if ($card.Name -eq 'J') {
                $highestValueCard = $this.Cards.Name | Sort-Object | Group-Object | Where-Object Name -NE "J" | Select-Object -Property *, @{Name = 'Value'; Expression = { $name = $_.Name; (@($cards).where({ $_.Name -eq $name })).Value } } | Sort-Object Count, Value | Select-Object -Last 1
                $valueCard = [Card]::new()
                [void]$valueCard.addCard($highestValueCard.Name, $highestValueCard.Value)
                $this.CardsWithoutJoker += $valueCard
            }
            else {
                $this.CardsWithoutJoker += $card
            }
        }
    }
    [void]addValue() {
        $hex = '0x'
        for ($i = 0; $i -lt $this.CardsWithoutJoker.Length; $i++) {
            $hex += '{0:X}' -f $this.CardsWithoutJoker[$i].Value
        }
        $this.ValueWithoutJoker = [int]$hex

        $hex = '0x'
        for ($i = 0; $i -lt $this.Cards.Length; $i++) {
            $hex += '{0:X}' -f $this.Cards[$i].Value
        }
        $this.Value = [int]$hex
    }
    [Array]getCardsSortedByRank() {
        return $this.CardsWithoutJoker.Value | Sort-Object
    }
    [bool]isFiveOfAKind() {
        $handValues = $this.CardsWithoutJoker.Value | Measure-Object -Minimum -Maximum
        if ($handValues.Minimum -eq $handValues.Maximum) {
            return $true
        }
        return $false
    }
    [bool]isFourOfAKind() {
        $handValues = $this.getCardsSortedByRank()
        if ($handValues[0] -eq $handValues[3] -or $handValues[1] -eq $handValues[4]) {
            return $true
        }
        return $false
    }
    [bool]isFullHouse() {
        $handValues = $this.getCardsSortedByRank()
        if (($handValues[0] -eq $handValues[2] -and $handValues[3] -eq $handValues[4]) -or ($handValues[0] -eq $handValues[1] -and $handValues[2] -eq $handValues[4])) {
            return $true
        }
        return $false
    }
    [bool]isThreeOfAKind() {
        $handValues = $this.getCardsSortedByRank()
        if ($handValues[0] -eq $handValues[2] -or $handValues[1] -eq $handValues[3] -or $handValues[2] -eq $handValues[4]) {
            return $true
        }
        return $false
    }
    [bool]isTwoPair() {
        $handValues = $this.getCardsSortedByRank()
        if (($handValues[0] -eq $handValues[1] -and $handValues[2] -eq $handValues[3]) -or ($handValues[0] -eq $handValues[1] -and $handValues[3] -eq $handValues[4]) -or ($handValues[1] -eq $handValues[2] -and $handValues[3] -eq $handValues[4])) {
            return $true
        }
        return $false
    }
    [bool]isOnePair() {
        $handValues = $this.getCardsSortedByRank()
        if ($handValues[0] -eq $handValues[1] -or $handValues[1] -eq $handValues[2] -or $handValues[2] -eq $handValues[3] -or $handValues[3] -eq $handValues[4]) {
            return $true
        }
        return $false
    }
    [bool]isHighCard() {
        return $true
    }
}

$cards = New-Object Collections.Generic.List[Card]
$cardnames = "A", "K", "Q", "T", "9", "8", "7", "6", "5", "4", "3", "2", "J"
for ($i = 0; $i -lt $cardnames.Count; $i++) {
    $card = [Card]::new()
    $card.addCard($cardnames[$i], $cardnames.Count - $i)
    [void]$cards.Add($card)
}

$handTypes = New-Object Collections.Generic.List[HandType]
$handnames = "Five of a kind", "Four of a kind", "Full house", "Three of a kind", "Two pair", "One pair", "High card"
for ($i = 0; $i -lt $handnames.Count; $i++) {
    $handType = [HandType]::new()
    $handType.addHandType($handnames[$i], $handnames.Count - $i)
    [void]$handTypes.Add($handType)
}

function Measure-HandType ([Hand]$hand) {
    if ($hand.isFiveOfAKind()) {
        $hand.addHandType(($handTypes | Where-Object Name -EQ "Five of a kind"))
    }
    elseif ($hand.isFourOfAKind()) {
        $hand.addHandType(($handTypes | Where-Object Name -EQ "Four of a kind"))
    }
    elseif ($hand.isFullHouse()) {
        $hand.addHandType(($handTypes | Where-Object Name -EQ "Full House"))
    }
    elseif ($hand.isThreeOfAKind()) {
        $hand.addHandType(($handTypes | Where-Object Name -EQ "Three of a kind"))
    }
    elseif ($hand.isTwoPair()) {
        $hand.addHandType(($handTypes | Where-Object Name -EQ "Two Pair"))
    }
    elseif ($hand.isOnePair()) {
        $hand.addHandType(($handTypes | Where-Object Name -EQ "One Pair"))
    }
    elseif ($hand.isHighCard()) {
        $hand.addHandType(($handTypes | Where-Object Name -EQ "High card"))
    }
}

$hands = New-Object Collections.Generic.List[Hand]
foreach ($line in $aoc_sample) {
    $match = $regex.Match($line)
    $hand = [Hand]::new()
    foreach ($singlecard in [char[]]$match.Groups[1].Value) {
        #
        $hand.addCardToHand(($cards | Where-Object Name -EQ $singlecard))
    }
    $hand.replaceJoker()
    $hand.addBid($match.Groups[2].Value)
    $hand.addValue()
    Measure-HandType($hand)
    [void]$hands.Add($hand)
}

$totalwinnings = 0
$i = 1
foreach ($result in ($hands | Sort-Object { $_.HandType.Value }, Value)) {
    "$($result.CardsWithoutJoker.Name) | Primary $($result.HandType.Value) ($($result.HandType.Name)), Secondary $($result.Value) | $totalwinnings + $i * $($result.Bid) => $($totalwinnings + $result.Bid * $i)"
    $totalwinnings += $result.Bid * $i++
}
$totalwinnings