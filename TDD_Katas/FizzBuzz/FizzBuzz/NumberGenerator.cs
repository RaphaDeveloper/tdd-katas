namespace FizzBuzz
{
    public class NumberGenerator
    {
        public string Generate(int number)
        {
            return CreateConverter(number).Convert(number);
        }

        private IConverter CreateConverter(int number)
        {
            if (number % 3 == 0 || number % 5 == 0 || number % 7 == 0)
            {
                ConverterComposite composite = new ConverterComposite();

                if (number % 3 == 0)
                    composite.AddConverter(new FizzConverter());

                if (number % 5 == 0)
                    composite.AddConverter(new BuzzConverter());

                if (number % 7 == 0)
                    composite.AddConverter(new WhizzConverter());

                return composite;
            }

            return new NumberConverter();
        }
    }

    public interface IConverter
    {
        string Convert(int number);
    }

    public class ConverterComposite : IConverter
    {
        private readonly List<IConverter> converters = new List<IConverter>();

        public string Convert(int number)
        {
            string result = "";

            foreach (IConverter converter in converters)
                result += converter.Convert(number);

            return result;
        }

        internal void AddConverter(IConverter converter)
        {
            converters.Add(converter);
        }
    }

    public class FizzConverter : IConverter
    {
        public string Convert(int number)
        {
            return "Fizz";
        }
    }

    public class BuzzConverter : IConverter
    {
        public string Convert(int number)
        {
            return "Buzz";
        }
    }

    public class WhizzConverter : IConverter
    {
        public string Convert(int number)
        {
            return "Whizz";
        }
    }

    public class NumberConverter : IConverter
    {
        public string Convert(int number)
        {
            return number.ToString();
        }
    }
}