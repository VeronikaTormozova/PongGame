namespace PongGameLibrary.Interfaces
{
    public interface IMovable : IGameObject
    {
        double SpeedX { get; set; }
        double SpeedY { get; set; }
        void Move();
    }
}