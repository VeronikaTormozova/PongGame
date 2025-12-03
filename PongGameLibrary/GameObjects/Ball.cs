using System;
using System.Collections.Generic;
using PongGameLibrary.Interfaces;
using PongGameLibrary.Observer;

namespace PongGameLibrary.GameObjects
{
    public class Ball : IBall, ISubject
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Width { get; set; } = 15;
        public double Height { get; set; } = 15;

        public double SpeedX { get; set; } = 6; 
        public double SpeedY { get; set; } = 6;

        private List<IObserver> _observers = new List<IObserver>();

        public void Attach(IObserver observer)
        {
            _observers.Add(observer);
        }

        public void Detach(IObserver observer)
        {
            _observers.Remove(observer);
        }

        public void Notify(string message)
        {
            foreach (var observer in _observers)
            {
                observer.Update(message);
            }
        }

        public void Move()
        {
            X += SpeedX;
            Y += SpeedY;
        }

        public void CheckCollision(double areaWidth, double areaHeight, IPaddle leftPaddle, IPaddle rightPaddle)
        {
            if (Y <= 0 || Y + Height >= areaHeight)
            {
                SpeedY = -SpeedY;
            }

            if (X < 0)
            {
                Notify("Goal_Right"); 
            }
            else if (X > areaWidth)
            {
                Notify("Goal_Left"); 
            }

            if (CheckPaddleCollision(leftPaddle) || CheckPaddleCollision(rightPaddle))
            {
                SpeedX = -SpeedX;
            }
        }

        private bool CheckPaddleCollision(IPaddle paddle)
        {
            if (paddle == null) return false;

            bool collisionX = X < paddle.X + paddle.Width && X + Width > paddle.X;
            bool collisionY = Y < paddle.Y + paddle.Height && Y + Height > paddle.Y;

            return collisionX && collisionY;
        }
    }
}