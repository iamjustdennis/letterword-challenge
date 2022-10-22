using FluentAssertions;
using LetterwordChallenge.Domain;
using LetterwordChallenge.Domain.Exceptions;
using LetterwordChallenge.Domain.ValueObjects;
using NUnit.Framework;

namespace LetterWordChallenge.Domain.Tests;

[TestFixture]
public class MatchCollectionTests
{

    [Test]
    public void Shoud_Create_MatchCollection()
    {
        // Act
        var result = MatchCollection.Create(6);

        // Assert
        result.MatchLength.Should().Be(6);
        result.Matches.Should().BeEmpty();
    }

    [Test]
    public void Should_Add_Match_ToCollection()
    {
        // Arrange
        var possibleMatch = new Match("foobar", 6);
        var sut = MatchCollection.Create(6);

        // Act
        sut.AddMatchToCollection(possibleMatch);

        // Assert
        sut.Matches.Should().Contain(possibleMatch);
    }

    [Test]
    public void Should_Throw_InvalidLengthException()
    {
        // Arrange
        var word = new Word("foo");
        var possibleMatch = new Match(word, word.Value.Length);
        var sut = MatchCollection.Create(6);

        // Act
        // Assert
        Assert.Throws<InvalidLengthException>(() => sut.AddMatchToCollection(possibleMatch));
    }
}
