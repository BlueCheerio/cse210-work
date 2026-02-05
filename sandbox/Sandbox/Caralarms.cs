public class Car
{
    public Door driverDoor = new Door();
    public Door passengerDoor = new Door();
    public Horn carHorn = new Horn();
    public RemoteClicker clicker = new RemoteClicker();
    public bool IsRunning = true;

    public void Run()
    {
        driverDoor.Name = "Driver Door";
        passengerDoor.Name = "Passenger Door";

        while (IsRunning)
        {
            // 1. DISPLAY OPTIONS
            PrintMenu();

            // 2. CHECK STATUS (The "Brain")
            if (clicker.IsArmed)
            {
                if (driverDoor.IsOpen || passengerDoor.IsOpen)
                {
                    carHorn.Honk();
                }
            }

            // 3. GET INPUT
            Console.Write("\nSelect an option (1-5): ");
            string input = Console.ReadLine();

            if (input == "1") driverDoor.Toggle();
            else if (input == "2") passengerDoor.Toggle();
            else if (input == "3") clicker.IsArmed = true;
            else if (input == "4") clicker.IsArmed = false;
            else if (input == "5") 
            {
                driverDoor.IsLocked = !driverDoor.IsLocked;
                passengerDoor.IsLocked = !passengerDoor.IsLocked;
            }
            else if (input == "6") IsRunning = false;
            else Console.WriteLine("Invalid choice, try again.");

            // 4. SHOW CURRENT STATE
            Console.WriteLine("----------------------------------");
            Console.WriteLine($"SYSTEM STATUS: [Armed: {clicker.IsArmed}]");
            Console.WriteLine($"DOORS:         [Driver: {driverDoor.GetStatus()}] [Passenger: {passengerDoor.GetStatus()}]");
            Console.WriteLine("----------------------------------");
        }

        Console.WriteLine("Goodbye!");
    }

    public void PrintMenu()
    {
        Console.WriteLine("\n--- CAR ALARM MENU ---");
        Console.WriteLine("1. Open/Close Driver Door");
        Console.WriteLine("2. Open/Close Passenger Door");
        Console.WriteLine("3. Set Alarm (Arm)");
        Console.WriteLine("4. Disable Alarm (Disarm)");
        Console.WriteLine("5. Unlock/Lock car doors");
        Console.WriteLine("6. Exit Program");
    }
}

// --- Component Classes ---

public class Door
{
    public string Name;
    public bool IsOpen = false;
    public bool IsLocked = false;
    public void Toggle()
    {
        if (IsLocked == false)
        {
            IsOpen = !IsOpen;
        }
        Console.WriteLine($"[Action] {Name} is now {(IsOpen ? "OPEN" : "CLOSED")}");
    }

    public string GetStatus()
    {
        return IsOpen ? "Open" : "Closed";
    }
}

public class Horn
{
    public void Honk()
    {
        Console.WriteLine("\n!!! ALARM TRIGGERED !!!");
        for (int i = 0; i < 3; i++)
        {
            Console.WriteLine("BEEP! HONK!");
            Thread.Sleep(1000);
        }
    }
}

public class RemoteClicker
{
    public bool IsArmed = false;
}