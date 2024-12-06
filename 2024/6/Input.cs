namespace AdventOfCode._6
{
    public static class Input
    {
        public static string GetSample()
        {
            return @"....#.....
.........#
..........
..#.......
.......#..
..........
.#..^.....
........#.
#.........
......#...";
        }

        public static string GetInput()
        {
            return @"...........#....................#......#.....................#.#...........#......................................................
.....................................#....#.................#...............................#.....................................
..#..#.......#.............................................#.#.........................#......................#..............#....
.........................#.....#...............#.................#................................................................
.......#..........#........#.#............................................#....#.....................#..........##..#.............
.........#.....................................................#..............................................................#...
.....#..............................................................#................##.....#...........#.......#.........#.......
.......#.........#......#...............#............................#.........#.....#.....#...#..................................
.......#...............#...................#...............#............#.......................................................#.
........#.......................................................................##..#..............#...#..........................
..............#........#.......................#......#...............#..#......................#......#...#............#.........
................#................#...........................................#.....#................#..........#..................
..##....................#...........#......................#..................#.......#...........................................
..................................................................#..........#...................#................................
........................#.......#..........................#................................#.....................#...#.#.........
...............#........#...............#.##..#.#...............#...........#......................................#..............
.#.........#.#...............................................................................#..........................#...#.....
..............................#.....#.............##..............#.##....................#......#.................#....#.........
..............#.............................#........#.....#..........................................#...........#...............
...................#.................#..............#....##..#......................#..............................#....#.#.......
.............##.....................#..........#....................................#.....................#...#.#.................
.........................#..........#.......#.................................#...................................................
............#.................#.................................................#.........##....................#.........#.....#.
.#.........#.........................#..............#............#..#...........................##.........#......................
...........................#.....#...................#....#...........#.#.#...........#...................#.......................
.................#..#......#..............................................................................#...................#...
...............................#..............#...#..#......##.#.........................#........#...........#...................
........#...............##.............................................................#..........................#...............
.............#.............#.............#...................#...........#....................#...................................
##.......................................................................................#....#...........#....#...........#......
.....................#.#.......................................#.....................................#.................#..........
......................#...................................................................#.....................#............#...#
.........................#.#........................#.#................#....#....#.....#..........................................
.....................#...#.......................................#.......#.............#...................#......................
.............#...............#...............................................................................................#....
........................................................................................................#........#.........#......
.................................##....................#....#..............#.....#.....#..#....#.........................#.#.....#
.........................................................................#........#........#.........................#...#........
#...................#..........#......................#..............................#.#........................#.................
.#.....................................................................#..#.......#........................#......................
.......................#..............#..............#..#..............................#..........................................
...................................................................................................#...................#..........
...............#............#....................................#.....................#....................#.....................
............#..#.#..........#.#.......#..........................#.................#.#..........#.......#.........................
.......#....#.............................#..............................#..#........................#........#...................
........#.................#.....#.#..............................#........................#...................#..........#........
............................#........................#.........................................................#..................
....................................#.............##....................................................................#..#......
..................................................#................................................#..............#........#...##.
...........##.................#.........................#....................................................#...........#........
...........#.#..................#.......................#...#.......#................#.......##...................................
................................................#...........#........#.......................#.....................#....#.#.......
...............#........................................#............................#.....................................#......
........#...#.....#.......................................................#.#................................#.#..................
.....#............#.#...............#.#.....#....................#.#...................#...................##.........#..........#
............#.................#....................................................#...........................................#..
................#..#.....#....................................#................#...#..............................................
.....................................................................#...............#............................................
..................#...........#.....#...................#....#..............................................#.....................
.#............#...................................#.........#.........................................#...........#...............
#.......#..#...#.....#............................................................................................................
..#.........................................................##..............................#................................#....
..............................#..............#........................................................#....................#......
#.........#.........#.............#..............#............................#..........#........................#..#............
....#...........#..........................##......#.............................#.....#........................#.................
.....#.................................................................#..#.......................................................
..........................#.......#.......#..................#....................................................................
................#....................#..................#.........................................................................
..............................................#..........................#...........#.....#...........................#....#.#...
.##...............#...#...........................................................................................................
..................#..#.......................#...#..#.#.................................#.........................#...........#...
..........................................................................#....................................#..................
#...........#.............................##.....................#........#....#...#........#.....................#.....#.........
.......#.............................#...^....#..................................#.........#......................................
........#..............................#................................#.....#....##.............................................
.................#...........................#........................#..........#..........#.................#.#..........#.....#
..................................................................................................................#...............
..........#.........#........................#........................................................#........................#..
................................................................................................................#.................
....................#......................#....#.......#.....#...................................................................
................................#........................................................#.........................###............
......#..............#.#....................#............#.......................#.......................................#........
.........................#....................................#..............#.......#............................................
..............#.................#........................................................#..#.....................................
.....#.#........................#...........................................#..#.....#.................#................#......##.
................#.............#...................................................................................................
#....................#..........#..............##...#........#..#.........................#............#......#..................#
...........#..#.......#.....................#..........................................................#........#.................
...............................................#................#...........#................................#....................
.............#.......#.................#........#.............................................#...........#.......................
....................#.......#.....#.......................#.................#.............#.........................#.............
.#..............#.................................................................................................................
..#.#......................................#.................#.........#...................................#.#....................
......#..............................#........#.#..................#................#.................................#...........
..............#........................................#..........................................................................
.#...........#.........#...........#...................#................#..................................#............#..#......
.........#....#...................#..#.................................................................#....#.....................
..........#...........................#.....................................#...............#.......#...#.........................
...........#..................................#............................................................##................#....
.......................#..#.......................................................................................................
...............................................#......................#.#.#.............#..#........#...........................#.
..#.................................................#..............................#.....................................#........
..........#..#..........#...................#......................................##......#.......#........#.....#...............
.#.#...............................................##...#................#..............#.....#...................................
....................#..#...............................#..#.......#....................#....#.....................#.....#.#.......
#...................#...........#...................................................#...........................#..##.........###.
.............#.........#......#..........................#.................#......##................#...............#...#.........
........#.....................................................................................#...................................
..#...........#...................................#...................#............................#.........#.................#..
.................................................................................#................................................
.#........#.................#......................................#.....#...........#................#...........................
#...........................#..............................#....#............................................................#....
#..........#.............................................#..........#.......................................................#.....
.........#...#...#...#............................................................#....#..........#.......................#.......
.........................#.........................#........#............#..............#.....##.........................#...#....
...............................#...........#..............................................#......................#......#.........
......................#........................#..#.....................#...............................#........................#
......#...##..............................................................................................................#.......
............#.............#.#...............................................#.........#..........................#...........#....
.......................................#............#...............................................#.............................
....#........#.............................#...............#.#................................................#...................
.........#.#........................#.....#...##...#.........###............#.#.........#......#.........#................#.....#.
...........#....................#......................##...............#.......................................................#.
#......................................................#.................##....................................#........#.....#...
..#..........................##.................#...........................................#.....................................
.......................................#............#......#...#.........#......##......................................#.........
.#.......#.........................................##..............................................#.#...................#........
.................#.........#..........................##............................#..#.....#....................................
.....#....................................#......................................#.......................#...........#..#..#......
.......#......#.........#.....#........#......#.................#...........#............#..................#....#...........#....";
        }
    }
}