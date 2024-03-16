// See https://aka.ms/new-console-template for more information
using WordCountLogic;

var wordProcessor = new WordProcessor();
var response = wordProcessor.GenerateCount(" ", true);

Console.WriteLine($"Input: {response.Input}");
response.Output.ForEach(item =>
{
    Console.WriteLine($"Word: {item.Word}");
    Console.WriteLine($"Count: {item.Count}");
    Console.WriteLine($"Weight: {item.Weight}");
    Console.WriteLine();
});