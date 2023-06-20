namespace Yatzy
{
    public enum Category
    {
        Chance,
        Yagzy,
        Ones,
        Twos,
        Threes,
        Fours,
        Fives,
        Sixes
    }

    public class YatzyScoreCalculator
    {
        public int Calculate(int[] roll, Category category)
        {
            var categoryCalculator = CreateCategoryCalculator(category);

            return categoryCalculator.Calculate(roll);
        }

        private ICategoryCalculator CreateCategoryCalculator(Category category)
        {
            switch (category)
            {
                case Category.Chance:
                    return new ChanceCalculator();
                case Category.Yagzy:
                    return new YagzyCalculator();
                case Category.Ones:
                    return new OnesCalculator();
                case Category.Twos:
                    return new TwosCalculator();
                case Category.Threes:
                    return new ThreesCalculator();
                case Category.Fours:
                    return new FoursCalculator();
                case Category.Fives:
                    return new FivesCalculator();
                case Category.Sixes:
                    return new SixesCalculator();
                default:
                    return null;
            }
        }
    }

    internal class SixesCalculator : ICategoryCalculator
    {
        public int Calculate(int[] roll)
        {
            return roll.Where(d => d == 6).Sum();
        }
    }

    internal class FivesCalculator : ICategoryCalculator
    {
        public int Calculate(int[] roll)
        {
            return roll.Where(d => d == 5).Sum();
        }
    }

    internal class FoursCalculator : ICategoryCalculator
    {
        public int Calculate(int[] roll)
        {
            return roll.Where(d => d == 4).Sum();
        }
    }

    internal class ChanceCalculator : ICategoryCalculator
    {
        public int Calculate(int[] roll)
        {
            return 14;
        }
    }

    internal class ThreesCalculator : ICategoryCalculator
    {
        public int Calculate(int[] roll)
        {
            return roll.Where(d => d == 3).Sum();
        }
    }

    internal class TwosCalculator : ICategoryCalculator
    {
        public int Calculate(int[] roll)
        {
            return roll.Where(d => d == 2).Sum();
        }
    }

    internal class OnesCalculator : ICategoryCalculator
    {
        public int Calculate(int[] roll)
        {
            return roll.Where(d => d == 1).Sum();
        }
    }

    internal class YagzyCalculator : ICategoryCalculator
    {
        public int Calculate(int[] roll)
        {
            if (roll.Distinct().Count() == 1)
                return 50;

            return 0;
        }
    }

    internal interface ICategoryCalculator
    {
        int Calculate(int[] roll);
    }
}