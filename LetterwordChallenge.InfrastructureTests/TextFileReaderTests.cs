using FluentAssertions;
using LetterwordChallenge.Infrastructure;
using NUnit.Framework;
using NUnit.Framework.Internal;
using System.IO;

namespace LetterwordChallenge.InfrastructureTests;

[TestFixture]
public class TextFileReaderTests
{
    private const string filePath = "./testFile.txt";

    [Test]
    public void Should_Read_TextFile()
    {
        // Arrange
        var sut = new TextFileReader();

        // Act
        var result = sut.ReadWordsFromFile(filePath);

        // Assert
        result.Count.Should().Be(11);
    }

    [Test]
    public void Should_Throw_FileNotFoundException()
    {
        // Arrange
        var sut = new TextFileReader();

        // Act
        // Assert
        Assert.Throws<FileNotFoundException>(() => sut.ReadWordsFromFile("test.txt"));
    }
}
