using PongGameLibrary.GameObjects;

namespace PongGameLibrary.Factories.Themes
{
    public class LightTheme
    {
        public class LightBall : Ball { }

        public class LightPaddle : Paddle
        {
            public LightPaddle(double x, double y) : base(x, y) { }
        }
    }
}
