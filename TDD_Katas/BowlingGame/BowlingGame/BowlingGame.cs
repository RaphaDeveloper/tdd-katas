namespace BowlingGame
{
    public class BowlingGameCalculator
    {
        public int Calculate(string turns)
        {
            int score = 0;
            var frames = FrameFactory.CreateFrames(turns);

            LinkedListNode<Frame> currentFrameNode = frames.First;
            while (currentFrameNode != null)
            {
                score += CalculateCurrentFrameScore(currentFrameNode);

                currentFrameNode = currentFrameNode.Next;
            }

            return score;
        }

        private int CalculateCurrentFrameScore(LinkedListNode<Frame> currentFrameNode)
        {
            Frame currentFrame = currentFrameNode.Value;

            int score = currentFrame.Score;

            if (currentFrame.IsSpare)
                score += CalculateSpareBonus(currentFrameNode);
            else if (currentFrame.IsStrike)
                score += CalculateStrikeBonus(currentFrameNode);

            return score;
        }

        private int CalculateSpareBonus(LinkedListNode<Frame> currentFrameNode)
        {
            if (currentFrameNode.Next != null)
            {
                var nextFrame = currentFrameNode.Next.Value;

                if (!nextFrame.IsBonus)
                    return nextFrame.Score1;
            }

            return 0;
        }

        private int CalculateStrikeBonus(LinkedListNode<Frame> currentFrameNode)
        {
            if (currentFrameNode.Next != null)
            {
                var nextFrame = currentFrameNode.Next.Value;

                if (!nextFrame.IsBonus)
                {
                    int score = nextFrame.Score;

                    if (nextFrame.IsStrike && currentFrameNode.Next.Next != null)
                    {
                        nextFrame = currentFrameNode.Next.Next.Value;

                        score += nextFrame.Score1;
                    }

                    return score;
                }
            }

            return 0;
        }
    }

    public class Frame
    {
        public Frame(bool isBonus, char score1, char score2)
        {
            IsBonus = isBonus;
            UpdateScore1(score1);
            UpdateScore2(score2);
        }

        private void UpdateScore1(char score)
        {
            Score1 = GetScore(score);
        }        

        private void UpdateScore2(char score)
        {
            if (!IsStrike || IsBonus)
                Score2 = GetScore2(score);
        }
        private int GetScore2(char score)
        {
            if (score == '/')
                return 10 - Score1;

            return GetScore(score);
        }

        private int GetScore(char score)
        {
            if (score == '-')
                return 0;

            if (score == 'X')
                return 10;

            return Convert.ToInt32(score.ToString());
        }

        public int Score1 { get; set; }
        public int Score2 { get; set; }
        public bool IsBonus { get; set; }

        public int Score => Score1 + Score2;
        public bool IsSpare => !IsStrike && Score == 10;
        public bool IsStrike => Score1 == 10;
    }

    public class FrameFactory
    {
        public static LinkedList<Frame> CreateFrames(string turns)
        {
            List<Frame> frames = new List<Frame>();
            int currentTurn = 0;
            int frameNumber = 1;

            while (currentTurn < turns.Length)
            {
                bool isBonus = frameNumber++ > 10;
                char score1 = turns[currentTurn];
                char score2 = GetScore2(turns, currentTurn + 1);

                var frame = new Frame(isBonus, score1, score2);

                frames.Add(frame);

                currentTurn = GetNextTurn(currentTurn, frame);
            }

            return new LinkedList<Frame>(frames);
        }

        private static char GetScore2(string turns, int turn)
        {
            if (turn < turns.Length)
                return turns[turn];

            return '-';
        }

        private static int GetNextTurn(int turn, Frame frame)
        {
            if (frame.IsStrike && !frame.IsBonus)
                return turn + 1;

            return turn + 2;
        }
    }
}