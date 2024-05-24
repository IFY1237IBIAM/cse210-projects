using System;
using System.Collections.Generic;

public abstract class Goal
{
    public string Name { get; set; }
    public int Points { get; set; }
    public bool IsComplete { get; set; }
   
    public abstract void RecordEvent();
}

public class SimpleGoal : Goal
{
    public override void RecordEvent()
    {
        IsComplete = true;
    }
}

public class EternalGoal : Goal
{
    public override void RecordEvent()
    {
        // Gain points each time the goal is recorded
    }
}

public class ChecklistGoal : Goal
{
    public int TargetCount { get; set; }
    public int CurrentCount { get; set; }

    public override void RecordEvent()
    {
        CurrentCount++;
        if (CurrentCount >= TargetCount)
        {
            IsComplete = true;
            // Gain bonus points when the goal is completed
        }
    }
}

public class Program
{
    public static List<Goal> Goals { get; set; } = new List<Goal>();
    public static int Score { get; set; }

    public static void Main(string[] args)
    {
        LoadData();

        while (true)
        {
            Console.WriteLine("1. Create new goal");
            Console.WriteLine("2. Record event");
            Console.WriteLine("3. Show goals");
            Console.WriteLine("4. Save and exit");

            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreateGoal();
                    break;
                case "2":
                    RecordEvent();
                    break;
                case "3":
                    ShowGoals();
                    break;
                case "4":
                    SaveData();
                    return;
            }
        }
    }

    private static void CreateGoal()
    {
        Console.WriteLine("Enter goal name:");
        var name = Console.ReadLine();

        Console.WriteLine("Enter goal type (Simple, Eternal, Checklist):");
        var type = Console.ReadLine();

        Goal goal;
        switch (type)
        {
            case "Simple":
                goal = new SimpleGoal();
                break;
            case "Eternal":
                goal = new EternalGoal();
                break;
            case "Checklist":
                goal = new ChecklistGoal();
                break;
            default:
                return;
        }

        goal.Name = name;
        Goals.Add(goal);
    }

    private static void RecordEvent()
    {
        Console.WriteLine("Enter goal name:");
        var name = Console.ReadLine();

        var goal = Goals.Find(g => g.Name == name);
        if (goal != null)
        {
            goal.RecordEvent();
            Score += goal.Points;
        }
    }

   private static void ShowGoals()
{
    foreach (var goal in Goals)
    {
        Console.WriteLine($"{goal.Name} - {(goal.IsComplete ? "[X]" : "[ ]")}");
        if (goal is ChecklistGoal checklistGoal)
        {
            Console.WriteLine($"Completed {checklistGoal.CurrentCount}/{checklistGoal.TargetCount} times");
        }
    }
    Console.WriteLine($"Score: {Score}");
}

    private static void SaveData()
    {
        using (var writer = new StreamWriter("data.txt"))
        {
            writer.WriteLine(Score);
            foreach (var goal in Goals)
            {
                writer.WriteLine(goal.Name);
                writer.WriteLine(goal.Points);
                writer.WriteLine(goal.IsComplete);
                if (goal is ChecklistGoal checklistGoal)
                {
                    writer.WriteLine(checklistGoal.TargetCount);
                    writer.WriteLine(checklistGoal.CurrentCount);
                }
            }
        }
    }

    private static void LoadData()
    {
        if (File.Exists("data.txt"))
        {
            using (var reader = new StreamReader("data.txt"))
            {
                Score = int.Parse(reader.ReadLine());
                while (!reader.EndOfStream)
                {
                    var name = reader.ReadLine();
                    var points = int.Parse(reader.ReadLine());
                    var isComplete = bool.Parse(reader.ReadLine());

                    Goal goal;
                    if (reader.EndOfStream)
                    {
                        goal = new SimpleGoal();
                    }
                    else
                    {
                        var targetCount = int.Parse(reader.ReadLine());
                        var currentCount = int.Parse(reader.ReadLine());
                        goal = new ChecklistGoal { TargetCount = targetCount, CurrentCount = currentCount };
                    }

                    goal.Name = name;
                    goal.Points = points;
                    goal.IsComplete = isComplete;
                    Goals.Add(goal);
                }
            }
        }
    }
}