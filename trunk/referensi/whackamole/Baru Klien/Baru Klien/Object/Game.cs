using System;

namespace WhackAMole.Object
{
    [Serializable]
    class Game
    {
        public string Puzzle;
        public int Point;

        public Game(string puzzle, int point)
        {
            Puzzle = puzzle;
            Point = point;
        }
    }
}
