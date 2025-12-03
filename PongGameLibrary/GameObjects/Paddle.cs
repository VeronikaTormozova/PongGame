using PongGameLibrary.Interfaces;
using PongGameLibrary.Strategies;

namespace PongGameLibrary.GameObjects
{
    public class Paddle : IPaddle
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Width { get; set; } = 10;
        public double Height { get; set; } = 80;

        private double _speed = 20;

        public IMovementStrategy Strategy { get; set; }

        public Paddle(double x, double y)
        {
            X = x;
            Y = y;
            Strategy = new HumanStrategy();
        }

        public void MoveUp()
        {
            Y -= _speed;
            if (Y < 0) Y = 0;
        }

        public void MoveDown(double screenHeight)
        {
            Y += _speed;
            if (Y + Height > screenHeight) Y = screenHeight - Height;
        }

        public void UpdateAI(IBall ball, double screenHeight)
        {
            if (Strategy == null) return;

            int direction = Strategy.GetMoveDirection(this, ball);

            if (direction == -1) MoveUp();
            else if (direction == 1) MoveDown(screenHeight);
        }
    }
}