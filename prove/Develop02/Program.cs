using System;
using System.Collections.Generic;
using System.Linq;

namespace JournalApp
{
	// This is the main program class
	class Program
	{
		static void Main(string[] args)
		{
			// Creating a new Journal instance
			Journal journal = new Journal();
			
			// Defining a list of prompts for the user
			List<string> prompts = new List<string>
			{
				"Who was the most interesting person I interacted with today?",
				"What was the best part of my day?",
				"How did I see the hand of the Lord in my life today?",
				"What was the strongest emotion I felt today?",
				"If I had one thing I could do over today, what would it be?",
				"What did I learn today?",
				"What am I grateful for today?",
				"What am I looking forward to tomorrow?"
			};
			
			// Main program loop
			while (true)
			{
				// Displaying menu options
				Console.WriteLine("1. Write a new entry");
				Console.WriteLine("2. Display the journal");
				Console.WriteLine("3. Save the journal to a file");
				Console.WriteLine("4. Load the journal from a file");
				Console.WriteLine("5. Exit");
				Console.Write("Choose an option: ");
				
				// Get user input
				int option = Convert.ToInt32(Console.ReadLine());
				
				// Handling user input
				switch (option)
				{
					case 1:
						// Write a new entry
						string prompt = prompts.OrderBy(x => Guid.NewGuid()).First();
						Console.WriteLine(prompt);
						string response = Console.ReadLine();
						Entry entry = new Entry { Prompt = prompt, Response = response, Date = DateTime.Now.ToString() };
						journal.AddEntry(entry);
						break;
					case 2:
						// Display the journal
						journal.DisplayEntries();
						break;
					case 3:
						// Save the journal to a file
						Console.Write("Enter filename: ");
						string filename = Console.ReadLine();
						journal.SaveToFile(filename);
						break;
					case 4:
						// Load the journal from a file
						Console.Write("Enter filename: ");
						filename = Console.ReadLine();
						journal.LoadFromFile(filename);
						break;
					case 5:
						// Exit the program
						return;
					default:
						// Handle invalid input
						Console.WriteLine("Invalid option. Please choose a valid option.");
						break;
				}
			}
		}
	}
}

// Entry.cs
namespace JournalApp
{
	// This is the Entry class, representing a single journal entry
	public class Entry
	{
		public string Prompt { get; set; }
		public string Response { get; set; }
		public string Date { get; set; }
	}
}

// Journal.cs
namespace JournalApp
{
	// This is the Journal class, managing a list of entries
	public class Journal
	{
		private List<Entry> entries = new List<Entry>();
		
		// Adding a new entry to the journal
		public void AddEntry(Entry entry)
		{
			entries.Add(entry);
		}
		
		// Display all entries in the journal
		public void DisplayEntries()
		{
			foreach (var entry in entries)
			{
				Console.WriteLine($"Prompt: {entry.Prompt}");
				Console.WriteLine($"Response: {entry.Response}");
				Console.WriteLine($"Date: {entry.Date}");
				Console.WriteLine();
			}
		}
		
		// Save the journal to a file
		public void SaveToFile(string filename)
		{
			using (StreamWriter writer = new StreamWriter(filename))
			{
				foreach (var entry in entries)
				{
					writer.WriteLine($"{entry.Prompt}|{entry.Response}|{entry.Date}");
				}
			}
		}
		
		// Load the journal from a file
		public void LoadFromFile(string filename)
		{
			entries = new List<Entry>();
			using (StreamReader reader = new StreamReader(filename))
			{
				string line;
				while ((line = reader.ReadLine()) != null)
				{
					string[] parts = line.Split('|');
					Entry entry = new Entry
					{
						Prompt = parts[0],
						Response = parts[1],
						Date = parts[2]
					};
					entries.Add(entry);
				}
			}
		}
	}
}
 