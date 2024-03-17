// See https://aka.ms/new-console-template for more information
using WordCountLogic;

var wordProcessor = new WordProcessor();

var ignoreCase = true;
var inputString = "This is a test operation for testing the Test.";

var response = wordProcessor.GenerateCount(inputString, ignoreCase);

Console.WriteLine($"Input: {response.Input}");
response.Output.ForEach(item =>
{
    Console.WriteLine($"Word: {item.Word}");
    Console.WriteLine($"Count: {item.Count}");
    Console.WriteLine($"Weight: {item.Weight}%");
    Console.WriteLine();
});