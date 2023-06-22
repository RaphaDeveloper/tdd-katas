namespace Yatzy.Categories.NumberOfAKind
{
    internal class FourOfAKindCalculator : ICategoryCalculator
    {
        public int Calculate(int[] roll)
        {
            var score = new NumberOfAKindScore(roll, 4);

            return score.Value;
        }
    }
}