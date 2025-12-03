namespace PongGameLibrary.States
{
    public class PlayingState : IGameState
    {
        public void Update()
        {
            var engine = GameEngine.Instance;

            engine.Ball?.Move();
            engine.Ball?.CheckCollision(engine.FieldWidth, engine.FieldHeight, engine.LeftPaddle, engine.RightPaddle);
            engine.LeftPaddle?.UpdateAI(engine.Ball, engine.FieldHeight);
            engine.RightPaddle?.UpdateAI(engine.Ball, engine.FieldHeight);
        }

        public void HandleInput(string input)
        {
            var engine = GameEngine.Instance;
            switch (input)
            {
                case "Pause": engine.ChangeState(new PausedState()); break;
                case "W": engine.LeftPaddle?.MoveUp(); break;
                case "S": engine.LeftPaddle?.MoveDown(engine.FieldHeight); break;
                case "Up": engine.RightPaddle?.MoveUp(); break;
                case "Down": engine.RightPaddle?.MoveDown(engine.FieldHeight); break;
            }
        }
    }
}