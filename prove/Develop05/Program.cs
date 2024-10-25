class Program
{
    static void Main(string[] args)
    {
        List<Activity> activities = new List<Activity> {
            new Breathing(),
            new Reflection(),
            new Listing()
        };

        while (true) {
            Console.WriteLine("Menu Options:");
            int activityNum = 1;
            foreach (Activity activity in activities) {
                Console.WriteLine($"  {activityNum}. Start {activity.GetName()} activity");
                activityNum++;
            }

            int quitNum = activityNum;
            Console.WriteLine($"  {quitNum}. Quit");
            Console.Write("Select a choice from the menu: ");
            int selection = int.Parse(Console.ReadLine());

            if (selection == quitNum) {
                return;
            } else {
                activities[selection-1].RunActivity();
            }
        }
    }
}
