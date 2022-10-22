# How to run the Console App

From the root of the project:<br />
<code>
cd ./LetterwordChallenge.Console
</code><br />
<code>
dotnet run ./input.txt 6
</code>

Paramter 1: location of the inputfile<br />
Parameter 2: length of the words that can be a match

For a faster test there is a testFile.txt file included.

# 6 letter words
There's a file in the root of the repository, input.txt, that contains words of varying lengths (1 to 6 characters).

Your objective is to show all combinations of those words that together form a word of 6 characters. That combination must also be present in input.txt
E.g.:  
<code>
foobar  
fo  
obar  
</code>

should result in the ouput:  
<code>
fo+obar=foobar
</code>

You can start by only supporting combinations of two words and improve the algorithm at the end of the exercise to support any combinations.

Treat this exercise as if you were writing production code; think unit tests, SOLID, clean code and avoid primitive obsession. Be mindful of changing requirements like a different maximum combination length, or a different source of the input data.

The solution must be stored in a git repo. After the repo is cloned, the application should be able to run with one command / script.

Don't spend too much time on this.
