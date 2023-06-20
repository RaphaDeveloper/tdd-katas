using FluentAssertions;
using Yatzy;

namespace YatzyTests
{
    public class YatzyScoreCalculatorTest
    {
        [Fact]
        public void The_Score_For_Chance_Category_Should_Be_The_Sum_Of_All_Dice()
        {
            int[] roll = new int[] { 1, 1, 3, 3, 6 };
            Category category = Category.Chance;
            YatzyScoreCalculator scoreCalculator = new YatzyScoreCalculator();

            int score = scoreCalculator.Calculate(roll, category);

            score.Should().Be(14);
        }

        [Fact]
        public void The_Score_For_Yagzy_Category_Should_Be_50_When_All_Dice_Are_Equal()
        {
            int[] roll = new int[] { 1, 1, 1, 1, 1};
            Category category = Category.Yagzy;
            YatzyScoreCalculator scoreCalculator = new YatzyScoreCalculator();

            int score = scoreCalculator.Calculate(roll, category);

            score.Should().Be(50);
        }

        [Fact]
        public void The_Score_For_Yagzy_Category_Should_Be_0_When_All_Dice_Are_Not_Equal()
        {
            int[] roll = new int[] { 1, 1, 1, 1, 6 };
            Category category = Category.Yagzy;
            YatzyScoreCalculator scoreCalculator = new YatzyScoreCalculator();

            int score = scoreCalculator.Calculate(roll, category);

            score.Should().Be(0);
        }

        [Fact]
        public void The_Score_For_Ones_Category_Should_Be_0_When_There_Is_No_Dice_1()
        {
            int[] roll = new int[] { 3, 3, 3, 4, 5 };
            Category category = Category.Ones;
            YatzyScoreCalculator scoreCalculator = new YatzyScoreCalculator();

            int score = scoreCalculator.Calculate(roll, category);

            score.Should().Be(0);
        }

        [Fact]
        public void The_Score_For_Ones_Category_Should_Be_The_Sum_Of_Ones_When_There_Is_Dice_1()
        {
            int[] roll = new int[] { 1, 1, 3, 4, 5 };
            Category category = Category.Ones;
            YatzyScoreCalculator scoreCalculator = new YatzyScoreCalculator();

            int score = scoreCalculator.Calculate(roll, category);

            score.Should().Be(2);
        }

        [Fact]
        public void The_Score_For_Twos_Category_Should_Be_0_When_There_Is_No_Dice_2()
        {
            int[] roll = new int[] { 3, 3, 3, 4, 5 };
            Category category = Category.Twos;
            YatzyScoreCalculator scoreCalculator = new YatzyScoreCalculator();

            int score = scoreCalculator.Calculate(roll, category);

            score.Should().Be(0);
        }

        [Fact]
        public void The_Score_For_Twos_Category_Should_Be_The_Sum_Of_Twos_When_There_Is_Dice_2()
        {
            int[] roll = new int[] { 2, 2, 3, 4, 5 };
            Category category = Category.Twos;
            YatzyScoreCalculator scoreCalculator = new YatzyScoreCalculator();

            int score = scoreCalculator.Calculate(roll, category);

            score.Should().Be(4);
        }

        [Fact]
        public void The_Score_For_Threes_Category_Should_Be_0_When_There_Is_No_Dice_3()
        {
            int[] roll = new int[] { 2, 2, 2, 4, 5 };
            Category category = Category.Threes;
            YatzyScoreCalculator scoreCalculator = new YatzyScoreCalculator();

            int score = scoreCalculator.Calculate(roll, category);

            score.Should().Be(0);
        }

        [Fact]
        public void The_Score_For_Threes_Category_Should_Be_The_Sum_Of_Threes_When_There_Is_Dice_3()
        {
            int[] roll = new int[] { 2, 3, 3, 4, 5 };
            Category category = Category.Threes;
            YatzyScoreCalculator scoreCalculator = new YatzyScoreCalculator();

            int score = scoreCalculator.Calculate(roll, category);

            score.Should().Be(6);
        }

        [Fact]
        public void The_Score_For_Fours_Category_Should_Be_0_When_There_Is_No_Dice_4()
        {
            int[] roll = new int[] { 2, 2, 2, 1, 5 };
            Category category = Category.Fours;
            YatzyScoreCalculator scoreCalculator = new YatzyScoreCalculator();

            int score = scoreCalculator.Calculate(roll, category);

            score.Should().Be(0);
        }

        [Fact]
        public void The_Score_For_Fours_Category_Should_Be_The_Sum_Of_Fours_When_There_Is_Dice_4()
        {
            int[] roll = new int[] { 2, 3, 3, 4, 4 };
            Category category = Category.Fours;
            YatzyScoreCalculator scoreCalculator = new YatzyScoreCalculator();

            int score = scoreCalculator.Calculate(roll, category);

            score.Should().Be(8);
        }

        [Fact]
        public void The_Score_For_Fives_Category_Should_Be_0_When_There_Is_No_Dice_5()
        {
            int[] roll = new int[] { 2, 2, 2, 1, 4 };
            Category category = Category.Fives;
            YatzyScoreCalculator scoreCalculator = new YatzyScoreCalculator();

            int score = scoreCalculator.Calculate(roll, category);

            score.Should().Be(0);
        }

        [Fact]
        public void The_Score_For_Fives_Category_Should_Be_The_Sum_Of_Fives_When_There_Is_Dice_5()
        {
            int[] roll = new int[] { 2, 3, 3, 5, 5 };
            Category category = Category.Fives;
            YatzyScoreCalculator scoreCalculator = new YatzyScoreCalculator();

            int score = scoreCalculator.Calculate(roll, category);

            score.Should().Be(10);
        }

        [Fact]
        public void The_Score_For_Sixes_Category_Should_Be_0_When_There_Is_No_Dice_6()
        {
            int[] roll = new int[] { 2, 2, 2, 1, 4 };
            Category category = Category.Sixes;
            YatzyScoreCalculator scoreCalculator = new YatzyScoreCalculator();

            int score = scoreCalculator.Calculate(roll, category);

            score.Should().Be(0);
        }

        [Fact]
        public void The_Score_For_Sixes_Category_Should_Be_The_Sum_Of_Sixes_When_There_Is_Dice_6()
        {
            int[] roll = new int[] { 2, 3, 3, 6, 6 };
            Category category = Category.Sixes;
            YatzyScoreCalculator scoreCalculator = new YatzyScoreCalculator();

            int score = scoreCalculator.Calculate(roll, category);

            score.Should().Be(12);
        }
    }
}