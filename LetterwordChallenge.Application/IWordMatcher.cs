using LetterwordChallenge.Domain;
namespace LetterwordChallenge.Application;

public interface IWordMatcher
{
    MatchCollection GetMatchesWithLength(string path, decimal length);
}
