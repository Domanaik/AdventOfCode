using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using AdventOfCode._14;

class Program
{
    static void Main(string[] args)
    {
        string[] inputData = Input.GetInput().Split(Environment.NewLine);

        //(int x, int y) spaceSample = (11, 7);
        (int X, int Y) spaceInput = (101, 103);
        const int seconds = 10000;

        List<Robot> robots = [];

        foreach (var line in inputData)
        {
            var parts = line.Split(' ');

            var positionValues = parts[0][2..].Split(',');
            var velocityValues = parts[1][2..].Split(',');

            var robot = new Robot(
                (int.Parse(positionValues[0]), int.Parse(positionValues[1])),
                (int.Parse(velocityValues[0]), int.Parse(velocityValues[1]))
            );

            robots.Add(robot);
        }

        for (int i = 1; i < seconds; i++)
        {
            Bitmap mapImage = new(spaceInput.X, spaceInput.Y);

            foreach (var robot in robots)
            {
                robot.Fly(spaceInput);
                mapImage.SetPixel(robot.Position.X, robot.Position.Y, Color.White);
            }

            mapImage.Save($@"robots_{i}.png");

            if (i == 100)
            {
                Console.WriteLine(CalculateSafetyFactor(robots, spaceInput));
            }
        }

    }

    static int CalculateSafetyFactor(List<Robot> robots, (int X, int Y) space)
    {
        int midX = space.X / 2;
        int midY = space.Y / 2;

        int quadrant1 = 0, quadrant2 = 0, quadrant3 = 0, quadrant4 = 0;

        foreach (var robot in robots)
        {
            if (robot.Position.X == midX || robot.Position.Y == midY)
            {
                continue;
            }

            if (robot.Position.X < midX && robot.Position.Y < midY)
                quadrant1++;
            else if (robot.Position.X >= midX && robot.Position.Y < midY)
                quadrant2++;
            else if (robot.Position.X < midX && robot.Position.Y >= midY)
                quadrant3++;
            else if (robot.Position.X >= midX && robot.Position.Y >= midY)
                quadrant4++;
        }

        return quadrant1 * quadrant2 * quadrant3 * quadrant4;
    }
}

class Robot((int X, int Y) position, (int X, int Y) velocity)
{
    public (int X, int Y) Position { get; set; } = position;
    public (int X, int Y) Velocity { get; set; } = velocity;

    public void Fly((int X, int Y) space)
    {
        Position = (Position.X + Velocity.X, Position.Y + Velocity.Y);

        Position = (
            (Position.X % space.X + space.X) % space.X,
            (Position.Y % space.Y + space.Y) % space.Y
        );
    }
}