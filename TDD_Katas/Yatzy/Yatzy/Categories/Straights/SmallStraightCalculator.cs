namespace Yatzy.Categories.Straights
{
    internal class SmallStraightCalculator : ICategoryCalculator
    {
        public int Calculate(int[] roll)
        {
            int currentNumber = 1;

            for (int i = 0; i < 5; i++)
            {
                if (roll[i] != currentNumber++)
                    return 0;
            }

            return 15;
        }
    }
}