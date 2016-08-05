using System;

namespace GameEngine.TicTacToe
{
    public class TicTacToeMove
    {
        public TicTacToeMove(int x, int y)
        {
            if (x < 0 || x > 2 || y < 0 || y > 2)
            {
                throw new Exception("invalid coordinates");
            }

            this.X = x;
            this.Y = y;
        }

        public int X { get; }

        public int Y { get; }
    }
}
