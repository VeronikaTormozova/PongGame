namespace PongGameLibrary.States
{
    public class GameOverState : IGameState
    {
        public void Update() { }

        public void HandleInput(string input)
        {
            if (input == "Restart")
            {
                GameEngine.Instance.RestartGame();
            }
        }
    }
}