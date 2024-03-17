using System.Collections.Generic;

namespace WordCountModels
{
    /// <summary>
    /// Represents the response object for word count operation.
    /// </summary>
    public record WordCountResponse
    {
        /// <summary>
        /// Get or init the input value from which the word count operation is carried out.
        /// </summary>
        public string Input { get; init; } = default!;

        /// <summary>
        /// Get or inits the output model for word count operation.
        /// </summary>
        public List<OutPutModel> Output { get; init; } = new();
    }

    /// <summary>
    /// Represents the output model for word count operation.
    /// </summary>
    public record OutPutModel
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