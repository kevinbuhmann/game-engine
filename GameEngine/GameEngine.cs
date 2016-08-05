using GameEngine.General;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GameEngine
{
    public static class GameEngine<TGame, TPlayer, TGameState, TMove>
        where TGame : IGame<TPlayer, TGameState, TMove>
        where TPlayer : IPlayer<TGameState, TMove>
    {
        public static TPlayer Run(TGame game, bool print = true)
        {
            if (print)
            {
                game.Print();
            }

            while (!game.IsGameOver())
            {
                foreach (TPlayer player in game.Players)
                {
                    TGameState gameState = game.GetCurrentGameState();
                    TMove move = player.NextMove(gameState);
                    game.MakeMove(player, move);

                    if (print)
                    {
                        game.Print();
                    }

                    if (game.IsGameOver())
                    {
                        break;
                    }
                }
            }

            TPlayer winner = game.GetWinner();

            if (print)
            {
                Console.WriteLine(winner != null ? $"Winner: {winner.Name}" : "No Winner");
            }

            return winner;
        }

        public static void RunMany(TGame game, int numGames)
        {
            Dictionary<string, int> playerWinTracker = new Dictionary<string, int>();
            Dictionary<string, int> strategyWinTracker = new Dictionary<string, int>();

            for (int i = 0; i < numGames; i++)
            {
                TPlayer winner = Run(game, false);
                game.Reset();

                string winnerName = winner?.Name ?? "Draw";
                if (!playerWinTracker.ContainsKey(winnerName))
                {
                    playerWinTracker[winnerName] = 0;
                }
                playerWinTracker[winnerName]++;

                string strategy = winner?.GetType().Name ?? "None";
                if (!strategyWinTracker.ContainsKey(strategy))
                {
                    strategyWinTracker[strategy] = 0;
                }
                strategyWinTracker[strategy]++;
            }

            foreach (string winnerName in playerWinTracker.Keys.OrderByDescending(key => key))
            {
                Console.WriteLine($"Player {winnerName} won {playerWinTracker[winnerName]} games.");
            }

            Console.WriteLine();

            foreach (string stategy in strategyWinTracker.Keys.OrderBy(key => key))
            {
                Console.WriteLine($"Strategy {stategy} won {strategyWinTracker[stategy]} games.");
            }
        }
    }
}
