namespace Yatzy.Categories.Numbers
{
    internal class FivesCalculator : ICategoryCalculator
    {
        public int Calculate(int[] roll)
        {
            var score = new NumbersScore(roll, 5);

            return score.Value;
        }
    }
}