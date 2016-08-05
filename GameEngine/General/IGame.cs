using System.Collections.Generic;

namespace GameEngine.General
{
    public interface IGame<TPlayer, TGameState, TMove>
        where TPlayer : IPlayer<TGameState, TMove>
    {
        IEnumerable<TPlayer> Players { get; }

        bool MakeMove(TPlayer player, TMove move);

        TGameState GetCurrentGameState();

        bool IsGameOver();

        TPlayer GetWinner();

        void Print();

        void Reset();
    }
}
