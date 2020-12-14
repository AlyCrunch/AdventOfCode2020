using System;
using System.Collections.Generic;
using System.Linq;

namespace Days
{
    public class SeatingSystem
    {
        public static int GetSeatsOccupied(string[] example)
        {
            IEnumerable<string> difference = null;
            var old = example;

            do
            {
                var current = GetNextState(old, GetOccupiedAdjacent);

                difference = old.Except(current);

                old = current;
            }
            while (difference.Count() > 0);

            return old.Sum(x => x.Count(y => y == '#'));
        }
        public static int GetSeatsOccupiedNew(string[] example)
        {
            IEnumerable<string> difference = null;
            var old = example;

            do
            {
                var current = GetNextState(old, GetOccupiedAdjecentNewRule, 5);

                difference = old.Except(current);

                old = current;
            }
            while (difference.Count() > 0);

            return old.Sum(x => x.Count(y => y == '#'));
        }

        private static string[] GetNextState(string[] seats, Func<int,int,string[], int> occupiedFunc, int occupiedSeat = 4)
        {
            var state = seats.Select(x => x.ToCharArray()).ToArray();

            for (int y = 0; y < seats.Length; y++)
            {
                for (int x = 0; x < seats[0].Length; x++)
                {
                    var nb = occupiedFunc(x, y, seats);
                    if (seats[y][x] == 'L' && nb == 0) state[y][x] = '#';
                    else if (seats[y][x] == '#' && nb >= occupiedSeat) state[y][x] = 'L';
                    else state[y][x] = seats[y][x];
                }
            }
            return state.Select(x => new string(x)).ToArray();
        }

        private static int GetOccupiedAdjacent(int x, int y, string[] seats)
        {
            bool IsInRange(int x, int y, string[] arr)
                => x >= 0 && x < arr[0].Length && y >= 0 && y < arr.Length;

            bool IsOccupied(char c)
                => (c == '#');

            bool IsSeatIsOccupied(int y, int x, string[] arr)
                => IsInRange(x, y, arr) && IsOccupied(seats[y][x]);

            int occupied = 0;
            if (IsSeatIsOccupied(y - 1, x - 1, seats)) occupied++;
            if (IsSeatIsOccupied(y - 1, x, seats)) occupied++;
            if (IsSeatIsOccupied(y - 1, x + 1, seats)) occupied++;
            if (IsSeatIsOccupied(y, x - 1, seats)) occupied++;
            if (IsSeatIsOccupied(y, x + 1, seats)) occupied++;
            if (IsSeatIsOccupied(y + 1, x - 1, seats)) occupied++;
            if (IsSeatIsOccupied(y + 1, x, seats)) occupied++;
            if (IsSeatIsOccupied(y + 1, x + 1, seats)) occupied++;

            return occupied;
        }

        public static int GetOccupiedAdjecentNewRule(int x, int y, string[] seats)
        {
            (int x, int y) TopRight() => (-1, -1);
            (int x, int y) Top() => (-1, 0);
            (int x, int y) TopLeft() => (-1, 1);
            (int x, int y) Right() => (0, -1);
            (int x, int y) Left() => (0, 1);
            (int x, int y) BottomRight() => (1, -1);
            (int x, int y) Bottom() => (1, 0);
            (int x, int y) BottomLeft() => (1, 1);

            bool IsInRange(int x, int y, string[] arr)
                => x >= 0 && x < arr[0].Length && y >= 0 && y < arr.Length;

            bool IsOccupied(char c)
                => (c == '#');

            bool IsEmpty(char c)
                => (c == 'L');

            bool IsSeatIsOccupied((int x, int y) dir, (int x, int y) seat, string[] arr)
            {
                (int x, int y) next = (seat.x + dir.x, seat.y + dir.y);
                if (!IsInRange(next.x, next.y, arr)) return false;
                do
                {
                    if (IsOccupied(arr[next.y][next.x])) return true;
                    if (IsEmpty(arr[next.y][next.x])) return false;
                    next.x += dir.x;
                    next.y += dir.y;
                }
                while (IsInRange(next.x, next.y, arr));
                return false;
            }

            int occupied = 0;
            if (IsSeatIsOccupied(TopRight(), (x, y), seats)) occupied++;
            if (IsSeatIsOccupied(Top(), (x, y), seats)) occupied++;
            if (IsSeatIsOccupied(TopLeft(), (x, y), seats)) occupied++;
            if (IsSeatIsOccupied(Right(), (x, y), seats)) occupied++;
            if (IsSeatIsOccupied(Left(), (x, y), seats)) occupied++;
            if (IsSeatIsOccupied(BottomRight(), (x, y), seats)) occupied++;
            if (IsSeatIsOccupied(Bottom(), (x, y), seats)) occupied++;
            if (IsSeatIsOccupied(BottomLeft(), (x, y), seats)) occupied++;

            return occupied;
        }

        public static string OutputFirst()
            => GetSeatsOccupied(Helpers.ReadFile("Inputs\\11.txt")).ToString();
        public static string OutputSecond()
            => GetSeatsOccupiedNew(Helpers.ReadFile("Inputs\\11.txt")).ToString();
    }
}