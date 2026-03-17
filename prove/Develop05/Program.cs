using System;
using System.ComponentModel.Design;
using System.Runtime.CompilerServices;

class Program
{
    static private List<Goal> AllGoals = new List<Goal>();
    static private int Score = 0;
    static void Main(string[] args)
    {
        bool goaling = true;
        while (goaling)
        {
            string userInput;
            while(true)
            {
                //Starting menu conditions
                Console.Clear();
                Console.WriteLine("-----Welcome to the Goal Program-----\n");
                Console.WriteLine("Please select an option:");
                Console.WriteLine("1. Create a new Goal");
                Console.WriteLine("2. Report progress on a goal");
                Console.WriteLine("3. Save Goals");
                Console.WriteLine("4. Load Goals");
                Console.WriteLine("5. Print Goals");
                Console.WriteLine("6. Quit Program");
                Console.WriteLine("Please input 1-6: ");
                userInput = Console.ReadLine();

                //Make sure the input is valid, otherwise repeat menu
                if(userInput == "1" || userInput == "2" || userInput == "3" || userInput == "4" || userInput == "5" || userInput == "6")
                {
                    Console.Clear();
                    break;
                }
                else
                {
                    Console.WriteLine("Please Input a 1, 2, 3, 4, or 5");
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
                        Console.WriteLine("1. Eternal Goal (Never Completed)");
                        userInput = Console.ReadLine();

                        //Ensure user input is valid, otherwise they repeat
                        if (userInput == "1" || userInput == "1" || userInput == "1")
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

                    break;

                case 4:
                //Load a Goals list
                    
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
                //End the program
                    goaling = false; //Sets the infinite loop to false so it wont repeat
                    Console.WriteLine("Come back soon!");
                    Thread.Sleep(2000);
                    break;
            }
        }
    }
}