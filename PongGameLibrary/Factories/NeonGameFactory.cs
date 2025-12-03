using PongGameLibrary.Factories.Themes;
using PongGameLibrary.Interfaces;

namespace PongGameLibrary.Factories
{
    public class NeonGameFactory : IGameFactory
    {
        public IBall CreateBall()
        {
            return new NeonTheme.NeonBall();
        }

        public IPaddle CreatePaddle(double x, double y)
        {
            return new NeonTheme.NeonPaddle(x, y);
        }
    }
}