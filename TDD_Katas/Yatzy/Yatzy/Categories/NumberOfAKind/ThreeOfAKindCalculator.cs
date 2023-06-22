namespace Yatzy.Categories.NumberOfAKind
{
    internal class ThreeOfAKindCalculator : ICategoryCalculator
    {
        public int Calculate(int[] roll)
        {
            var score = new NumberOfAKindScore(roll, 3);

            return score.Value;
        }
    }
}