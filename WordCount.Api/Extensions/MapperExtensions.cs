using System.Collections.Generic;
using System.Linq;
using Ardalis.GuardClauses;
using WordCount.Api.Models;

namespace WordCount.Api.Extensions
{
    /// <summary>
    /// Extension methods for mapping WordCountResponse objects.
    /// </summary>
    public static class MapperExtensions
    {
        /// <summary>
        /// Converts a <see cref="WordCountModels.WordCountResponse"/> object to a list of <see cref="WordCountResponse"/> objects.
        /// </summary>
        /// <param name="response">The WordCountModels.WordCountResponse object to convert.</param>
        /// <returns>A list of <see cref="WordCountResponse"/> objects.</returns>
        public static List<WordCountResponse> ToApiModel(this WordCountModels.WordCountResponse response)
        {
            Guard.Against.Null(response);

            return response.Output
                .ConvertAll(x => x.ToApiModel())
                .ToList();
        }

        /// <summary>
        /// Converts a <see cref="WordCountModels.WordCountResponse"/> object to a list of <see cref="WordCountResponse"/> objects.
        /// </summary>
        /// <param name="response">The WordCountModels.WordCountResponse object to convert.</param>
        /// <returns>A list of WordCountResponse objects.</returns>
        private static WordCountResponse ToApiModel(this WordCountModels.OutPutModel response)
        {
            Guard.Against.Null(response);

            return new WordCountResponse
            {
                Word = response.Word,
                Count = response.Count,
                Weight = $"{response.Weight}%"
            };
        }
    }
}