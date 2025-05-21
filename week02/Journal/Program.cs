using System;
using System.Collections.Generic;
using System.IO;

public class Entry
{
    public string _prompt;
    public string _response;
    public string _date;

    public Entry(string prompt, string response, string date)
    {
        _prompt = prompt;
        _response = response;
        _date = date;
    }

    public void Display()
    {
        Console.WriteLine($"Date: {_date}");
        Console.WriteLine($"Prompt: {_prompt}");
        Console.WriteLine($"Response: {_response}\n");
    }

    public string ToJournalString()
    {
        return $"{_date}|{_prompt}|{_response}";
    }

    public static Entry FromJournalString(string line)
    {
        string[] parts = line.Split('|');
        if (parts.Length >= 3)
        {
            string date = parts[0];
            string prompt = parts[1];
            string response = string.Join("|", parts, 2, parts.Length - 2);
            return new Entry(prompt, response, date);
        }
        return null;
    }
}

public class Journal
{
    private List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry entry)
    {
        _entries.Add(entry);
    }

    public void Display()
    {
        Console.WriteLine("--- Journal Entries ---\n");
        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }

    public void Save(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (Entry entry in _entries)
            {
                writer.WriteLine(entry.ToJournalString());
            }
        }
        Console.WriteLine($"Journal saved to {filename}\n");
    }

    public void Load(string filename)
    {
        if (!File.Exists(filename))
        {
            Console.WriteLine($"File not found: {filename}\n");
            return;
        }
        _entries.Clear();
        string[] lines = File.ReadAllLines(filename);
        foreach (string line in lines)
        {
            Entry entry = Entry.FromJournalString(line);
            if (entry != null)
            {
                _entries.Add(entry);
            }
        }
        Console.WriteLine($"Journal loaded from {filename}\n");
    }
}

// Main program
class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        List<string> prompts = new List<string>
        {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "What am I grateful for today?",
            "What challenge did I overcome today?",
            "If I could relive one moment from today, what would it be?"
        };
        var rand = new Random();

        bool running = true;
        while (running)
        {
            Console.WriteLine("Journal Menu:\n1. Write a new entry\n2. Display the journal\n3. Save the journal\n4. Load the journal\n5. Quit");
            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    string prompt = prompts[rand.Next(prompts.Count)];
                    Console.WriteLine($"Prompt: {prompt}");
                    Console.Write("Your response: ");
                    string response = Console.ReadLine();
                    string date = DateTime.Now.ToShortDateString();
                    Entry entry = new Entry(prompt, response, date);
                    journal.AddEntry(entry);
                    Console.WriteLine("Entry added!\n");
                    break;

                case "2":
                    journal.Display();
                    break;

                case "3":
                    Console.Write("Enter filename to save: ");
                    string saveFile = Console.ReadLine();
                    journal.Save(saveFile);
                    break;

                case "4":
                    Console.Write("Enter filename to load: ");
                    string loadFile = Console.ReadLine();
                    journal.Load(loadFile);
                    break;

                case "5":
                    running = false;
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please select 1-5.\n");
                    break;
            }
        }

        Console.WriteLine("Goodbye!");
    }
}
