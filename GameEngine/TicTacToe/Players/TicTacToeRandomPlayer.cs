using System;
using System.Linq;

namespace GameEngine.TicTacToe.Players
{
    public class TicTacToeRandomPlayer : TicTacToePlayer
    {
        public TicTacToeRandomPlayer(TicTacToeBoardValue boardValue)
            : base(boardValue)
        {
        }

        public override TicTacToeMove NextMove(TicTacToeGameState gameState)
        {
            return gameState.Board.GetOpenMoves()
                .OrderBy(x => Guid.NewGuid())
                .FirstOrDefault();
        }
    }
}
