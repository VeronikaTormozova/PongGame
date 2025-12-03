using System;
using PongGameLibrary.Factories;
using PongGameLibrary.Interfaces;
using PongGameLibrary.Observer;
using PongGameLibrary.States;
using PongGameLibrary.Strategies;

namespace PongGameLibrary
{
    public class GameEngine : IObserver
    {
        private static GameEngine _instance;
        private IGameState _currentState;
        private Random _random = new Random();

        public int WinningScore { get; set; } = 0;

        private GameEngine()
        {
            _currentState = new MenuState();
        }

        public static GameEngine Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new GameEngine();
                return _instance;
            }
        }

        public IGameState CurrentState => _currentState;

        public IBall Ball { get; private set; }
        public IPaddle LeftPaddle { get; private set; }
        public IPaddle RightPaddle { get; private set; }
        public int ScoreLeft { get; private set; }
        public int ScoreRight { get; private set; }
        public double FieldWidth { get; private set; }
        public double FieldHeight { get; private set; }
        public double BallSpeed { get; private set; }
        public double BallSize { get; private set; }
        public double PaddleHeight { get; private set; }

        public void Initialize(IGameFactory factory, double width, double height, int scoreLimit,
                               double ballSpeed, double ballSize, double paddleHeight,
                               IMovementStrategy leftStrategy, IMovementStrategy rightStrategy)
        {
            FieldWidth = width;
            FieldHeight = height;
            WinningScore = scoreLimit;
            BallSpeed = ballSpeed;
            BallSize = ballSize;
            PaddleHeight = paddleHeight;
            ScoreLeft = 0;
            ScoreRight = 0;

            Ball = factory.CreateBall();
            Ball.Width = BallSize;
            Ball.Height = BallSize;

            LeftPaddle = factory.CreatePaddle(20, height / 2 - paddleHeight / 2);
            LeftPaddle.Height = PaddleHeight;
            LeftPaddle.Strategy = leftStrategy;

            RightPaddle = factory.CreatePaddle(width - 40, height / 2 - paddleHeight / 2);
            RightPaddle.Height = PaddleHeight;
            RightPaddle.Strategy = rightStrategy;

            if (Ball is ISubject ballSubject)
            {
                ballSubject.Attach(this);
            }

            ResetBall(0);
        }

        public void Update(string message)
        {
            if (message == "Goal_Left")
            {
                ScoreRight++;
                CheckWinCondition(1);
            }
            else if (message == "Goal_Right")
            {
                ScoreLeft++;
                CheckWinCondition(-1);
            }
        }

        private void CheckWinCondition(int nextDirection)
        {
            if (WinningScore > 0 && (ScoreLeft >= WinningScore || ScoreRight >= WinningScore))
            {
                ChangeState(new GameOverState());
            }
            else
            {
                ResetBall(nextDirection);
            }
        }

        private void ResetBall(int directionX)
        {
            if (Ball == null) return;

            Ball.X = FieldWidth / 2 - Ball.Width / 2;
            Ball.Y = FieldHeight / 2 - Ball.Height / 2;

            if (directionX == 0)
            {
                directionX = _random.Next(0, 2) == 0 ? 1 : -1;
            }
            Ball.SpeedX = directionX * BallSpeed;

            int dirY = _random.Next(0, 2) == 0 ? 1 : -1;
            Ball.SpeedY = dirY * BallSpeed;
        }

        public void ChangeState(IGameState newState)
        {
            _currentState = newState;
        }

        public void Update()
        {
            _currentState.Update();
        }

        public void ProcessInput(string input)
        {
            _currentState.HandleInput(input);
        }

        public void RestartGame()
        {
            ScoreLeft = 0;
            ScoreRight = 0;

            if (LeftPaddle != null) LeftPaddle.Y = FieldHeight / 2 - LeftPaddle.Height / 2;
            if (RightPaddle != null) RightPaddle.Y = FieldHeight / 2 - RightPaddle.Height / 2;

            ResetBall(0);
            ChangeState(new PlayingState());
        }
    }
}

