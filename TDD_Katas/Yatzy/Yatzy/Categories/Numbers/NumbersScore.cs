namespace Yatzy.Categories.Numbers
{
    internal class NumbersScore
    {
        public NumbersScore(int[] roll, int number)
        {
            Value = roll.Where(d => d == number).Sum();
        }

        public int Value { get; }
    }
}