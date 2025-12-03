using PongGameLibrary.Strategies;

namespace PongGameLibrary.Interfaces
{
    public interface IPaddle : IGameObject
    {
        void MoveUp();
        void MoveDown(double screenHeight);
        IMovementStrategy Strategy { get; set; }
        void UpdateAI(IBall ball, double screenHeight);
    }
}