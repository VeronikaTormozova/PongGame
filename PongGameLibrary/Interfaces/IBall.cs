using System;

namespace PongGameLibrary.Interfaces
{
    public interface IBall : IMovable
    {
        void CheckCollision(double areaWidth, double areaHeight, IPaddle paddle1, IPaddle paddle2);
    }
}