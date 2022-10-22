using FluentAssertions;
using LetterwordChallenge.Application.Contracts;
using LetterwordChallenge.Domain;
using LetterwordChallenge.Domain.ValueObjects;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using Match = LetterwordChallenge.Domain.ValueObjects.Match;

namespace LetterwordChallenge.Application.Tests;

[TestFixture]
public class WordMatcherTests
{
    private readonly IReadOnlyList<Word> words = new List<Word> { "foobar", "string", "words1", "foo", "bar", "oneone", "o", "n", "e", "o", "n", "e" }.AsReadOnly();
    private readonly MatchCollection testMatches = MatchCollection.Create(6);
    private readonly Mock<ITextfileReader> _fileReaderMock = new();
    private const string filePath = "test.txt";
    private readonly Match match1 = new("foobar", 6);
    private readonly Match match2 = new("oneone", 6);


    [SetUp]
    public void Setup()
    {
        _fileReaderMock.Setup(x => x.ReadWordsFromFile(filePath)).Returns(words);
        testMatches.AddMatchToCollection(match1);
        testMatches.AddMatchToCollection(match2);
    }

    [Test]
    public void Should_Return_No_Matchen_When_Length_IsTooBig()
    {
        // Arrange
        var sut = new WordMatcher(_fileReaderMock.Object);

        // Act
        var matches = sut.GetMatchesWithLength(filePath, 1000);

        // Assert
        matches.Matches.Count.Should().Be(0);
    }

    [Test]
    public void Should_Return_Matches()
    {
        // Arrange
        var sut = new WordMatcher(_fileReaderMock.Object);

        // Act
        var matches = sut.GetMatchesWithLength(filePath, 6);

        // Assert
        matches.Matches.Count.Should().Be(testMatches.Matches.Count);
        matches.Matches[0].Should().Be(testMatches.Matches[0]);
        matches.Matches[1].Should().Be(testMatches.Matches[1]);
    }
}
