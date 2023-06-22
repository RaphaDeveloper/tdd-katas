namespace Yatzy.Categories.Numbers
{
    internal class TwosCalculator : ICategoryCalculator
    {
        public int Calculate(int[] roll)
        {
            var score = new NumbersScore(roll, 2);

            return score.Value;
        }
    }
}