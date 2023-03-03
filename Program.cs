using System;
using System.Collections.Generic;

internal class Program
{
    class UserInterface
    {
        public Stack<int> tower1;
        public Stack<int> tower2;
        public Stack<int> tower3;
        public int total_moves;
        public int source;
        public int destination;
        public char start;
        public String message;
        public UserInterface()
        {
            total_moves = 0;
            source = 0;
            destination = 0;
            message = "";
            tower1 = new Stack<int>();
            tower1.Push(5);
            tower1.Push(4);
            tower1.Push(3);
            tower1.Push(2);
            tower1.Push(1);
            tower2 = new Stack<int>();
            tower3 = new Stack<int>();
            start = 'a';
        }
        public void printTowers()
        {
            Console.Write("Tower 1 ::: ");
            foreach(int item in tower1)
            {
                Console.Write(item + " ");
            }
            Console.Write("\n\nTower 2 :::");
            foreach (int item in tower2)
            {
                Console.Write(item + " ");
            }
            Console.Write("\n\nTower 3 :::");
            foreach (int item in tower3)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine("\n");
        }
        public void Inputmoves()
        {
            while (true)
            {
                if (message != "")
                {
                    Console.WriteLine("Message :: "+message);
                }
                Console.WriteLine("Select Tower to Disk move");
                Console.WriteLine("Source");
                source = int.Parse(Console.ReadLine());
                
                if(source <1 || source > 3) {
                    message = "Wrong Source Tower";
                    continue;
                }
                Console.WriteLine("Destination");
                destination = int.Parse(Console.ReadLine());
                if (destination < 1 || destination > 3) 
                {
                    message = "Wrong Destination Tower";
                    continue;
                }
                message = "";
                break;
                
            }
        }
        public void clearscreen()
        {
            Console.Clear(); 
        }
        public void cleargame()
        {
            tower1 = new Stack<int>();
            tower1.Push(5);
            tower1.Push(4);
            tower1.Push(3);
            tower1.Push(2);
            tower1.Push(1);
            tower2 = new Stack<int>();
            tower3 = new Stack<int>();
        }
        public char startgame()
        {
            while (true)
            {
                Console.WriteLine("Press \'S\' to start game.");
                Console.WriteLine("Press \'C\' to close game.");
                start = char.Parse(Console.ReadLine());
                if (start == 's' || start == 'S' || start == 'c' || start == 'C')
                    break;
                else
                    Console.WriteLine("Wrong Input");
            }
            return start;
            
        }
        public void frontDesign()
        {
            Console.WriteLine("------------------------------\n");
            Console.WriteLine("\tTower of Honai\n");
            Console.WriteLine("------------------------------\n");

        }
        public void instructions()
        {
            Console.WriteLine("1. This is a Tower of Honai game.");
            Console.WriteLine("2. There are plates in Tower 1, weight staring from 1-5.");
            Console.WriteLine("3. You have to move these plates from Tower1 to Tower3.");
            Console.WriteLine("4. Rules include: You can't place a plate with greater weight on the plate with small weight.");
            Console.WriteLine("5. Lowest Plate is on the right & Upper Plate on the left");
            Console.WriteLine("6. You have to move all the upper plates to reach the lowest one");
        }
         
    }
    class GameLogics
    {
        public UserInterface UI;
        public GameLogics()
        {
            UI = new UserInterface();
        }
        public bool checkForRules()
        {
            int number, checkrules;
            while (true)
            {
                UI.Inputmoves();
                number = 0;
                checkrules = 0;
                if (UI.source == 1)
                {
                    if (UI.tower1.Count == 0)
                    {
                        UI.message = "No plates left in Tower 1";
                        continue;
                    }
                    number = UI.tower1.Peek();
                    UI.tower1.Pop();
                }
                else if (UI.source == 2)
                {
                    if (UI.tower2.Count == 0)
                    {
                        UI.message = "No plates in Tower 2";
                        continue;
                    }
                    number = UI.tower2.Peek();
                    UI.tower2.Pop();
                }
                else 
                {
                    if (UI.tower3.Count == 0)
                    {
                        UI.message = "No plates in Tower 3";
                        continue;
                    }
                    number = UI.tower3.Peek();
                    UI.tower3 .Pop();
                }

                if (UI.destination == 1)
                {
                    if (UI.tower1.Count != 0)
                    {
                        checkrules = UI.tower1.Peek();
                    }
                    else
                    {
                        UI.tower1.Push(number);
                        return true; 
                    }
                }
                else if (UI.destination == 2)
                {
                    if (UI.tower2.Count != 0)
                    {
                        checkrules = UI.tower2.Peek();
                    }
                    else
                    {
                        UI.tower2.Push(number);
                        return true;
                    }
                }
                else 
                {
                    if (UI.tower3.Count != 0)
                    {
                        checkrules = UI.tower3.Peek();
                    }
                    else
                    {
                        UI.tower3.Push(number);
                        return true;
                    }
                }
                if (number < checkrules)
                {
                    if (UI.destination == 1)
                    {
                        UI.tower1.Push(number);
                        number = 0;
                    }
                    else if (UI.destination == 2)
                    {
                        UI.tower2.Push(number);
                        number = 0;
                    }
                    else if (UI.destination == 3)
                    {
                        UI.tower3.Push(number);
                        number = 0;
                    }
                    return true;
                }

                else
                {
                    if (UI.source == 1)
                    {
                        UI.tower1.Push(number);
                    }
                    else if (UI.source == 2)
                    {
                        UI.tower2.Push(number);
                    }
                    else if (UI.source == 3)
                    {
                        UI.tower3.Push(number);
                    }

                    return false;
                }
            }
        }
        public bool checkWinner()
        {
            int number = 0;
            foreach(int i in UI.tower3)
            {
                number += i;
                number *= 10;
            }
            number/= 10;
            if (number == 12345)
                return true;
            else
                return false;
        }
        public void startGameLoop()
        {
            
            UI.frontDesign();
            if(UI.startgame() == 'S' || UI.startgame() == 's')
            {
                Console.WriteLine("Read Instructions Carefully\n\n");
                UI.instructions();
                Console.WriteLine("\nPress Any Key To Continue");
                Console.ReadKey();
                while(checkWinner() != true)
                { 
                    UI.clearscreen();
                    UI.frontDesign();
                    UI.printTowers();
                    Console.WriteLine("Total Moves = " + UI.total_moves);
                    Console.WriteLine("------------------------------\n");
                    if(checkForRules() == true)
                    {
                        UI.message = "Successfully Moved";
                        UI.total_moves += 1;
                    }
                    else
                    {
                        UI.message = "Unsuccessfull Because You are trying to put a large plate on small one";
                    }
                    
                    if (checkWinner())
                    {

                        Console.WriteLine("You Won!!!");
                        Console.ReadKey();
                        break;
                    }

                }
            }
            
            
        }
    }
    class MainLoop
    {
        static GameLogics gameLogics = new GameLogics();
        private static void Main(string[] args)
        {
            while (true)
            {
                gameLogics.startGameLoop();
            }

        }
    }
}