using LetterwordChallenge.Domain.Exceptions;
using LetterwordChallenge.Domain.ValueObjects;

namespace LetterwordChallenge.Domain;

public class MatchCollection
{
    public List<Match> Matches { get; set; } = new List<Match>();
    public decimal MatchLength { get; set; }

    public static MatchCollection Create(decimal length)
    {
        return new MatchCollection
        {
            Matches = new List<Match>(),
            MatchLength = length,
        };
    }

    public void AddMatchToCollection(Match match)
    {
        if (match.Length != MatchLength)
            throw new InvalidLengthException($"matches must be of length {MatchLength}, word has a length of: {match.Length}.");

        if (Matches.Contains(match))
            return;

        Matches.Add(match);
    }
}
