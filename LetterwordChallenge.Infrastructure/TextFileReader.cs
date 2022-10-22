using LetterwordChallenge.Application.Contracts;
using LetterwordChallenge.Domain;
using LetterwordChallenge.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
namespace LetterwordChallenge.Infrastructure;

public class TextFileReader : ITextfileReader
{
    public IReadOnlyList<Word> ReadWordsFromFile(string path)
    {
        var words = new List<Word>();

        string[] lines = File.ReadAllLines(path);

        foreach (string line in lines)
            words.Add(line);

        return words;
    }
}
