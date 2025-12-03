using PongGameLibrary.GameObjects;
using PongGameLibrary.Interfaces;

namespace PongGameLibrary.Factories
{
    public class ClassicGameFactory : IGameFactory
    {
        public IBall CreateBall()
        {
            return new Ball();
        }

        public IPaddle CreatePaddle(double x, double y)
        {
            return new Paddle(x, y);
        }
    }
}