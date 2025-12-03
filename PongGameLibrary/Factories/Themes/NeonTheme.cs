using PongGameLibrary.GameObjects;

namespace PongGameLibrary.Factories.Themes
{
    public class NeonTheme
    {
        public class NeonBall : Ball
        {
            public NeonBall()
            {
                SpeedX = 8;
                SpeedY = 8;
            }
        }

        public class NeonPaddle : Paddle
        {
            public NeonPaddle(double x, double y) : base(x, y) { }
        }

    }
}
