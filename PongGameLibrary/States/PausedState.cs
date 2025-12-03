namespace PongGameLibrary.States
{
    public class PausedState : IGameState
    {
        public void Update() { }

        public void HandleInput(string input)
        {
            if (input == "Resume" || input == "Pause")
            {
                GameEngine.Instance.ChangeState(new PlayingState());
            }
        }
    }
}