namespace Yatzy.Categories.Straights
{
    internal class LargeStraightCalculator : ICategoryCalculator
    {
        public int Calculate(int[] roll)
        {
            int currentNumber = 2;

            for (int i = 1; i < roll.Length; i++)
            {
                if (roll[i] != currentNumber++)
                    return 0;
            }

            return 20;
        }
    }
}