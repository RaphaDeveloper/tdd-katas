namespace PrimeFactors
{
    public class PrimeFactors
    {
        public List<int> Generate(int number)
        {
            List<int> primes = new List<int>();

            int divisor = 2;
            while (number > 1)
            {
                if (number % divisor == 0)
                {
                    primes.Add(divisor);
                    number /= divisor;
                }
                else
                {
                    divisor++;
                }
            }

            return primes;
        }
    }
}