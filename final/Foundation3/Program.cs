using System;

public class Address
{
    private string street;
    private string city;
    private string state;
    private string country;

    public Address(string street, string city, string state, string country)
    {
        this.street = street;
        this.city = city;
        this.state = state;
        this.country = country;
    }

    public override string ToString()
    {
        return $"{street}\n{city}, {state}\n{country}";
    }
}

public abstract class Event
{
    private string title;
    private string description;
    private DateTime date;
    private TimeSpan time;
    private Address address;

    public Event(string title, string description, DateTime date, TimeSpan time, Address address)
    {
        this.title = title;
        this.description = description;
        this.date = date;
        this.time = time;
        this.address = address;
    }

    public string StandardDetails()
    {
        return $"{title}\n{description}\n{date.ToShortDateString()} {time}\n{address}";
    }

    public abstract string FullDetails();
    public abstract string ShortDescription();
}

public class Lecture : Event
{
    private string speaker;
    private int capacity;

    public Lecture(string title, string description, DateTime date, TimeSpan time, Address address, string speaker, int capacity)
        : base(title, description, date, time, address)
    {
        this.speaker = speaker;
        this.capacity = capacity;
    }

    public override string FullDetails()
    {
        return $"{StandardDetails()}\nSpeaker: {speaker}\nCapacity: {capacity}";
    }

    public override string ShortDescription()
    {
        return $"Lecture: {title} on {date.ToShortDateString()}";
    }
}

public class Reception : Event
{
    private string rsvpEmail;

    public Reception(string title, string description, DateTime date, TimeSpan time, Address address, string rsvpEmail)
        : base(title, description, date, time, address)
    {
        this.rsvpEmail = rsvpEmail;
    }

    public override string FullDetails()
    {
        return $"{StandardDetails()}\nRSVP Email: {rsvpEmail}";
    }

    public override string ShortDescription()
    {
        return $"Reception: {title} on {date.ToShortDateString()}";
    }
}

public class OutdoorGathering : Event
{
    private string weather;

    public OutdoorGathering(string title, string description, DateTime date, TimeSpan time, Address address, string weather)
        : base(title, description, date, time, address)
    {
        this.weather = weather;
    }

    public override string FullDetails()
    {
        return $"{StandardDetails()}\nWeather: {weather}";
    }

    public override string ShortDescription()
    {
        return $"Outdoor Gathering: {title} on {date.ToShortDateString()}";
    }
}

class Program
{
    static void Main(string[] args)
    {
        Address address1 = new Address("123 Main St", "Anytown", "CA", "USA");
        Address address2 = new Address("456 Elm St", "Othertown", "ON", "NIGERIa");
        Address address3 = new Address("789 Oak St", "Thistown", "TX", "USA");

        Event lecture = new Lecture("Lecture 1", "This is a lecture", DateTime.Parse("2022-01-01"), TimeSpan.Parse("10:00"), address1, "John Doe", 50);
        Event reception = new Reception("Reception 1", "This is a reception", DateTime.Parse("2022-01-15"), TimeSpan.Parse("18:00"), address2, "rsvp@email.com");
        Event outdoorGathering = new OutdoorGathering("Outdoor Gathering 1", "This is an outdoor gathering", DateTime.Parse("2022-02-01"), TimeSpan.Parse("12:00"), address3, "Sunny");

        Console.WriteLine("Lecture:");
        Console.WriteLine(lecture.StandardDetails());
        Console.WriteLine(lecture.FullDetails());
        Console.WriteLine(lecture.ShortDescription());

        Console.WriteLine("\nReception:");
        Console.WriteLine(reception.StandardDetails());
        Console.WriteLine(reception.FullDetails());
        Console.WriteLine(reception.ShortDescription());

        Console.WriteLine("\nOutdoor Gathering:");
        Console.WriteLine(outdoorGathering.StandardDetails());
        Console.WriteLine(outdoorGathering.FullDetails());
        Console.WriteLine(outdoorGathering.ShortDescription());
    }
}
