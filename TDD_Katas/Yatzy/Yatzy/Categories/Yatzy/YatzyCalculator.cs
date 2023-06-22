namespace Yatzy.Categories.Yatzy
{
    internal class YatzyCalculator : ICategoryCalculator
    {
        public int Calculate(int[] roll)
        {
            if (AllDicesAreTheSame(roll))
                return 50;

            return 0;
        }

        private static bool AllDicesAreTheSame(int[] roll)
        {
            return roll.Distinct().Count() == 1;
        }
    }
}