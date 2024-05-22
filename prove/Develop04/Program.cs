using System;
using System.Collections.Generic;
using System.Threading;

public abstract class Activity
{
    public string Name { get; set; }
    public string Description { get; set; }

    public void Start(int duration)
    {
        Console.WriteLine($"Welcome to {Name}!");
        Console.WriteLine(Description);
        Console.WriteLine($"Please prepare to begin. Duration: {duration} seconds.");
        Thread.Sleep(5000);
    }

    public void End(int duration)
    {
        Console.WriteLine($"Great job! You completed {Name} in {duration} seconds.");
        Thread.Sleep(5000);
    }

    public abstract void Run(int duration);
}

public class BreathingActivity : Activity
{
    public BreathingActivity()
    {
        Name = "Breathing";
        Description = "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.";
    }

    public override void Run(int duration)
    {
        Start(duration);
        for (int i = 0; i < duration; i++)
        {
            Console.WriteLine("Breathe in...");
            Thread.Sleep(1000);
            Console.WriteLine("Breathe out...");
            Thread.Sleep(1000);
        }
        End(duration);
    }
}

public class ReflectionActivity : Activity
{
    private List<string> Prompts { get; set; }
    private List<string> Questions { get; set; }

    public ReflectionActivity()
    {
        Name = "Reflection";
        Description = "This activity will help you reflect on times in your life when you have shown strength and resilience.";
        Prompts = new List<string>()
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."

        };
        Questions = new List<string>()
        {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
           "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?"
        };
    }

    public override void Run(int duration)
    {
        Start(duration);
        string prompt = Prompts[new Random().Next(Prompts.Count)];
        Console.WriteLine(prompt);
        Thread.Sleep(5000);
        for (int i = 0; i < duration; i++)
        {
            string question = Questions[new Random().Next(Questions.Count)];
            Console.WriteLine(question);
            Thread.Sleep(5000);
        }
        End(duration);
    }
}

public class ListingActivity : Activity
{
    private List<string> Prompts { get; set; }

    public ListingActivity()
    {
        Name = "Listing";
        Description = "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.";
        Prompts = new List<string>()
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };
    }

    public override void Run(int duration)
    {
        Start(duration);
        string prompt = Prompts[new Random().Next(Prompts.Count)];
        Console.WriteLine(prompt);
        Thread.Sleep(5000);
        List<string> items = new List<string>();
        for (int i = 0; i < duration; i++)
        {
            Console.Write("Enter an item: ");
            string item = Console.ReadLine();
            items.Add(item);
            Thread.Sleep(1000);
        }
        Console.WriteLine($"You entered {items.Count} items.");
        End(duration);
    }
}

class Program
{
    static void Main(string[] args)
    {
        List<Activity> activities = new List<Activity>()
        {
            new BreathingActivity(),
            new ReflectionActivity(),
            new ListingActivity()
        };

        while (true)
        {
            Console.WriteLine("Menu:");
            for (int i = 0; i < activities.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {activities[i].Name}");
            }
            Console.Write("Choose an activity (or 'q' to quit): ");
            string choice = Console.ReadLine();
            if (choice.ToLower() == "q")
            {
                break;
            }
            Activity activity = activities[int.Parse(choice) - 1];
            Console.Write("Enter duration in seconds: ");
            int duration = int.Parse(Console.ReadLine());
            activity.Run(duration);
        }
    }
}

