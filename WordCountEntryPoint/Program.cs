using System;
using WordCountLogic;

namespace WordCountEntryPoint
{
    internal class Program
    {
        static void Main(string[] _)
        {
            var wordProcessor = new WordProcessor();
            const bool ignoreCase = true;
            const string inputString = "This is a test operation for testing the Test.";

            var response = wordProcessor.GenerateCount(inputString, ignoreCase);

            Console.WriteLine($"Input: {response.Input}");
            response.Output.ForEach(item =>
            {
                Console.WriteLine($"Word: {item.Word}");
                Console.WriteLine($"Count: {item.Count}");
                Console.WriteLine($"Weight: {item.Weight}%");
                Console.WriteLine();
            });
        }
    }
}