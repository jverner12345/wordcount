using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Ardalis.GuardClauses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WordCount.Api.Extensions;
using WordCount.Api.Models;
using WordCountLogic;

namespace WordCount.Api.Controllers
{
    /// <summary>
    /// Controller for handling word count requests.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class WordCountController : ControllerBase
    {
        private readonly WordProcessor _processor;

        /// <summary>
        /// Controller for handling word count requests.
        /// </summary>
        public WordCountController(
            WordProcessor wordProcessor)
        {
            _processor = Guard.Against.Null(wordProcessor);
        }

        /// <summary>
        /// Creates a file containing a list of words from document with their occurrence and weights.
        /// </summary>>
        /// <returns>A file to be downloaded. It contains the result of the word count operation.</returns>
        /// <param name="uploadedFile">The file that will be processed. Only .TXT files are accepted.</param>
        /// <param name="ignoreCasing">A flag that will allow you to decide whether the words should be case sensitive.</param>
        /// <param name="responseFileName">The name of the newly created file.</param>
        /// <response code="200">Returns the newly created file containing the output of the operation.</response>
        /// <response code="400">If the file type is incorrect a BadRequest should be returned.</response>   
        [HttpPost("/process-file")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [Produces("application/json")]
        public ActionResult Post(IFormFile uploadedFile,  bool ignoreCasing, string responseFileName)
        {
            Guard.Against.NullOrWhiteSpace(responseFileName, message: "The output requires a valid file name.");
            
            if (uploadedFile.ContentType is not "text/plain")
            {
                return new BadRequestObjectResult("Only '.txt' files are accepted.");
            }

            var stream = uploadedFile.OpenReadStream();

            var textInput = UseStreamReaderReadToEnd();
            var response=  _processor.GenerateCount(textInput, ignoreCasing)
                .ToApiModel();

            var byteArray = JsonSerializer.SerializeToUtf8Bytes(response, new JsonSerializerOptions
            {
                WriteIndented = true
            });
            var  memStream = new MemoryStream(byteArray);
            
            return File(memStream, "text/plain", $"{responseFileName}.txt");

            string UseStreamReaderReadToEnd()
            {
                using var streamReader = new StreamReader(stream);
                return streamReader.ReadToEnd();
            }
        }
        
        /// <summary>
        /// Generates an occurrence of words within a sentence based on input string.
        /// </summary>
        /// <param name="input">The input string from which we will count occurrences.</param>
        /// <param name="ignoreCasing">A flag that will allow you to decide whether the words should be case sensitive.</param>
        /// <response code="200">Returns the newly created item</response>
        [HttpGet("/{input}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [Produces("application/json")]
        public ActionResult<List<WordCountResponse>> Get(string input, bool ignoreCasing)
        {
            try
            {
                return _processor.GenerateCount(input, ignoreCasing)
                    .ToApiModel();            
            }
            catch (Exception e)
            {
                return new BadRequestObjectResult(e.Message);
            }
        }
    }
}