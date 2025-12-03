using PongGameLibrary.Interfaces;

namespace PongGameLibrary.Strategies
{
    public interface IMovementStrategy
    {
        int GetMoveDirection(IPaddle me, IBall ball);
    }
}