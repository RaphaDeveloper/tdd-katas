namespace Yatzy.Categories.Numbers
{
    internal class FoursCalculator : ICategoryCalculator
    {
        public int Calculate(int[] roll)
        {
            var score = new NumbersScore(roll, 4);

            return score.Value;
        }
    }
}