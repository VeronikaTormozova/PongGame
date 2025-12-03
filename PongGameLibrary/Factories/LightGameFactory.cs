using PongGameLibrary.Factories.Themes;
using PongGameLibrary.Interfaces;

namespace PongGameLibrary.Factories
{
    public class LightGameFactory : IGameFactory
    {
        public IBall CreateBall()
        {
            return new LightTheme.LightBall();
        }

        public IPaddle CreatePaddle(double x, double y)
        {
            return new LightTheme.LightPaddle(x, y);
        }
    }
}