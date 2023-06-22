namespace Yatzy.Categories.Pairs
{
    internal class PairCalculator : ICategoryCalculator
    {
        private class HighestPairScore
        {
            private int highest = 0;
            private readonly Dictionary<int, int> countByDice = new Dictionary<int, int>();

            public int Value => highest * 2;

            public HighestPairScore(int[] roll)
            {
                Initialize(roll);
            }

            private void Initialize(int[] roll)
            {
                foreach (var dice in roll)
                {
                    IncrementCountByDice(dice);

                    if (DiceIsTheHighestPairUntilNow(dice))
                        highest = dice;
                }
            }

            private void IncrementCountByDice(int dice)
            {
                if (!countByDice.ContainsKey(dice))
                    countByDice[dice] = 0;

                countByDice[dice]++;
            }

            private bool DiceIsTheHighestPairUntilNow(int dice)
            {
                return countByDice[dice] == 2 && dice > highest;
            }
        }

        public int Calculate(int[] roll)
        {
            var score = new HighestPairScore(roll);

            return score.Value;
        }
    }
}