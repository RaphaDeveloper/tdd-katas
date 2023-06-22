using Yatzy.Categories.Chance;
using Yatzy.Categories.FullHouse;
using Yatzy.Categories.NumberOfAKind;
using Yatzy.Categories.Numbers;
using Yatzy.Categories.Pairs;
using Yatzy.Categories.Straights;
using Yatzy.Categories.Yatzy;

namespace Yatzy.Categories
{
    internal static class CategoryCalculatorFactory
    {
        internal static ICategoryCalculator Create(Category category)
        {
            switch (category)
            {
                case Category.Chance:
                    return new ChanceCalculator();
                case Category.Yatzy:
                    return new YatzyCalculator();
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
                case Category.Pair:
                    return new PairCalculator();
                case Category.TwoPairs:
                    return new TwoPairsCalculator();
                case Category.ThreeOfAKind:
                    return new ThreeOfAKindCalculator();
                case Category.FourOfAKind:
                    return new FourOfAKindCalculator();
                case Category.SmallStraight:
                    return new SmallStraightCalculator();
                case Category.LargeStraight:
                    return new LargeStraightCalculator();
                case Category.FullHouse:
                    return new FullHouseCalculator();
                default:
                    return null;
            }
        }
    }
}
