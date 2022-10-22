using LetterwordChallenge.Domain;
using LetterwordChallenge.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetterwordChallenge.Application.Contracts;

public interface ITextfileReader
{
    IReadOnlyList<Word> ReadWordsFromFile(string path);
}
