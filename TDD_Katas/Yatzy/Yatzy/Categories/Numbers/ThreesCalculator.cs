namespace Yatzy.Categories.Numbers
{
    internal class ThreesCalculator : ICategoryCalculator
    {
        public int Calculate(int[] roll)
        {
            var score = new NumbersScore(roll, 3);

            return score.Value;
        }
    }
}