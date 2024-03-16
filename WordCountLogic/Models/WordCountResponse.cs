namespace WordCountLogic.Models;

/// <summary>
/// Represents the response object for word count operation.
/// </summary>
public record WordCountResponse
{
    public string Input { get; init; } = default!;

    public List<OutPutModel> Output { get; init; } = new();
}

/// <summary>
/// Represents the output model for word count operation.
/// </summary>
public record OutPutModel
{
    /// <summary>
    /// Represents a word processing utility.
    /// </summary>
    public string Word { get; init; } = default!;
    public int Count { get; init; }
    public string Weight { get; init; } = "0.00";
}