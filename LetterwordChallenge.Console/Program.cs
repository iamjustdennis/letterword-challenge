using LetterwordChallenge.Application;
using LetterwordChallenge.Application.Contracts;
using LetterwordChallenge.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

public class Program
{
    public static void Main(string[] args)
    {
        var serviceProvider = new ServiceCollection()
            .AddLogging()
            .AddTransient<ITextfileReader, TextFileReader>()
            .AddTransient<IWordMatcher, WordMatcher>()
            .BuildServiceProvider();

        var wordMatcher = serviceProvider.GetService<IWordMatcher>();

        Console.WriteLine($"Starting application...");

        var filePath = args[0];
        var matchLength = decimal.Parse(args[1]);

        var start = DateTime.Now;
        var match = wordMatcher?.GetMatchesWithLength(filePath, matchLength);
        var end = DateTime.Now;

        Console.WriteLine($"Total matches: {match?.Matches.Count}");
        Console.WriteLine($"Time elapsed: {end - start}");
    }
}