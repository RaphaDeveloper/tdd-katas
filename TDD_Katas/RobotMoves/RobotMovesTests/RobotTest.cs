using FluentAssertions;
using RobotMoves;

namespace RobotMovesTests
{
    public class RobotTest
    {
        [Fact]
        public void Should_Not_Be_On_Start_Position_When_There_Is_A_Command_To_Right()
        {
            Robot robot = new Robot();
            
            robot.Move("R");

            robot.IsOnStartPosition.Should().BeFalse();
        }

        [Fact]
        public void Should_Be_On_Start_Position_When_There_Is_A_Command_To_Right_And_To_Left()
        {
            Robot robot = new Robot();

            robot.Move("RL");

            robot.IsOnStartPosition.Should().BeTrue();
        }

        [Fact]
        public void Should_Be_On_Start_Position_When_There_Is_A_Command_To_Up_And_To_Down()
        {
            Robot robot = new Robot();

            robot.Move("UD");

            robot.IsOnStartPosition.Should().BeTrue();
        }

        [Fact]
        public void Should_Be_On_Start_Position_When_There_Is_A_Command_To_Up_And_To_Down_And_To_Right_And_Left()
        {
            Robot robot = new Robot();

            robot.Move("UDRL");

            robot.IsOnStartPosition.Should().BeTrue();
        }

        [Fact]
        public void Should_Be_On_Start_Position_When_The_Amount_Of_Moves_To_Up_Is_Equal_The_Amount_Of_Moves_To_Down()
        {
            Robot robot = new Robot();

            robot.Move("UUUDDD");

            robot.IsOnStartPosition.Should().BeTrue();
        }

        [Fact]
        public void Should_Be_On_Start_Position_When_The_Amount_Of_Moves_To_Right_Is_Equal_The_Amount_Of_Moves_To_Left()
        {
            Robot robot = new Robot();

            robot.Move("RRRLLL");

            robot.IsOnStartPosition.Should().BeTrue();
        }
    }
}