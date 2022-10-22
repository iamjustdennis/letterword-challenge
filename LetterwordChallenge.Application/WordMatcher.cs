using LetterwordChallenge.Application.Contracts;
using LetterwordChallenge.Domain;
using LetterwordChallenge.Domain.ValueObjects;

namespace LetterwordChallenge.Application;

public class WordMatcher : IWordMatcher
{
    private readonly ITextfileReader _textFileReader;

    public WordMatcher(ITextfileReader textfileReader)
    {
        _textFileReader = textfileReader;
    }

    public MatchCollection GetMatchesWithLength(string path, decimal length) {
        var matches = MatchCollection.Create(length);
        var words = GetWordsFromFile(path);
        var totalLength = words.Select(x => x.Value.Length).Sum();

        if (totalLength < matches.MatchLength)
            return matches;

        var possibleMatches = GetPossibleMatches(words, matches.MatchLength);
        var otherWords = GetOtherWords(words, matches.MatchLength);

        foreach (var word in otherWords)
            CalculateMatches(word, otherWords,possibleMatches, matches);

        return matches;
    }

    private void CalculateMatches(Word word, IReadOnlyList<Word> otherWords, List<Word> possibleMatches, MatchCollection matches)
    {
        var currentLength = word.Value.Length;
        var possibleMatch = otherWords.Where(x => (x.Value.Length + currentLength) <= matches.MatchLength);

        foreach (var combination in possibleMatch)
        {
            var newWord = word.Value + combination.Value;

            if (newWord.Length < matches.MatchLength)
                CalculateMatches(newWord, otherWords, possibleMatches, matches);

            if (possibleMatches.Contains(newWord))
            {
                var match = new Match(newWord, newWord.Length);
                matches.AddMatchToCollection(match);
                break;
            }
        }
    }

    private static List<Word> GetPossibleMatches(IReadOnlyList<Word> words, decimal matchLength) =>
        words.Where(x => x.Value.Length == matchLength).ToList();

    private static IReadOnlyList<Word> GetOtherWords(IReadOnlyList<Word> words, decimal matchLength) =>
        words.Where(x => x.Value.Length < matchLength).ToList().AsReadOnly();

    private IReadOnlyList<Word> GetWordsFromFile(string path) =>
        _textFileReader.ReadWordsFromFile(path);
}
