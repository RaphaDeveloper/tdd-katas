namespace Yatzy.Categories.NumberOfAKind
{
    internal class NumberOfAKindScore
    {
        private readonly int number;
        private readonly Dictionary<int, int> countByDices = new Dictionary<int, int>();
        private int dice;

        public int Value => dice * number;

        public NumberOfAKindScore(int[] roll, int number)
        {
            this.number = number;
            Initialize(roll);
        }

        private void Initialize(int[] roll)
        {
            foreach (var dice in roll)
            {
                IncrementCountByDice(dice);

                if (countByDices[dice] == number)
                    this.dice = dice;
            }
        }

        private void IncrementCountByDice(int dice)
        {
            if (!countByDices.ContainsKey(dice))
                countByDices[dice] = 0;

            countByDices[dice]++;
        }
    }
}