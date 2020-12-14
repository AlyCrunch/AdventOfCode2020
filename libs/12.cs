using System;
using System.Collections.Generic;
using System.Text;

namespace Days
{
    public static class RainRisk
    {
        private static readonly LinkedList<int> directions = new LinkedList<int>(new List<int>() { 0, 1, 2, 3 });

        public static int GetManhattanDistance(string[] example)
        {
            var (x, y) = GetDistance(example);
            return Math.Abs(x) + Math.Abs(y);
        }
        public static int GetManhattanDistanceNew(string[] example)
        {
            var (x, y) = GetDistanceNewRules(example);
            return Math.Abs(x) + Math.Abs(y);
        }

        private static (int x, int y) GetDistance(string[] instruction)
        {
            var facing = directions.First;
            (int x, int y) positioning = (0, 0);

            static LinkedListNode<int> TurnRight(int degrees, LinkedListNode<int> facing)
            {
                var times = (degrees / 90) % 4;
                for (int i = 1; i <= times; i++)
                {
                    facing = facing.Next ?? facing.List.First;
                }
                return facing;
            }

            static LinkedListNode<int> TurnLeft(int degrees, LinkedListNode<int> facing)
            {
                var times = (degrees / 90) % 4;
                for (int i = 1; i <= times; i++)
                {
                    facing = facing.Previous ?? facing.List.Last;
                }
                return facing;
            }

            static (int, int) Navigate(int face, int value)
            {
                return face switch
                {
                    0 => (value, 0),
                    1 => (0, value),
                    2 => (-value, 0),
                    3 => (0, -value),
                    _ => (0, 0),
                };
            }

            foreach (var instr in instruction)
            {
                var action = instr[0];
                int value = int.Parse(instr[1..]);
                switch (action)
                {
                    case 'N': positioning.y -= value; break;
                    case 'S': positioning.y += value; break;
                    case 'E': positioning.x += value; break;
                    case 'W': positioning.x -= value; break;
                    case 'L': facing = TurnLeft(value, facing); break;
                    case 'R': facing = TurnRight(value, facing); break;
                    case 'F': positioning = Add(positioning, Navigate(facing.Value, value)); break;
                }
            }

            return positioning;
        }

        private static (int x, int y) GetDistanceNewRules(string[] instruction)
        {
            (int x, int y) ship = (0, 0);
            (int x, int y) waypoint = (10, -1);

            static (int,int) RotateRight((int x, int y) point, int degrees)
            {
                var times = (degrees / 90) % 4;
                return times switch
                {
                    0 => point,
                    1 => (point.y * -1, point.x),
                    2 => (point.x * -1, point.y * -1),
                    3 => (point.y, point.x * -1),
                    _ => point,
                };
            }
            static (int, int) RotateLeft((int x, int y) point, int degrees)
            {
                var times = (degrees / 90) % 4;
                return times switch
                {
                    0 => point,
                    1 => (point.y, point.x * -1),
                    2 => (point.x * -1, point.y * -1),
                    3 => (point.y * -1, point.x),
                    _ => point,
                };
            }

            foreach (var instr in instruction)
            {
                var action = instr[0];
                int value = int.Parse(instr[1..]);
                switch (action)
                {
                    case 'N': waypoint.y -= value; break;
                    case 'S': waypoint.y += value; break;
                    case 'E': waypoint.x += value; break;
                    case 'W': waypoint.x -= value; break;
                    case 'R': waypoint = RotateRight(waypoint, value);break;
                    case 'L': waypoint = RotateLeft(waypoint, value); break;
                    case 'F': ship = Add(ship, Multiply(waypoint, value));break;
                }
            }

            return ship;
        }

        private static (int,int) Add((int x, int y) a, (int x, int y) b)
            => (a.x + b.x, a.y + b.y);
        private static (int, int) Multiply((int x, int y) a, int multiplier)
            => (a.x * multiplier, a.y * multiplier);

        #region Printing methods
        public static string OutputFirst()
            => GetManhattanDistance(Helpers.ReadFile("Inputs\\12.txt")).ToString();
        public static string OutputSecond()
            => GetManhattanDistanceNew(Helpers.ReadFile("Inputs\\12.txt")).ToString();
        #endregion
    }
}
