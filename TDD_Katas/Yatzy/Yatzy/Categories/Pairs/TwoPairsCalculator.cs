namespace Yatzy.Categories.Pairs
{
    internal class TwoPairsCalculator : ICategoryCalculator
    {
        private class TwoPairsScore
        {
            private readonly List<int> dicesWithTwoPairs = new List<int>();
            private readonly Dictionary<int, int> countByDice = new Dictionary<int, int>();

            public int Value => ThereIsTwoPairs ? dicesWithTwoPairs.Sum() * 2 : 0;
            private bool ThereIsTwoPairs => dicesWithTwoPairs.Count == 2;

            public TwoPairsScore(int[] roll)
            {
                Initialize(roll);
            }

            private void Initialize(int[] roll)
            {
                foreach (var dice in roll)
                {
                    IncrementCountByDice(dice);

                    if (ThereIsAPairForTheDice(dice))
                        dicesWithTwoPairs.Add(dice);
                }
            }

            private void IncrementCountByDice(int dice)
            {
                if (!countByDice.ContainsKey(dice))
                    countByDice[dice] = 0;

                countByDice[dice]++;
            }

            private bool ThereIsAPairForTheDice(int dice)
            {
                return countByDice[dice] == 2;
            }
        }

        public int Calculate(int[] roll)
        {
            var score = new TwoPairsScore(roll);

            return score.Value;
        }
    }
}