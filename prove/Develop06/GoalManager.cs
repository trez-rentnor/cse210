class GoalManager {
    private List<Goal> _goals;

    public GoalManager() {
        _goals = new List<Goal>();
    }

    public void Start() {
        bool finished = false;

        while (!finished) {
            DisplayPlayerInfo();
            Console.WriteLine();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Create New Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Save Goals");
            Console.WriteLine("  4. Load Goals");
            Console.WriteLine("  5. Record Event");
            Console.WriteLine("  6. Quit");
            Console.Write("Select a choice from the menu: ");
            String selection = Console.ReadLine();
            
            switch (selection ) {
                case "1":
                    CreateGoal();
                    break;
                case "2":
                    ListGoalDetails();
                    break;
                case "3":
                    SaveGoals();
                    break;
                case "4":
                    LoadGoals();
                    break;
                case "5":
                    RecordEvent();
                    break;
                case "6":
                    finished = true;
                    break;
            }
        }
    }

    public void DisplayPlayerInfo() {
        Console.WriteLine($"You have {GetScore()} points.");
    }

    public void ListGoalNames() {
        int goalIndex = 1;
        foreach (Goal goal in _goals) {
            Console.WriteLine($"  {goalIndex}. {goal.GetName()}");
            goalIndex++;
        }
    }

    public void ListGoalDetails() {
        int goalNumber = 1;
        foreach (Goal goal in _goals) {
            Console.WriteLine($"  {goalNumber}. [{(goal.IsComplete() ? "X" : " ")}] {goal.GetStringRepresentation()}");
            foreach (Event evt in goal.GetEvents()) {
                Console.WriteLine($"         Performed at {evt.GetEventTime()} for {goal.GetPoints()} points");
            }
            goalNumber++;
        }
        Console.WriteLine();
    }

    private void CreateGoal() {
        Console.WriteLine("The types of goals are:");
        Console.WriteLine("  1. Simple Goal");
        Console.WriteLine("  2. Eternal Goal");
        Console.WriteLine("  3. Checklist Goal");
        Console.Write("Which type of goal would you like to create? ");
        String response = Console.ReadLine();
        Console.Write("What is the name of your goal? ");
        String name = Console.ReadLine();
        Console.Write("What is a short description of your goal? ");
        String description = Console.ReadLine();
        Console.Write("What is the amount of points associated with this goal? ");
        int points = int.Parse(Console.ReadLine());

        switch (response) {
            case "1":
                _goals.Add(new SimpleGoal(name, description, points));
                break;
            case "2":
                _goals.Add(new EternalGoal(name, description, points));
                break;
            case "3":
                Console.Write("How many times does this goal need to be accomplished for a bonus? ");
                int target = int.Parse(Console.ReadLine());
                Console.Write("What is the bonus for accomplishing it that many times? ");
                int bonus = int.Parse(Console.ReadLine());
                _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
                break;
        }

        Console.WriteLine();
    }

    public void RecordEvent() {
        Console.WriteLine("The goals are:");
        ListGoalNames();
        Console.Write("Which goal did you accomplish? ");
        int selection = int.Parse(Console.ReadLine());
        
        Goal selectedGoal = _goals[selection-1];
        selectedGoal.RecordEvent();
    }

    public void SaveGoals() {
        Console.Write("What is the filename of the goals file? ");
        String filename = Console.ReadLine();

        using (StreamWriter outputFile = new StreamWriter(filename)) {
            foreach (Goal goal in _goals) {
                outputFile.Write($"{goal.GetType().Name}|");
                outputFile.Write(goal.GetDetailsString());
                foreach (Event goalEvent in goal.GetEvents()) {
                    outputFile.Write($",{goalEvent.GetDetailsString()}");
                }
                outputFile.WriteLine();
            }
        }
    }

    public void LoadGoals() {
        Console.Write("What is the filename of the goals file? ");
        String filename = Console.ReadLine();
        
        String[] lines = System.IO.File.ReadAllLines(filename);

        _goals = new List<Goal>();

        foreach (String line in lines) {
            String[] parts = line.Split("|");

            switch (parts[0]) {
                case "SimpleGoal":
                    _goals.Add(buildSimpleGoal(parts[1]));
                    break;
                case "EternalGoal":
                    _goals.Add(buildEternalGoal(parts[1]));
                    break;
                case "ChecklistGoal":
                    _goals.Add(buildChecklistGoal(parts[1]));
                    break;
            }
        }
    }

    private SimpleGoal buildSimpleGoal(String detailsString) {
        String[] parts = detailsString.Split(",");
        SimpleGoal result = new SimpleGoal(parts[0], parts[1], int.Parse(parts[2]));
        for (int i = 3; i < parts.Length; i++) {
            result.GetEvents().Add(new Event(DateTime.Parse(parts[i])));
        }
        return result;
    }

    private EternalGoal buildEternalGoal(String detailsString) {
        String[] parts = detailsString.Split(",");
        EternalGoal result =  new EternalGoal(parts[0], parts[1], int.Parse(parts[2]));
        for (int i = 3; i < parts.Length; i++) {
            result.GetEvents().Add(new Event(DateTime.Parse(parts[i])));
        }
        return result;
    }

    private ChecklistGoal buildChecklistGoal(String detailsString) {
        String[] parts = detailsString.Split(",");
        ChecklistGoal result = new ChecklistGoal(parts[0], parts[1], int.Parse(parts[2]),int.Parse(parts[3]),
            int.Parse(parts[4]));
        for (int i = 5; i < parts.Length; i++) {
            result.GetEvents().Add(new Event(DateTime.Parse(parts[i])));
        }
        return result;
    }

    private int GetScore() {
        return _goals.Sum(g => g.GetScore());
    }
}