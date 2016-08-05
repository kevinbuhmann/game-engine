using GameEngine.General;
using GameEngine.TicTacToe.Players;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace GameEngine.TicTacToe
{
    public class TicTacToeGame : IGame<TicTacToeRandomPlayer, TicTacToeGameState, TicTacToeMove>
    {
        private TicTacToeBoard board = new TicTacToeBoard();

        public TicTacToeGame(TicTacToeRandomPlayer player1, TicTacToeRandomPlayer player2)
        {
            if (player1.BoardValue == player2.BoardValue)
            {
                throw new Exception("players cannot have the same board value");
            }

            this.Players = new ReadOnlyCollection<TicTacToeRandomPlayer>(new List<TicTacToeRandomPlayer>() { player1, player2 });
        }

        public IEnumerable<TicTacToeRandomPlayer> Players { get; }

        public TicTacToeGameState GetCurrentGameState()
        {
            return new TicTacToeGameState(board);
        }

        public bool MakeMove(TicTacToeRandomPlayer player, TicTacToeMove move)
        {
            return this.board.MakeMove(move, player.BoardValue);
        }

        public bool IsGameOver()
        {
            return this.board.IsFull() || this.board.CheckForWinner() != null;
        }

        public TicTacToeRandomPlayer GetWinner()
        {
            TicTacToeBoardValue? winner = this.board.CheckForWinner();
            return winner != null ? this.Players.First(p => p.BoardValue == winner.Value) : null;
        }

        public void Print()
        {
            this.board.Print();
        }

        public void Reset()
        {
            this.board = new TicTacToeBoard();
        }
    }
}
