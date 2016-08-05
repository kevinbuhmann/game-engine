using GameEngine.General;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GameEngine.TicTacToe
{
    public abstract class TicTacToePlayer : IPlayer<TicTacToeGameState, TicTacToeMove>
    {
        public TicTacToePlayer(TicTacToeBoardValue boardValue)
        {
            this.BoardValue = boardValue;
        }

        public TicTacToeBoardValue BoardValue { get; }

        public string Name
        {
            get
            {
                return this.BoardValue.ToString();
            }
        }

        public abstract TicTacToeMove NextMove(TicTacToeGameState gameState);
    }
}
