using BowlingGame;
using FluentAssertions;

namespace BowlingGameTests
{
    public class BowlingGameCalculatorTest
    {
        private BowlingGameCalculator calculator = new BowlingGameCalculator();

        [Fact]
        public void Score_Should_Be_Zero_When_No_Pins_Were_Hitted()
        {
            string sequenceOfRolls = "--------------------";

            int score = calculator.Calculate(sequenceOfRolls);

            score.Should().Be(0);
        }

        [Fact]
        public void Score_Should_Be_The_Sum_Of_Hitted_Pins_When_All_Pins_Were_Hitted_And_There_Is_No_Strike_And_Spare()
        {
            string sequenceOfRolls = "11111111111111111111";

            int score = calculator.Calculate(sequenceOfRolls);

            score.Should().Be(20);
        }

        [Fact]
        public void Score_Should_Be_The_Sum_Of_Hitted_Pins_When_Just_Pins_Of_One_Frame_In_Each_Turn_Were_Hitted()
        {
            string sequenceOfRolls = "9-9-9-9-9-9-9-9-9-9-";

            int score = calculator.Calculate(sequenceOfRolls);

            score.Should().Be(90);
        }

        [Fact]
        public void Should_Be_Possible_To_Calculate_A_Score_When_There_Is_A_Spare_But_The_Next_Turn_After_Spare_Failed()
        {
            string sequenceOfRolls = "5/-11111111111111111";

            int score = calculator.Calculate(sequenceOfRolls);

            score.Should().Be(27);
        }

        [Fact]
        public void Should_Be_Possible_To_Calculate_A_Score_When_There_Is_A_Spare_And_The_Next_Turn_After_Spare_Succeed()
        {
            string sequenceOfRolls = "5/111111111111111111";

            int score = calculator.Calculate(sequenceOfRolls);

            score.Should().Be(29);
        }

        [Fact]
        public void Score_Should_Be_150_For_A_Game_With_Spare_In_Every_Round()
        {
            string sequenceOfRolls = "5/5/5/5/5/5/5/5/5/5/5";
            
            int score = calculator.Calculate(sequenceOfRolls);

            score.Should().Be(150);
        }

        [Fact]
        public void Should_Be_Possible_To_Calculate_When_There_Is_A_Strike_But_The_Next_Two_Turns_After_Strike_Failed()
        {
            string sequenceOfRolls = "X--1111111111111111";

            int score = calculator.Calculate(sequenceOfRolls);

            score.Should().Be(26);
        }

        [Fact]
        public void Should_Be_Possible_To_Calculate_When_There_Is_A_Strike_But_The_Next_Turn_After_Strike_Failed()
        {
            string sequenceOfRolls = "X-11111111111111111";

            int score = calculator.Calculate(sequenceOfRolls);

            score.Should().Be(28);
        }

        [Fact]
        public void Should_Be_Possible_To_Calculate_When_There_Is_A_Perfect_Game()
        {
            string sequenceOfRolls = "XXXXXXXXXXXX";

            int score = calculator.Calculate(sequenceOfRolls);

            score.Should().Be(300);
        }
        
    }

    public class FrameTest
    {
        [Fact]
        public void Should_Be_Possible_To_Create_Frame_Without_Score()
        {
            char score1 = '-';
            char score2 = '-';

            var frame = new Frame(false, score1, score2);

            frame.Score.Should().Be(0);
        }

        [Fact]
        public void Should_Be_Possible_To_Create_Frame_With_Score()
        {
            char score1 = '1';
            char score2 = '1';

            var frame = new Frame(false, score1, score2);

            frame.Score.Should().Be(2);
        }

        [Fact]
        public void Should_Be_Possible_To_Create_Frame_With_Spare()
        {
            char score1 = '5';
            char score2 = '/';

            var frame = new Frame(false, score1, score2);

            frame.Score.Should().Be(10);
            frame.IsSpare.Should().BeTrue();
            frame.IsStrike.Should().BeFalse();
        }

        [Fact]
        public void Should_Be_Possible_To_Create_Frame_With_Strike()
        {
            char score1 = 'X';
            char score2 = '2';

            var frame = new Frame(false, score1, score2);

            frame.Score.Should().Be(10);
            frame.IsSpare.Should().BeFalse();
            frame.IsStrike.Should().BeTrue();
        }
    }

    public class FrameFactoryTest
    {
        [Fact]
        public void Should_Be_Possible_To_Create_Frames()
        {
            string turns = "11111111111111111111";

            LinkedList<Frame> frames = FrameFactory.CreateFrames(turns);

            frames.Should().HaveCount(10);
            frames.All(f => f.Score == 2).Should().BeTrue();
        }

        [Fact]
        public void Should_Be_Possible_To_Create_Frames_Full_Of_Spares()
        {
            string turns = "5/5/5/5/5/5/5/5/5/5/5";

            LinkedList<Frame> frames = FrameFactory.CreateFrames(turns);

            frames.Should().HaveCount(11);
            frames.Where(f => f != frames.Last.Value).All(f => f.Score == 10).Should().BeTrue();
            frames.Where(f => f != frames.Last.Value).All(f => f.IsSpare).Should().BeTrue();
            frames.Where(f => f != frames.Last.Value).All(f => f.IsStrike).Should().BeFalse();
            frames.Last.Value.Score.Should().Be(5);
        }

        [Fact]
        public void Should_Be_Possible_To_Create_Frames_Full_Of_Strikes()
        {
            string turns = "XXXXXXXXXXXX";

            LinkedList<Frame> frames = FrameFactory.CreateFrames(turns);

            frames.Should().HaveCount(11);
            frames.Where(f => f != frames.Last.Value).All(f => f.Score == 10).Should().BeTrue();
            frames.Where(f => f != frames.Last.Value).All(f => f.IsSpare).Should().BeFalse();
            frames.Where(f => f != frames.Last.Value).All(f => f.IsStrike).Should().BeTrue();
            frames.Last.Value.Score.Should().Be(20);
        }
    }
}