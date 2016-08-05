using System;
using System.Collections.Generic;
using System.Linq;

namespace GameEngine.TicTacToe.Players
{
    public class TicTacToeHumanPlayer : TicTacToeRandomPlayer
    {
        public TicTacToeHumanPlayer(TicTacToeBoardValue boardValue)
            : base(boardValue)
        {
        }

        public override TicTacToeMove NextMove(TicTacToeGameState gameState)
        {
            Console.Clear();

            Console.WriteLine($"Player {this.Name}'s turn:");
            Console.WriteLine();
            Console.WriteLine();

            gameState.Board.Print();

            IEnumerable<TicTacToeMove> openMoves = gameState.Board.GetOpenMoves();

            TicTacToeMove selectedMove = openMoves.First();
            SetCursorToMove(selectedMove);

            while (true)
            {
                ConsoleKey key = Console.ReadKey().Key;

                switch (key)
                {
                    case ConsoleKey.UpArrow:
                        selectedMove = openMoves
                            .OrderByDescending(move => move.Y < selectedMove.Y)
                            .ThenByDescending(move => move.X == selectedMove.X)
                            .ThenByDescending(move => move.Y)
                            .FirstOrDefault() ?? selectedMove;
                        break;
                    case ConsoleKey.DownArrow:
                        selectedMove = openMoves
                            .OrderByDescending(move => move.Y > selectedMove.Y)
                            .ThenByDescending(move => move.X == selectedMove.X)
                            .ThenBy(move => move.Y)
                            .FirstOrDefault() ?? selectedMove;
                        break;
                    case ConsoleKey.LeftArrow:
                        selectedMove = openMoves
                            .OrderByDescending(move => move.X < selectedMove.X)
                            .ThenByDescending(move => move.Y == selectedMove.Y)
                            .ThenByDescending(move => move.X)
                            .FirstOrDefault() ?? selectedMove;
                        break;
                    case ConsoleKey.RightArrow:
                        selectedMove = openMoves
                            .OrderByDescending(move => move.X > selectedMove.X)
                            .ThenByDescending(move => move.Y == selectedMove.Y)
                            .ThenBy(move => move.X)
                            .FirstOrDefault() ?? selectedMove;
                        break;
                    case ConsoleKey.Enter:
                        Console.Clear();
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine();
                        return selectedMove;
                }

                SetCursorToMove(selectedMove);
            }
        }

        private static void SetCursorToMove(TicTacToeMove move)
        {
            if (Console.CursorLeft > 0)
            {
                Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                Console.Write("_");
            }

            Console.SetCursorPosition(1 + move.X * 4, 3 + move.Y * 2);
        }
    }
}
