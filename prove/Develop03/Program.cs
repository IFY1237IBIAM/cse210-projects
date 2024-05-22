using System;
using System.Collections.Generic;
using System.Linq;

namespace ScriptureProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Scripture scripture = new Scripture(new Reference("John", 3, 16), "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life.");

            // Looping  until the user quits
            while (true)
            {
                Console.Clear();
                Console.WriteLine(scripture);
                Console.Write("Press enter to hide words, or type 'quit' to exit, or type 'quiz' to start a quiz: ");
                string input = Console.ReadLine();

                if (input.ToLower() == "quit")
                {
                    break;
                }
                else if (input.ToLower() == "quiz")
                {
                    scripture.QuizMode();
                }
                else
                {
                    scripture.HideRandomWords();
                }
            }
        }
    }
}

// Scripture.cs
// This class represents a scripture, containing a reference and a list of words

public class Scripture
{
    private Reference reference;
    private List<Word> words;


    public Scripture(Reference reference, string text)
    {
        this.reference = reference;
        this.words = text.Split(' ').Select(t => new Word(t)).ToList();
        
        
    }

    // Hide random words in the scripture
    public void HideRandomWords()
    {
        var random = new Random();
        var word = words[random.Next(words.Count)];
        word.Hide();
    }

    // Start quiz mode
    public void QuizMode()
    {
        Console.Clear();
        Console.WriteLine("Quiz Mode!");
        Console.WriteLine(reference + " " + string.Join(" ", words.Select(w => w.Text)));

        string input = Console.ReadLine();

        // Check if the input is correct
    }

    public override string ToString()
    {
        return $"{reference} {string.Join(" ", words.Select(w => w.Text))}";
    }
}

// Reference.cs
// This class represents a reference, containing a book, start verse, and end verse

public class Reference
{
    private string book;
    private int startVerse;
    private int endVerse;

    public Reference(string book, int verse)
    {
        this.book = book;
        this.startVerse = verse;
        this.endVerse = verse;
    }

    public Reference(string book, int startVerse, int endVerse)
    {
        this.book = book;
        this.startVerse = startVerse;
        this.endVerse = endVerse;
    }

    public override string ToString()
    {
        if (startVerse == endVerse)
        {
            return $"{book} {startVerse}";
        }
        else
        {
            return $"{book} {startVerse}-{endVerse}";
        }
    }
}

// Word.cs
// This class represents a word, containing the text and a hidden flag

public class Word
{
    private string text;
    private bool hidden;

    public Word(string text)
    {
        this.text = text;
        this.hidden = false;
    }

    public string Text
    {
        get
        {
            if (hidden)
            {
                return "*****";
            }
            else
            {
                return text;
            }
        }
    }

    public void Hide()
    {
        this.hidden = true;
    }
}