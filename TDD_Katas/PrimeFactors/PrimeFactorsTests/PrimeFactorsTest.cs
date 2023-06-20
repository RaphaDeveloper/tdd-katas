using FluentAssertions;

namespace PrimeFactorsTests
{
    public class PrimeFactorsTest
    {
        [Fact]
        public void Should_Be_Possible_To_Factorize_The_Number_2()
        {
            PrimeFactors.PrimeFactors primeFactorsCalculator = new();

            List<int> primes = primeFactorsCalculator.Generate(2);

            primes.Should().HaveCount(1);
            primes.Should().Contain(2);
        }

        [Fact]
        public void Should_Be_Possible_To_Factorize_The_Number_3()
        {
            PrimeFactors.PrimeFactors primeFactorsCalculator = new();

            List<int> primes = primeFactorsCalculator.Generate(3);

            primes.Should().HaveCount(1);
            primes.Should().Contain(3);
        }

        [Fact]
        public void Should_Be_Possible_To_Factorize_The_Number_4()
        {
            PrimeFactors.PrimeFactors primeFactorsCalculator = new();

            List<int> primes = primeFactorsCalculator.Generate(4);

            primes.Should().HaveCount(2);
            primes.Should().HaveElementAt(0, 2);
            primes.Should().HaveElementAt(1, 2);
        }

        [Fact]
        public void Should_Be_Possible_To_Factorize_The_Number_6()
        {
            PrimeFactors.PrimeFactors primeFactorsCalculator = new();

            List<int> primes = primeFactorsCalculator.Generate(6);

            primes.Should().HaveCount(2);
            primes.Should().HaveElementAt(0, 2);
            primes.Should().HaveElementAt(1, 3);
        }

        [Fact]
        public void Should_Be_Possible_To_Factorize_The_Number_12()
        {
            PrimeFactors.PrimeFactors primeFactorsCalculator = new();

            List<int> primes = primeFactorsCalculator.Generate(12);

            primes.Should().HaveCount(3);
            primes.Should().HaveElementAt(0, 2);
            primes.Should().HaveElementAt(1, 2);
            primes.Should().HaveElementAt(2, 3);
        }
    }
}