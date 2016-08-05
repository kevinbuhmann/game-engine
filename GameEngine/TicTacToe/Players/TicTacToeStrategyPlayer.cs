using System;
using System.Collections.Generic;
using System.Linq;

namespace GameEngine.TicTacToe.Players
{
    public class TicTacToeStrategyPlayer : TicTacToeRandomPlayer
    {
        public TicTacToeStrategyPlayer(TicTacToeBoardValue boardValue)
            : base(boardValue)
        {
        }

        public override TicTacToeMove NextMove(TicTacToeGameState gameState)
        {
            if (gameState.Board.IsFull())
            {
                return null;
            }

            // Can I win?
            TicTacToeMove winningMove = this.CheckForWin(gameState, this.BoardValue);

            // Can they win?
            TicTacToeBoardValue otherBoardValue = this.BoardValue == TicTacToeBoardValue.O ?
                TicTacToeBoardValue.X : TicTacToeBoardValue.O;
            TicTacToeMove blockingMove = this.CheckForWin(gameState, otherBoardValue);

            // Can I play a corner?
            TicTacToeMove cornerMove = new TicTacToeMove[]
            {
                new TicTacToeMove(0, 0),
                new TicTacToeMove(0, 2),
                new TicTacToeMove(2, 0),
                new TicTacToeMove(2, 2)
            }.OrderBy(move => Guid.NewGuid()).FirstOrDefault(move => gameState.Board.IsValidMove(move));


            // play best move
            return winningMove ?? blockingMove ?? cornerMove ?? base.NextMove(gameState);
        }

        private TicTacToeMove CheckForWin(TicTacToeGameState gameState, TicTacToeBoardValue boardValue)
        {
            IEnumerable<TicTacToeMove> openMoves = gameState.Board.GetOpenMoves();
            foreach (TicTacToeMove move in openMoves)
            {
                gameState.Board.MakeMove(move, boardValue);

                TicTacToeBoardValue? winner = gameState.Board.CheckForWinner();
                if (winner == boardValue)
                {
                    return move;
                }

                gameState.Board.ResetPosition(move.X, move.Y);
            }

            return null;
        }
    }
}
