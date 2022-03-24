using Calculator;

namespace Application
{
    class Program
    {
        static int Main()
        {
            try
            {
                var input = Console.ReadLine();
                if (string.IsNullOrEmpty(input))
                {
                    throw new ApplicationException("Incorrect input data");
                }

                var result = new Calcualtor().Calculate(input);
                Console.WriteLine(result);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return 1;
            }
            return 0;
        }
    }
}