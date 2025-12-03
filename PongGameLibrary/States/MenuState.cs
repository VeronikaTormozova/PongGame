namespace PongGameLibrary.States
{
    public class MenuState : IGameState
    {
        public void Update() { }

        public void HandleInput(string input)
        {
            if (input == "Start")
            {
                GameEngine.Instance.ChangeState(new PlayingState());
            }
        }
    }
}