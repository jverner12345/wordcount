using System.Text.RegularExpressions;
using Ardalis.GuardClauses;
using WordCountLogic.Models;

namespace WordCountLogic;

/// <summary>
/// Represents a word processor that generates word count and weight based on the input.
/// </summary>
public class WordProcessor
{
    /// <summary>
    /// Generates word count and weight based on the input.
    /// </summary>
    /// <param name="input">The input string.</param>
    /// <param name="ignoreCasing">Determines whether to ignore the casing of words when counting.</param>
    /// <returns>The WordCountResponse object containing the input, output word count, and weight. <see cref="WordCountResponse"/></returns>
    public WordCountResponse GenerateCount(string input, bool ignoreCasing)
    {
        // Ardalis is a nuget package that allows for an application to fail fast. Should be used to check inputs early. Will throw exception if criteria met. 
        Guard.Against.NullOrWhiteSpace(input, message: $"{nameof(input)} cannot be null or whitespace, please provide a suitable input.");
        
        var regexPattern = @"\b\w+\b";
        var count = Regex.Matches(input, regexPattern);
        
        var result = count.GroupBy(x => ignoreCasing ? x.Value.ToUpper() : x.Value)
            .Select(x => new OutPutModel
            {
                Word = x.First().Value,
                Count = x.Count(),
                Weight = GenerateWeight(count.Count, x.Count())
            });

        return new WordCountResponse
        {
            Input = input,
            Output = result.ToList()
        };
    }

    private string GenerateWeight(int count, int occurrence)
    {
        return ((decimal)occurrence / count * 100m).ToString("F");
    }
}