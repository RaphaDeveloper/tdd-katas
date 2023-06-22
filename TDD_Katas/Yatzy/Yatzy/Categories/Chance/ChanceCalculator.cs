namespace Yatzy.Categories.Chance
{
    internal class ChanceCalculator : ICategoryCalculator
    {
        public int Calculate(int[] roll)
        {
            return roll.Sum();
        }
    }
}