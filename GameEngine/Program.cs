using GameEngine.TicTacToe;
using GameEngine.TicTacToe.Players;
using System;

namespace GameEngine
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            TicTacToePlayer player1 = new TicTacToeHumanPlayer(TicTacToeBoardValue.X);
            TicTacToePlayer player2 = new TicTacToeStrategyPlayer(TicTacToeBoardValue.O);

            TicTacToeGame game = new TicTacToeGame(player1, player2);

            //GameEngine<TicTacToeGame, TicTacToePlayer, TicTacToeGameState, TicTacToeMove>.RunMany(game, 10000);
            //Console.ReadKey();

            ConsoleKey key;
            do
            {
                GameEngine<TicTacToeGame, TicTacToePlayer, TicTacToeGameState, TicTacToeMove>.Run(game);
                game.Reset();

                Console.WriteLine();
                Console.Write("Press any key to play again or escape to exit...");
                key = Console.ReadKey().Key;
            } while (key != ConsoleKey.Escape);
        }
    }
}
