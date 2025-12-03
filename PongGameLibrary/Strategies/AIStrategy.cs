using System;
using PongGameLibrary.Interfaces;

namespace PongGameLibrary.Strategies
{
    public class AIStrategy : IMovementStrategy
    {
        private Random _random = new Random();
        private double _targetOffset = 0;
        private int _frames = 0;

        public int GetMoveDirection(IPaddle me, IBall ball)
        {
            if (ball.SpeedX < 0 && me.X > 400)
            {
                double centerField = 225;
                if (Math.Abs((me.Y + me.Height / 2) - centerField) < 10) return 0;
                return (me.Y + me.Height / 2) < centerField ? 1 : -1;
            }

            if (Math.Abs(me.X - ball.X) > 500) return 0;

            _frames++;
            if (_frames > 15) 
            {
                _targetOffset = _random.Next(-25, 26);
                _frames = 0;
            }

            double ballCenterY = ball.Y + ball.Height / 2;
            double paddleCenterY = me.Y + me.Height / 2;
            double targetY = ballCenterY + _targetOffset;

            if (Math.Abs(paddleCenterY - targetY) < 15) return 0;
            if (paddleCenterY < targetY) return 1; 
            return -1; 
        }
    }
}