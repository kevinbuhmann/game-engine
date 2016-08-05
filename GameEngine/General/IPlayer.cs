namespace GameEngine.General
{
    public interface IPlayer<TGameState, TMove>
    {
        string Name { get; }

        TMove NextMove(TGameState gameState);
    }
}
