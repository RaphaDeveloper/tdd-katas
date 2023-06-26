namespace BowlingGame
{
    public class BowlingGameCalculator
    {
        public int CalculateScore(string rounds)
        {
            return CalculateScore(CreateRounds(rounds));
        }

        private int CalculateScore(List<int> rounds)
        {
            int score = 0;

            int frame = 1;
            int turn = 0;

            while (turn < rounds.Count)
            {
                int roundScore = rounds[turn];
                int frameScore = roundScore;

                if (frame <= 10)
                {
                    int nextRoundScore = rounds[turn + 1];
                    frameScore += nextRoundScore;

                    if (IsAStrike(roundScore) || IsASpare(roundScore, nextRoundScore))
                        frameScore += rounds[turn + 2];

                    score += frameScore;
                }

                if (IsAStrike(roundScore))
                    turn++;
                else
                    turn += 2;

                frame++;
            }

            return score;
        }

        private static List<int> CreateRounds(string rounds)
        {
            var result = new List<int>();
            int lastRoundScore = 0;

            for (int i = 0; i < rounds.Length; i++)
            {
                int roundScore = ConvertRound(rounds[i], lastRoundScore);

                lastRoundScore = roundScore;

                result.Add(roundScore);
            }

            return result;
        }

        private static int ConvertRound(char round, int lastRoundScore)
        {
            if (round == '-')
                return 0;

            if (round == '/')
                return 10 - lastRoundScore;

            if (round == 'X')
                return 10;

            return GetRoundScore(round);
        }

        private static int GetRoundScore(char round)
        {
            return Convert.ToInt32(round.ToString());
        }

        private static bool IsAStrike(int roundScore)
        {
            return roundScore == 10;
        }

        private static bool IsASpare(int roundScore, int nextRoundScore)
        {
            return roundScore + nextRoundScore == 10;
        }
    }
}