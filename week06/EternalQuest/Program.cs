using System;

class Program
{
    static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();
        int choice = -1;

        while (choice != 6)
        {
            Console.WriteLine("\nEternal Quest Program:");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Record Event");
            Console.WriteLine("4. Save Goals");
            Console.WriteLine("5. Load Goals");
            Console.WriteLine("6. Quit");
            Console.Write("Select a choice: ");
            choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    CreateGoal(manager);
                    break;
                case 2:
                    manager.ShowGoals();
                    manager.ShowScore();
                    break;
                case 3:
                    manager.ShowGoals();
                    Console.Write("Which goal did you accomplish? ");
                    int index = int.Parse(Console.ReadLine()) - 1;
                    manager.RecordEvent(index);
                    break;
                case 4:
                    Console.Write("Enter filename: ");
                    string saveName = Console.ReadLine();
                    manager.Save(saveName);
                    break;
                case 5:
                    Console.Write("Enter filename: ");
                    string loadName = Console.ReadLine();
                    manager.Load(loadName);
                    break;
            }
        }
    }

    static void CreateGoal(GoalManager manager)
    {
        Console.WriteLine("\nGoal Types:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("Choose a goal type: ");
        int type = int.Parse(Console.ReadLine());

        Console.Write("Name: ");
        string name = Console.ReadLine();
        Console.Write("Description: ");
        string desc = Console.ReadLine();
        Console.Write("Points: ");
        int points = int.Parse(Console.ReadLine());

        switch (type)
        {
            case 1:
                manager.AddGoal(new SimpleGoal(name, desc, points));
                break;
            case 2:
                manager.AddGoal(new EternalGoal(name, desc, points));
                break;
            case 3:
                Console.Write("Target count: ");
                int target = int.Parse(Console.ReadLine());
                Console.Write("Bonus points: ");
                int bonus = int.Parse(Console.ReadLine());
                manager.AddGoal(new ChecklistGoal(name, desc, points, target, bonus));
                break;
        }
    }
}