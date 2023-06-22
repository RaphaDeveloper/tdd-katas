namespace Yatzy.Categories.FullHouse
{
    internal class FullHouseCalculator : ICategoryCalculator
    {
        private class FullHouseScore
        {
            private readonly Dictionary<int, int> countByDice = new Dictionary<int, int>();

            public int Value => IsAFullHouse ? countByDice.Sum(c => c.Key * c.Value) : 0;
            private bool IsAFullHouse => ThereAreJustTwoDices && ThereIsTwoOfAKind;
            private bool ThereAreJustTwoDices => countByDice.Count == 2;
            private bool ThereIsTwoOfAKind => countByDice.Values.Any(v => v == 2);

            public FullHouseScore(int[] roll)
            {
                Initialize(roll);
            }

            private void Initialize(int[] roll)
            {
                foreach (var dice in roll)
                    IncrementCountOfDice(dice);
            }

            private void IncrementCountOfDice(int dice)
            {
                if (!countByDice.ContainsKey(dice))
                    countByDice[dice] = 0;

                countByDice[dice]++;
            }
        }

        public int Calculate(int[] roll)
        {
            var score = new FullHouseScore(roll);

            return score.Value;
        }
    }
}