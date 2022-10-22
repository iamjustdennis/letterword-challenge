namespace LetterwordChallenge.Domain.Exceptions;

[Serializable]
public class InvalidLengthException : Exception
{
    public InvalidLengthException()
    {
    }

    public InvalidLengthException(string message)
        : base(message)
    {
    }
}
