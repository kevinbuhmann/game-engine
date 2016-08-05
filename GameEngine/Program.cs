using GameEngine.TicTacToe;
using GameEngine.TicTacToe.Players;
using System;

namespace GameEngine
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            TicTacToeStrategyPlayer player1 = new TicTacToeStrategyPlayer(TicTacToeBoardValue.X);
            TicTacToeRandomPlayer player2 = new TicTacToeRandomPlayer(TicTacToeBoardValue.O);

            TicTacToeGame game = new TicTacToeGame(player1, player2);

            //GameEngine<TicTacToeGame, TicTacToeRandomPlayer, TicTacToeGameState, TicTacToeMove>.Run(game);
            GameEngine<TicTacToeGame, TicTacToeRandomPlayer, TicTacToeGameState, TicTacToeMove>.RunMany(game, 1000);

            Console.WriteLine();
            Console.Write("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
