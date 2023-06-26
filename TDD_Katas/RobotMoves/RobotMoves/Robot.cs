namespace RobotMoves
{
    public class Robot
    {
        private class RobotPositionChecker
        {
            private readonly Dictionary<char, int> amountOfMovesByMove = new Dictionary<char, int>();

            public RobotPositionChecker(string moves)
            {
                Initialize(moves);
            }

            public bool IsOnStartPosition()
            {
                amountOfMovesByMove.TryGetValue('U', out int countOfUpMove);
                amountOfMovesByMove.TryGetValue('D', out int countOfDownMove);
                amountOfMovesByMove.TryGetValue('R', out int countOfRightMove);
                amountOfMovesByMove.TryGetValue('L', out int countOfLeftMove);

                return (countOfUpMove == countOfDownMove) && (countOfRightMove == countOfLeftMove);
            }

            private void Initialize(string moves)
            {
                foreach (var move in moves)
                    IncrementAmountOfMove(move);
            }

            private void IncrementAmountOfMove(char move)
            {
                if (!amountOfMovesByMove.ContainsKey(move))
                    amountOfMovesByMove[move] = 0;

                amountOfMovesByMove[move]++;
            }
        }

        public bool IsOnStartPosition { get; set; }

        public void Move(string moves)
        {
            var robotPositionChecker = new RobotPositionChecker(moves);

            IsOnStartPosition = robotPositionChecker.IsOnStartPosition();
        }
    }
}