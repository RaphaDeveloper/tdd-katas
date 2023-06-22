using FluentAssertions;
using Yatzy;
using Yatzy.Categories;

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
            Category category = Category.Yatzy;
            YatzyScoreCalculator scoreCalculator = new YatzyScoreCalculator();

            int score = scoreCalculator.Calculate(roll, category);

            score.Should().Be(50);
        }

        [Fact]
        public void The_Score_For_Yagzy_Category_Should_Be_0_When_All_Dice_Are_Not_Equal()
        {
            int[] roll = new int[] { 1, 1, 1, 1, 6 };
            Category category = Category.Yatzy;
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

        [Fact]
        public void The_Score_For_Pair_Should_Be_0_If_There_Is_No_Pair()
        {
            int[] roll = new int[] { 1, 2, 3, 4, 5 };
            Category category = Category.Pair;
            YatzyScoreCalculator calculator = new YatzyScoreCalculator();

            int score = calculator.Calculate(roll, category);

            score.Should().Be(0);
        }

        [Fact]
        public void The_Score_For_Pair_Should_Be_The_Sum_Of_Pair_If_There_Is_A_Pair()
        {
            int[] roll = new int[] { 1, 3, 3, 4, 5 };
            Category category = Category.Pair;
            YatzyScoreCalculator calculator = new YatzyScoreCalculator();

            int score = calculator.Calculate(roll, category);

            score.Should().Be(6);
        }

        [Fact]
        public void The_Score_For_Pair_Should_Be_The_Sum_Of_Highest_Pair_If_There_Is_More_Than_One_Pair()
        {
            int[] roll = new int[] { 1, 3, 3, 5, 5 };
            Category category = Category.Pair;
            YatzyScoreCalculator calculator = new YatzyScoreCalculator();

            int score = calculator.Calculate(roll, category);

            score.Should().Be(10);
        }

        [Fact]
        public void The_Score_For_Two_Pairs_Should_Be_0_If_There_Is_No_Pair()
        {
            int[] roll = new int[] { 1, 2, 3, 4, 5 };
            Category category = Category.TwoPairs;
            YatzyScoreCalculator calculator = new YatzyScoreCalculator();

            int score = calculator.Calculate(roll, category);

            score.Should().Be(0);
        }

        [Fact]
        public void The_Score_For_Two_Pairs_Should_Be_0_If_There_Is_Just_One_Pair()
        {
            int[] roll = new int[] { 1, 1, 2, 3, 4 };
            Category category = Category.TwoPairs;
            YatzyScoreCalculator calculator = new YatzyScoreCalculator();

            int score = calculator.Calculate(roll, category);

            score.Should().Be(0);
        }

        [Fact]
        public void The_Score_For_Two_Pairs_Should_Be_The_Sum_Of_The_Two_Pairs()
        {
            int[] roll = new int[] { 1, 1, 2, 3, 3 };
            Category category = Category.TwoPairs;
            YatzyScoreCalculator calculator = new YatzyScoreCalculator();

            int score = calculator.Calculate(roll, category);

            score.Should().Be(8);
        }

        [Fact]
        public void The_Score_For_Three_Of_A_Kind_Should_Be_0_If_There_Is_No_Three_Dices_Of_The_Same_Kind()
        {
            int[] roll = new int[] { 1, 1, 3, 4, 5 };
            Category category = Category.ThreeOfAKind;
            YatzyScoreCalculator calculator = new YatzyScoreCalculator();

            int score = calculator.Calculate(roll, category);

            score.Should().Be(0);
        }

        [Fact]
        public void The_Score_For_Three_Of_A_Kind_Should_Be_The_Sum_Of_Them_If_There_Are_Three_Dices_Of_The_Same_Kind()
        {
            int[] roll = new int[] { 1, 1, 1, 4, 5 };
            Category category = Category.ThreeOfAKind;
            YatzyScoreCalculator calculator = new YatzyScoreCalculator();

            int score = calculator.Calculate(roll, category);

            score.Should().Be(3);
        }

        [Fact]
        public void The_Score_For_Four_Of_A_Kind_Should_Be_0_If_There_Is_No_Four_Dices_Of_The_Same_Kind()
        {
            int[] roll = new int[] { 1, 1, 1, 4, 5 };
            Category category = Category.FourOfAKind;
            YatzyScoreCalculator calculator = new YatzyScoreCalculator();

            int score = calculator.Calculate(roll, category);

            score.Should().Be(0);
        }

        [Fact]
        public void The_Score_For_Four_Of_A_Kind_Should_Be_The_Sum_Of_Them_If_There_Are_Four_Dices_Of_The_Same_Kind()
        {
            int[] roll = new int[] { 1, 1, 1, 1, 5 };
            Category category = Category.FourOfAKind;
            YatzyScoreCalculator calculator = new YatzyScoreCalculator();

            int score = calculator.Calculate(roll, category);

            score.Should().Be(4);
        }

        [Fact]
        public void The_Score_For_Small_Straight_Should_Be_0_If_The_First_Five_Numbers_Are_Not_From_1_To_5_In_Sequence()
        {
            int[] roll = new int[] { 1, 1, 1, 4, 5 };
            Category category = Category.SmallStraight;
            YatzyScoreCalculator calculator = new YatzyScoreCalculator();

            int score = calculator.Calculate(roll, category);

            score.Should().Be(0);
        }

        [Fact]
        public void The_Score_For_Small_Straight_Should_Be_15_Wich_Is_The_Sum_Of_Of_The_First_Five_Numbers_If_They_Are_From_1_To_5_In_Sequence()
        {
            int[] roll = new int[] { 1, 2, 3, 4, 5, 5 };
            Category category = Category.SmallStraight;
            YatzyScoreCalculator calculator = new YatzyScoreCalculator();

            int score = calculator.Calculate(roll, category);

            score.Should().Be(15);
        }

        [Fact]
        public void The_Score_For_Large_Straight_Should_Be_0_If_The_Last_Five_Numbers_Are_Not_From_2_To_6_In_Sequence()
        {
            int[] roll = new int[] { 1, 1, 1, 4, 5 };
            Category category = Category.LargeStraight;
            YatzyScoreCalculator calculator = new YatzyScoreCalculator();

            int score = calculator.Calculate(roll, category);

            score.Should().Be(0);
        }

        [Fact]
        public void The_Score_For_Large_Straight_Should_Be_20_Wich_Is_The_Sum_Of_Of_The_Last_Five_Numbers_If_They_Are_From_1_To_5_In_Sequence()
        {
            int[] roll = new int[] { 2, 2, 3, 4, 5, 6 };
            Category category = Category.LargeStraight;
            YatzyScoreCalculator calculator = new YatzyScoreCalculator();

            int score = calculator.Calculate(roll, category);

            score.Should().Be(20);
        }

        [Fact]
        public void The_Score_For_Full_House_Should_Be_0_When_There_Is_No_Two_Of_A_Kind_And_Three_Of_A_Kind()
        {
            int[] roll = new int[] { 1, 1, 1, 2, 3 };
            Category category = Category.FullHouse;
            YatzyScoreCalculator calculator = new YatzyScoreCalculator();

            int score = calculator.Calculate(roll, category);

            score.Should().Be(0);
        }

        [Fact]
        public void The_Score_For_Full_House_Shoud_Be_The_Sum_Of_All_Roll_When_There_Is_A_Two_Of_A_Kind_And_Three_Of_A_Kind()
        {
            int[] roll = new int[] { 1, 1, 2, 2, 2 };
            Category category = Category.FullHouse;
            YatzyScoreCalculator calculator = new YatzyScoreCalculator();

            int score = calculator.Calculate(roll, category);

            score.Should().Be(8);
        }
    }
}