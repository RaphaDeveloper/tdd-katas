namespace Yatzy.Categories.Numbers
{
    internal class OnesCalculator : ICategoryCalculator
    {
        public int Calculate(int[] roll)
        {
            var score = new NumbersScore(roll, 1);

            return score.Value;
        }
    }
}