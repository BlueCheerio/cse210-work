using System;
using System.ComponentModel.Design;
using System.Runtime.CompilerServices;

class Program
{
    static private List<Goal> AllGoals = new List<Goal>();
    static private int Score = 0;
    static void Main(string[] args)
    {
        Console.Clear();
        Console.WriteLine("-----Welcome to the Goal Program-----");
        Thread.Sleep(3000); //I put this outside the program so that it only prints once
        bool goaling = true;
        while (goaling)
        {
            string userInput;
            while(true)
            {
                //Starting menu conditions
                Console.Clear();
                Console.WriteLine("Please select an option:");
                Console.WriteLine("1. Create a new Goal");
                Console.WriteLine("2. Report progress on a goal");
                Console.WriteLine("3. Save Goals");
                Console.WriteLine("4. Load Goals");
                Console.WriteLine("5. Print Goals");
                Console.WriteLine("6. Delete a Goal");
                Console.WriteLine("7. Quit Program");
                int currentx = Console.CursorTop; // save our cursor position
                //This is to write the score in the top right corner
                string scoreMessage = $"Score: {Score}";
                Console.SetCursorPosition(Console.WindowWidth - scoreMessage.Length, 1); //It measures the message to make sure it fits in the corner of the program, I set it to 1 because the initial console height isn't tall enough
                Console.Write(scoreMessage);
                Console.SetCursorPosition(0, currentx); 
                //Write our last line
                Console.WriteLine("Please input 1-7: ");
                userInput = Console.ReadLine();

                //Make sure the input is valid, otherwise repeat menu
                if(userInput == "1" || userInput == "2" || userInput == "3" || userInput == "4" || userInput == "5" || userInput == "6" || userInput == "7")
                {
                    Console.Clear();
                    break;
                }
                else
                {
                    Console.WriteLine("Please Input a 1, 2, 3, 4, 5, 6, or 7");
                    Thread.Sleep(2000);
                }
            }

            int userI = int.Parse(userInput);

            //We determine what to do here depending on the menu choice
            switch (userI)
            {
                case 1:
                //Create a new goal
                    while(true)
                    {
                        //Choose what type of goal to create
                        Console.WriteLine("Please select one of the following goals to create:");
                        Console.WriteLine("1. Simple Goal (Complete once)");
                        Console.WriteLine("2. Checklist Goal (Complete a few times)");
                        Console.WriteLine("3. Eternal Goal (Never Completed)");
                        userInput = Console.ReadLine();

                        //Ensure user input is valid, otherwise they repeat
                        if (userInput == "1" || userInput == "2" || userInput == "3")
                        {
                            Console.Clear();
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Please input a 1, 2, or 3");
                            Thread.Sleep(2000);
                            Console.Clear();
                        }
                    }

                    //Input information about the Goal
                    Console.WriteLine("Give the Goal a name: ");
                    string name = Console.ReadLine();
                    Console.WriteLine("Give a description of the goal: ");
                    string description = Console.ReadLine();
                    userI = int.Parse(userInput);
                    switch(userI)
                    {
                        case 1:
                            AllGoals.Add(new SimpleGoal(name, description));
                            break;
                        case 2:
                            Console.WriteLine("How many times does the goal need to be completed?: ");
                            int timesToComplete = int.Parse(Console.ReadLine());
                            AllGoals.Add(new ChecklistGoal(name, description, timesToComplete));
                            break;
                        case 3:
                            AllGoals.Add(new EternalGoal(name, description));
                            break;
                    }
                    Console.WriteLine("\n-----Goal Created!-----");
                    Thread.Sleep(2000);
                    break;

                case 2:
                //Report progress on a goal
                    Console.WriteLine("Type the name of the goal you have completed:");
                    string goalName = Console.ReadLine();
                    bool itemExists = false;
                    int itemIndex = 0;
                    for (int i = 0; i < AllGoals.Count; i++)
                    {
                        //Check if that name exists
                        if (AllGoals[i].GetName().ToLower() == goalName.ToLower())
                        {
                            itemExists = true;
                            itemIndex = i;
                        }
                    }
                    if(itemExists)
                    {
                        if(AllGoals[itemIndex].CheckComplete())
                        {
                            //Because I keep completed goals in the same list
                            Console.WriteLine("This goal is already complete silly!");
                            Thread.Sleep(2000);
                        }
                        else
                        {
                            //My unnecessarily complicated way of adding to the total score
                            int temporaryScore = AllGoals[itemIndex].GetScore();
                            AllGoals[itemIndex].MarkComplete();
                            int pointsGained = AllGoals[itemIndex].GetScore() - temporaryScore;
                            Score += pointsGained;
                            if(AllGoals[itemIndex].CheckComplete())
                            {
                                Console.Clear();
                                Console.WriteLine("-----Congrats! You completely finished that goal!-----\n");
                                Console.WriteLine($"You gained {pointsGained} points!\n");
                                Console.WriteLine("--0----0--");
                                Thread.Sleep(1000);
                                Console.WriteLine("----------");
                                Thread.Sleep(1000);
                                Console.WriteLine("0--------0");
                                Thread.Sleep(1000);
                                Console.WriteLine("-00----00-");
                                Thread.Sleep(1000);
                                Console.WriteLine("---0000---");
                                Thread.Sleep(3000);
                            }
                            else if (AllGoals[itemIndex] is EternalGoal)
                            {
                                Console.Clear();
                                Console.WriteLine("You made progress on your Eternal goal!");
                                Console.WriteLine($"You gained {pointsGained} points and have completed that goal {AllGoals[itemIndex].GetTimesCompleted()} times!");
                                Console.WriteLine("--0----0--");
                                Thread.Sleep(1000);
                                Console.WriteLine("----------");
                                Thread.Sleep(1000);
                                Console.WriteLine("0--------0");
                                Thread.Sleep(1000);
                                Console.WriteLine("-00----00-");
                                Thread.Sleep(1000);
                                Console.WriteLine("---0000---");
                                Thread.Sleep(3000);
                            }
                            else
                            {
                                Console.WriteLine("You made progress on your Checklist goal!\n");
                                Console.WriteLine($"You gained {pointsGained} points and have completed that goal {AllGoals[itemIndex].GetTimesCompleted()} times!");
                                Console.WriteLine("--0----0--");
                                Thread.Sleep(1000);
                                Console.WriteLine("----------");
                                Thread.Sleep(1000);
                                Console.WriteLine("0--------0");
                                Thread.Sleep(1000);
                                Console.WriteLine("-00----00-");
                                Thread.Sleep(1000);
                                Console.WriteLine("---0000---");
                                Thread.Sleep(3000);
                            }
                        }

                    }
                    else
                    {
                        Console.WriteLine("That goal does not exist, maybe check your spelling!");
                        Thread.Sleep(3000);
                    }
                    break;

                case 3:
                //Save the current Goals list
                    Console.WriteLine("What would you like to call this set of Goals?");
                    string filename = Console.ReadLine();
                    if (!filename.Contains(".txt"))          //I got this from my Develop2 program
                    {
                        filename = filename + ".txt";
                    }
                    using (StreamWriter File = new StreamWriter(filename.ToLower()))
                    {
                        File.WriteLine(Score);
                        foreach (Goal item in AllGoals)
                        {
                            //Save the goal and all it's information to 1 line
                            if (item is SimpleGoal)
                            {
                                File.Write($"SimpleGoal:{item.GetName()}:{item.GetDescription()}:{item.GetScore()}:{item.CheckComplete()}");
                            }
                            else if (item is ChecklistGoal)
                            {
                                File.Write($"ChecklistGoal:{item.GetName()}:{item.GetDescription}:{item.GetScore()}:{item.CheckComplete()}:{item.GetTimesCompleted()}:{((ChecklistGoal)item).GetTimesToComplete()}");
                            }
                            else if (item is EternalGoal)
                            {
                                File.Write($"EternalGoal:{item.GetName()}:{item.GetDescription}:{item.GetScore()}:{item.GetTimesCompleted()}");
                            }

                            if (item.CheckComplete())
                            {
                                File.Write($":{item.GetDateCompleted()}"); // Add this onto the line (only works for Simple and Checklist goals)
                            }
                            File.WriteLine(); //Go to next line for the next Goal 
                        }
                        Console.Clear();
                        Console.WriteLine($"-----Goals successfully saved to file '{filename}'-----");
                        Thread.Sleep(2000);
                    }
                    break;

                case 4:
                //Load a Goals list
                    Console.WriteLine("Loading goals will clear the current list, type 'no' to cancel\n");
                    Console.WriteLine("What is the name of the set of Goals you would like to load?");
                    string fileload = Console.ReadLine();
                    if (fileload == "no")
                    {
                        //Can cancel load if user desires
                        break;
                    }
                    else
                    {
                        AllGoals.Clear();
                    }
                    if (!fileload.Contains(".txt"))          //I got this from my Develop2 program
                    {
                        fileload = fileload + ".txt";
                    }
                    //Load the file
                    string[] lines = System.IO.File.ReadAllLines(fileload.ToLower());
                    foreach (string line in lines)
                    {
                        if (line == lines[0])
                        {
                            //The first line in the file is the Score
                            Score = int.Parse(line);
                        }
                        else
                        {
                            //Read the line and make it into a goal class that we add to the AllGoals list
                            int currentIndex = AllGoals.Count;
                            string[] parts = line.Split(":");
                            if(parts[0] == "SimpleGoal")
                            {
                                AllGoals.Add(new SimpleGoal(parts[1], parts[2]));
                                AllGoals[currentIndex].SetScore(int.Parse(parts[3]));
                                if (parts[4] == "True")
                                {
                                    AllGoals[currentIndex].SetComplete(true);
                                    AllGoals[currentIndex].SetDateCompleted(parts[5]);
                                }
                                else
                                {
                                    AllGoals[currentIndex].SetComplete(false);
                                }
                            }
                            else if (parts[0] == "ChecklistGoal")
                            {
                                AllGoals.Add(new ChecklistGoal(parts[1], parts[2], int.Parse(parts[6])));
                                AllGoals[currentIndex].SetScore(int.Parse(parts[3]));
                                AllGoals[currentIndex].SetTimesCompleted(int.Parse(parts[5]));
                                if (parts[4] == "True")
                                {
                                    AllGoals[currentIndex].SetComplete(true);
                                    AllGoals[currentIndex].SetDateCompleted(parts[7]);
                                }
                                else
                                {
                                    AllGoals[currentIndex].SetComplete(false);
                                }
                            }
                            else if (parts[0] == "EternalGoal")
                            {
                                AllGoals.Add(new EternalGoal(parts[1], parts[2]));
                                AllGoals[currentIndex].SetScore(int.Parse(parts[3]));
                                AllGoals[currentIndex].SetTimesCompleted(int.Parse(parts[4]));
                            }
                            else
                            {
                                Console.WriteLine("Somehow that goal doesn't fit our program");
                            }
                        }
                    }
                    Console.Clear();
                    Console.WriteLine("-----Goals Loaded!-----");
                    Thread.Sleep(2000);
                    break;

                case 5:
                //Display all the Goals
                    foreach (Goal item in AllGoals)
                    {
                        item.PrintDetails();
                    }
                    Console.WriteLine("Press any key to return to the menu");
                    Console.ReadKey();
                    break;

                case 6:
                //Delete a goal
                    Console.WriteLine("Type the name of the goal you want to delete:");
                    string gname = Console.ReadLine();
                    bool gExists = false;
                    int gIndex = 0;
                    for (int i = 0; i < AllGoals.Count; i++)
                    {
                        //Check if that name exists
                        if (AllGoals[i].GetName().ToLower() == gname.ToLower())
                        {
                            gExists = true;
                            gIndex = i;
                        }
                    }
                    Console.Clear(); //Display whether the goal is going to be deleted or not
                    if(gExists)
                    {
                        AllGoals.RemoveAt(gIndex);
                        Console.WriteLine("-----Goal Deleted-----");
                        Thread.Sleep(2000);
                    }
                    else
                    {
                        Console.WriteLine("That goal does not exist! Please check your spelling...");
                        Thread.Sleep(2000);
                    }
                    break;

                case 7:
                //End the program
                    goaling = false; //Sets the infinite loop to false so it wont repeat
                    Console.WriteLine("Come back soon!");
                    Thread.Sleep(2000);
                    break;
            }
        }
    }
}