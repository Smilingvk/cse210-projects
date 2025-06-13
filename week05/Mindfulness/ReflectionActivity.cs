using System;
using System.Collections.Generic;
using System.Threading;

public class ReflectionActivity : Activity
{
    private List<string> _prompts = new()
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private List<string> _questions = new()
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience?",
        "What did you learn about yourself?",
        "How can you keep this experience in mind in the future?"
    };

    public ReflectionActivity()
        : base("Reflection Activity", "This activity will help you reflect on times in your life when you have shown strength and resilience.") { }

    public void Run()
    {
        DisplayStartingMessage();
        Random rand = new Random();

        Console.WriteLine("\n" + _prompts[rand.Next(_prompts.Count)]);
        ShowSpinner(3);

        DateTime end = DateTime.Now.AddSeconds(_duration);
        while (DateTime.Now < end)
        {
            string question = _questions[rand.Next(_questions.Count)];
            Console.Write("\n> " + question + " ");
            ShowSpinner(5);
        }

        DisplayEndingMessage();
    }
}
