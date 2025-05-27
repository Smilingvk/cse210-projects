using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        List<Scripture> scriptures = LoadScripturesFromFile("scriptures.txt");
        Random rand = new Random();
        Scripture scripture = scriptures[rand.Next(scriptures.Count)];

        while (!scripture.AllWordsHidden())
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine("\nPress Enter to continue or type 'quit' to exit:");
            string input = Console.ReadLine();
            if (input.ToLower() == "quit")
                break;

            scripture.HideRandomWords(3);
        }

        Console.Clear();
        Console.WriteLine(scripture.GetDisplayText());
    }

    static List<Scripture> LoadScripturesFromFile(string filename)
    {
        List<Scripture> scriptures = new List<Scripture>();
        foreach (var line in File.ReadLines(filename))
        {
            if (string.IsNullOrWhiteSpace(line)) continue;

            var parts = line.Split('|');
            if (parts.Length != 2) continue;

            Reference reference = Reference.Parse(parts[0].Trim());
            string text = parts[1].Trim();
            scriptures.Add(new Scripture(reference, text));
        }
        return scriptures;
    }
}
public class Reference
{
    private string book;
    private int chapter;
    private int verseStart;
    private int verseEnd;

    public Reference(string book, int chapter, int verse)
    {
        this.book = book;
        this.chapter = chapter;
        this.verseStart = verse;
        this.verseEnd = verse;
    }

    public Reference(string book, int chapter, int verseStart, int verseEnd)
    {
        this.book = book;
        this.chapter = chapter;
        this.verseStart = verseStart;
        this.verseEnd = verseEnd;
    }

    public static Reference Parse(string input)
    {
        var spaceIndex = input.IndexOf(' ');
        string book = input.Substring(0, spaceIndex);
        string chapterVerse = input.Substring(spaceIndex + 1);
        string[] chapterAndVerses = chapterVerse.Split(':');
        int chapter = int.Parse(chapterAndVerses[0]);

        if (chapterAndVerses[1].Contains("-"))
        {
            var verses = chapterAndVerses[1].Split('-');
            return new Reference(book, chapter, int.Parse(verses[0]), int.Parse(verses[1]));
        }
        else
        {
            return new Reference(book, chapter, int.Parse(chapterAndVerses[1]));
        }
    }

    public override string ToString()
    {
        if (verseStart == verseEnd)
            return $"{book} {chapter}:{verseStart}";
        else
            return $"{book} {chapter}:{verseStart}-{verseEnd}";
    }
}

public class Word
{
    private string text;
    private bool isHidden;

    public Word(string text)
    {
        this.text = text;
        isHidden = false;
    }

    public void Hide()
    {
        isHidden = true;
    }

    public bool IsHidden()
    {
        return isHidden;
    }

    public string GetDisplayText()
    {
        return isHidden ? new string('_', text.Length) : text;
    }
}

public class Scripture
{
    private Reference reference;
    private List<Word> words;
    private Random rand = new Random();

    public Scripture(Reference reference, string text)
    {
        this.reference = reference;
        this.words = text.Split(' ').Select(word => new Word(word)).ToList();
    }

    public void HideRandomWords(int count)
    {
        var visibleWords = words.Where(w => !w.IsHidden()).ToList();
        for (int i = 0; i < count && visibleWords.Count > 0; i++)
        {
            int index = rand.Next(visibleWords.Count);
            visibleWords[index].Hide();
            visibleWords.RemoveAt(index);
        }
    }

    public string GetDisplayText()
    {
        return reference.ToString() + "\n" + string.Join(" ", words.Select(w => w.GetDisplayText()));
    }

    public bool AllWordsHidden()
    {
        return words.All(w => w.IsHidden());
    }
}
