using System;
using System.Collections.Generic;

abstract class Activity
{
    private string _date;
    private int _minutes;

    public Activity(string date, int minutes)
    {
        _date = date;
        _minutes = minutes;
    }

    public string GetDate() => _date;
    public int GetMinutes() => _minutes;

    public abstract double GetDistance();
    public abstract double GetSpeed();
    public abstract double GetPace();

    public virtual string GetSummary()
    {
        return $"{_date} {GetType().Name} ({_minutes} min) - Distance: {GetDistance():F1} km, Speed: {GetSpeed():F1} kph, Pace: {GetPace():F2} min per km";
    }
}

class Running : Activity
{
    private double _distance; // in kilometers

    public Running(string date, int minutes, double distance)
        : base(date, minutes)
    {
        _distance = distance;
    }

    public override double GetDistance() => _distance;

    public override double GetSpeed() => (_distance / GetMinutes()) * 60;

    public override double GetPace() => GetMinutes() / _distance;
}

class Cycling : Activity
{
    private double _speed; // in kilometers per hour

    public Cycling(string date, int minutes, double speed)
        : base(date, minutes)
    {
        _speed = speed;
    }

    public override double GetDistance() => _speed * GetMinutes() / 60;

    public override double GetSpeed() => _speed;

    public override double GetPace() => 60 / _speed;
}

class Swimming : Activity
{
    private int _laps;

    public Swimming(string date, int minutes, int laps)
        : base(date, minutes)
    {
        _laps = laps;
    }

    public override double GetDistance() => _laps * 50 / 1000.0;

    public override double GetSpeed() => (GetDistance() / GetMinutes()) * 60;

    public override double GetPace() => GetMinutes() / GetDistance();
}


class Program
{
    static void Main(string[] args)
    {
        List<Activity> activities = new List<Activity>
        {
            new Running("03 Nov 2022", 30, 4.8),
            new Cycling("04 Nov 2022", 45, 20.0),
            new Swimming("05 Nov 2022", 60, 40)
        };

        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
        Console.WriteLine("Hello World! This is the ExerciseTracking Project.");
    }
}