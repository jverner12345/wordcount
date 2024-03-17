namespace WordCount.Api.Models
{
    /// <summary>
    /// Represents the output model for word count operation.
    /// </summary>
    public record WordCountResponse
    {
        /// <summary>
        /// Get or inits specific word within input.
        /// </summary>
        public string Word { get; init; } = default!;

        /// <summary>
        /// Get or inits the count of specific word within input.
        /// </summary>
        public int Count { get; init; }

        /// <summary>
        /// Get or inits the weight of a specific word within the input.
        /// </summary>
        public string Weight { get; init; } = "0.00";
    }
}