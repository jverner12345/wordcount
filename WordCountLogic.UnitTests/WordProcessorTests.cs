using FluentAssertions;
using Xunit;

namespace WordCountLogic.UnitTests;

public class WordProcessorTests
{
    private readonly WordProcessor _sut;

    public WordProcessorTests()
    {
        _sut = new WordProcessor();
    }
    
    [Fact]
    public void GenerateCount_ShouldThrowException_WhenInputIsNull()
    {
        // Arrange
        string? testInput = null;
        
        // Act
        Action act = () => _sut.GenerateCount(testInput!, false);
        
        // Assert
        act.Should().Throw<ArgumentNullException>();
    }

    [Theory]
    [InlineData("My name is Jamie I am a good developer. Hire me! MY", true, 11)]
    [InlineData("My name is Jamie I am a good developer. Hire me! MY", false, 12)]
    public void GenerateCount_ShouldProcessInputCorrectly(string input, bool ignoreCasing, int expectedCount)
    {
        // Act
        var result = _sut.GenerateCount(input, ignoreCasing);

        // Assert
        result.Should().NotBeNull();
        result.Input.Should().Be(input);
        result.Output.Count.Should().Be(expectedCount);
    }
}
