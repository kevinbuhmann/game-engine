namespace GameEngine.TicTacToe
{
    public class TicTacToeGameState
    {
        public TicTacToeGameState(TicTacToeBoard board)
        {
            this.Board = board.Clone() as TicTacToeBoard;
        }

        public TicTacToeBoard Board { get; }
    }
}
