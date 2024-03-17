# Word Count

## Applications

+ WordCountEntryPoint (Console Application)
+ WordCount.Api (Web Api)

### WordCounEntryPoint
This application is to allow a user to run the application via a console application. This simply allows a user to update the Progam.cs file to directly return the response from the Logic application(***WordCountLogic***)

### WordCount.Api
This web-api builds upon the EntryPoint application providing a better ui for the user to carry out word count operations. Here we can now both provide a .txt file to be processed as well as simply providing a string via the GET endpoint.

## Motivation
The approach for achieving the desired output was fuelled by simplicity as we can see from WordProcessor.cs. The first step was simply to produce a list of matches based on our Regex pattern, from this we would then easily group by the specific word, to produce a count. Additionally a weight was generated, this was more of a personal thing when checking our output, it was nice to see how much each word made up of the entire word count. 

## Improvements

+ **Testing -** While the heart of the solution was tested (the processing of the data). In processing files as well as generating downloadable files a lot of issues can occur, the simplicity of the solution should help to reduce any unexpected behaviour, for example limiting the files to only .txt. However, providing better testing would help allow for more certainty in the solution as a whole. Therefore if iterated further, this would be addressed.

+ **Re-usability -** Largely I am happy with the re-usability of the code, however, generally I would not like to process and have file download functionality within the same method (WordCount.Api Post function). I accepted for the sake of the exercise that keeping it simple. In future iterations helpers should be introduced so that this functionality could be re-used in other areas of the system. as well making it easier to unit test. 
