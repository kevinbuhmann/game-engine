using System;
using System.Collections.Generic;

namespace GameEngine.TicTacToe
{
    public class TicTacToeBoard : ICloneable
    {
        private readonly TicTacToeBoardValue?[,] values;

        public TicTacToeBoard()
        {
            this.values = new TicTacToeBoardValue?[3, 3];
        }

        private TicTacToeBoard(TicTacToeBoardValue?[,] values)
        {
            this.values = values;
        }

        public bool IsValidMove(TicTacToeMove move)
        {
            return move != null && this.values[move.X, move.Y] == null;
        }

        public bool MakeMove(TicTacToeMove move, TicTacToeBoardValue boardValue)
        {
            bool isValid = this.IsValidMove(move);
            if (isValid)
            {
                this.values[move.X, move.Y] = boardValue;
            }
            return isValid;
        }

        public void ResetPosition(int x, int y)
        {
            this.values[x, y] = null;
        }

        public TicTacToeBoardValue? GetBoardValueAtPosition(int x, int y)
        {
            return this.values[x, y];
        }

        public IEnumerable<TicTacToeMove> GetOpenMoves()
        {
            List<TicTacToeMove> openMoves = new List<TicTacToeMove>();

            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    TicTacToeMove move = new TicTacToeMove(x, y);
                    if (this.IsValidMove(move))
                    {
                        openMoves.Add(move);
                    }
                }
            }

            return openMoves;
        }

        public bool IsFull()
        {
            bool isFull = true;
            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    if (this.values[x, y] == null)
                    {
                        isFull = false;
                    }
                }
            }

            return isFull;
        }

        public TicTacToeBoardValue? CheckForWinner()
        {
            for (int x = 0; x < 3; x++)
            {
                if ((this.values[x, 0] != null) && (this.values[x, 0] == this.values[x, 1]) && (this.values[x, 0] == this.values[x, 2]))
                {
                    return this.values[x, 0];
                }
            }

            for (int y = 0; y < 3; y++)
            {
                if ((this.values[0, y] != null) && (this.values[0, y] == this.values[1, y]) && (this.values[0, y] == this.values[2, y]))
                {
                    return this.values[0, y];
                }
            }

            if ((this.values[0, 0] != null) && (this.values[0, 0] == this.values[1, 1]) && (this.values[0, 0] == this.values[2, 2]))
            {
                return this.values[0, 0];
            }

            if ((this.values[0, 2] != null) && (this.values[0, 2] == this.values[1, 1]) && (this.values[0, 2] == this.values[2, 0]))
            {
                return this.values[0, 2];
            }

            return null;
        }

        public void Print()
        {
            for (int x = 0; x < 3; x++)
            {
                Console.Write(" ");
                for (int y = 0; y < 3; y++)
                {
                    Console.Write(this.values[x, y]?.ToString() ?? " ");

                    if (y < 2)
                    {
                        Console.Write(" | ");
                    }
                }
                Console.WriteLine();

                if (x < 2)
                {
                    Console.WriteLine("-----------");
                }
            }

            Console.WriteLine();
            Console.WriteLine();
        }

        public object Clone()
        {
            TicTacToeBoardValue?[,] copy = new TicTacToeBoardValue?[3, 3];
            Array.Copy(this.values, copy, 9);

            return new TicTacToeBoard(copy);
        }
    }
}
