using PongGameLibrary.Interfaces;

namespace PongGameLibrary.Strategies
{
    public class HumanStrategy : IMovementStrategy
    {
        public int GetMoveDirection(IPaddle me, IBall ball)
        {
            return 0; 
        }
    }
}