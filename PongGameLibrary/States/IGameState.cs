namespace PongGameLibrary.States
{
    public interface IGameState
    {
        void Update();
        void HandleInput(string input);
    }
}