namespace LetterwordChallenge.Domain.ValueObjects;

public record Word(string Value)
{
    public static implicit operator Word(string value) => new(value);
}