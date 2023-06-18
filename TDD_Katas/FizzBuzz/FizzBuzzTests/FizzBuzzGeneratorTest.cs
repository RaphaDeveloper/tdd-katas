using FizzBuzz;
using FluentAssertions;

namespace FizzBuzzTests
{
    public class NumberGeneratorTest
    {
        [Fact]
        public void Number_Generator_Should_Generate_The_Given_Number_When_Its_Not_Divisible_By_3_And_5()
        {
            NumberGenerator numberGenerator = new NumberGenerator();

            string one = numberGenerator.Generate(1);

            one.Should().Be("1");
        }

        [Fact]
        public void Number_Generator_Should_Generate_Fizz_When_Number_Is_Divisible_By_3()
        {
            NumberGenerator numberGenerator = new NumberGenerator();

            string three = numberGenerator.Generate(3);

            three.Should().Be("Fizz");
        }

        [Fact]
        public void Number_Generator_Should_Generate_Buzz_When_Number_Is_Divisible_By_5()
        {
            NumberGenerator numberGenerator = new NumberGenerator();

            string five = numberGenerator.Generate(5);

            five.Should().Be("Buzz");
        }

        [Fact]
        public void Number_Generator_Should_Generate_FizzBuzz_When_Number_Is_Divisible_By_3_And_5()
        {
            NumberGenerator numberGenerator = new NumberGenerator();

            string fifteen = numberGenerator.Generate(15);

            fifteen.Should().Be("FizzBuzz");
        }

        [Fact]
        public void Number_Generator_Should_Generate_Whizz_When_Number_Is_Divisible_By_7()
        {
            NumberGenerator numberGenerator = new NumberGenerator();

            string seven = numberGenerator.Generate(7);

            seven.Should().Be("Whizz");
        }

        [Fact]
        public void Number_Generator_Should_Generate_FizzBuzzWhizz_When_Number_Is_Divisible_By_3_And_5()
        {
            NumberGenerator numberGenerator = new NumberGenerator();

            string oneHundredFive = numberGenerator.Generate(105);

            oneHundredFive.Should().Be("FizzBuzzWhizz");
        }
    }
}