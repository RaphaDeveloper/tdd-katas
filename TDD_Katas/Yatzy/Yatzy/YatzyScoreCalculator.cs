using Yatzy.Categories;

namespace Yatzy
{

    public class YatzyScoreCalculator
    {
        public int Calculate(int[] roll, Category category)
        {
            var categoryCalculator = CategoryCalculatorFactory.Create(category);

            return categoryCalculator.Calculate(roll);
        }
    }
}