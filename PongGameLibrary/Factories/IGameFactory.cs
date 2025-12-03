using PongGameLibrary.Interfaces;

namespace PongGameLibrary.Factories
{
    public interface IGameFactory
    {
        IBall CreateBall();
        IPaddle CreatePaddle(double x, double y);
    }
}