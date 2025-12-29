
namespace Calculator
{
    class Program
    {
        static decimal lastResult;
        static bool hasLastResult = false;

        static void Main(string[] args)
        {
            Menu();
        }

        static void Menu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("+-+-+- Welcome to Calculator -+-+-+");

                if (hasLastResult)
                    Console.WriteLine($"Last result: {lastResult}");

                Console.WriteLine("Choose an operation [+ - x /] or E to exit:");
                string option = Console.ReadLine()!.ToUpper();

                if (option == "E")
                    break;

                switch (option)
                {
                    case "+":
                        Calculate((a, b) => a + b, "+");
                        break;
                    case "-":
                        Calculate((a, b) => a - b, "-");
                        break;
                    case "X":
                        Calculate((a, b) => a * b, "x");
                        break;
                    case "/":
                        Calculate((a, b) => a / b, "/");
                        break;
                    default:
                        Console.WriteLine("Invalid operation!");
                        Pause();
                        break;
                }
            }
        }

        static void Calculate(Func<decimal, decimal, decimal> operation, string symbol)
        {
            Console.Clear();

            decimal value1;

            if (hasLastResult && AskUseLastResult())
            {
                value1 = lastResult;
                Console.WriteLine($"Using last result as first value: {value1}");
            }
            else
            {
                value1 = ReadDecimal("First value:");
            }

            decimal value2 = ReadDecimal("Second value:");

            if (symbol == "/" && value2 == 0)
            {
                Console.WriteLine("Error: Division by zero is not allowed.");
                Pause();
                return;
            }

            lastResult = operation(value1, value2);
            hasLastResult = true;

            Console.WriteLine($"\nResult: {value1} {symbol} {value2} = {lastResult}");
            Pause();
        }

        static bool AskUseLastResult()
        {
            Console.WriteLine("Use last result as first value? (Y/N)");
            return Console.ReadLine()!.ToUpper() == "Y";
        }

        static decimal ReadDecimal(string message)
        {
            Console.WriteLine(message);

            decimal value;

            while (!decimal.TryParse(Console.ReadLine(), out value))
            {
                Console.WriteLine("Invalid value, try again:");
            }

            return value;
        }

        static void Pause()
        {
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
    }
}