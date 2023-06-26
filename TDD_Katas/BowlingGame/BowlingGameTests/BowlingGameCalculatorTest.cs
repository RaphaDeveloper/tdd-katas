using BowlingGame;
using FluentAssertions;

namespace BowlingGameTests
{
    public class BowlingGameCalculatorTest
    {
        BowlingGameCalculator bowlingGame = new BowlingGameCalculator();

        [Fact]
        public void ZeroPinsHittedGame()
        {
            string rounds = "--------------------";

            int score = bowlingGame.CalculateScore(rounds);

            score.Should().Be(0);
        }

        [Fact]
        public void AllPinsHittedGame()
        {
            string rounds = "11111111111111111111";

            int score = bowlingGame.CalculateScore(rounds);

            score.Should().Be(20);
        }

        [Fact]
        public void SpareWithNextRoundMissed()
        {
            string rounds = "5/-11111111111111111";

            int score = bowlingGame.CalculateScore(rounds);

            score.Should().Be(27);
        }

        [Fact]
        public void SpareWithNextRoundHitted()
        {
            string rounds = "5/111111111111111111";

            int score = bowlingGame.CalculateScore(rounds);

            score.Should().Be(29);
        }

        [Fact]
        public void SpareInAllFrames()
        {
            string rounds = "9/9/9/9/9/9/9/9/9/9/9";

            int score = bowlingGame.CalculateScore(rounds);

            score.Should().Be(190);
        }

        [Fact]
        public void StrikeWithNextTwoRoundsMissed()
        {
            string rounds = "X--1111111111111111";

            int score = bowlingGame.CalculateScore(rounds);

            score.Should().Be(26);
        }

        [Fact]
        public void StrikeWithNextTwoRoundsHitted()
        {
            string rounds = "X111111111111111111";

            int score = bowlingGame.CalculateScore(rounds);

            score.Should().Be(30);
        }

        [Fact]
        public void StrikeInAllFrames()
        {
            string rounds = "XXXXXXXXXXXX";

            int score = bowlingGame.CalculateScore(rounds);

            score.Should().Be(300);
        }

    }
}