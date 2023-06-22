namespace Yatzy.Categories.Numbers
{
    internal class SixesCalculator : ICategoryCalculator
    {
        public int Calculate(int[] roll)
        {
            var score = new NumbersScore(roll, 6);

            return score.Value;
        }
    }
}