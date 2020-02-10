using System;
using System.Collections.Generic;
using System.Threading;
using com.codedool.plaza.api;

namespace com.codecool.plaza.cmdprog
{
    public class CmdProgram
    {
        private Plaza myPlaza;
        private List<Product> cart;
        private List<float> prices;

        public CmdProgram(String[] args)
        {
        }
        public void run()
        {
            bool? loop = true;
            while (loop.Value)
            {
                MenuStart();
                loop = ChooseStart();
            }
            string nameOfPlaza = AnyInput("The name of the plaza?: ");
            myPlaza = new PlazaImpl(nameOfPlaza);
            bool loop2 = true; 
            while (loop2)
            {
                MenuMainPlaza(nameOfPlaza);
                loop2 = ChooseMainPlaza();
            }
        }

        void MenuStart()
        {
            Console.Clear();
            Console.WriteLine("Welcome the the PLAZA SIM!");
            Console.WriteLine();
            Console.WriteLine("(1) Create a new Plaza");
            Console.WriteLine("(0) Exit");
            Console.WriteLine();
        }
        void MenuMainPlaza(string nameOfPlaza)
        {
            Console.Clear();
            Console.WriteLine("Welcome the the " + nameOfPlaza + " plaza!");
            Console.WriteLine();
            Console.WriteLine("(1) Check if the plaza is open or not.");
            Console.WriteLine("(2) Open the plaza.");
            Console.WriteLine("(3) Close the plaza.");
            Console.WriteLine("(4) List all shops.");
            Console.WriteLine("(5) Add a new shop.");
            Console.WriteLine("(6) Remove an existing shop.");
            Console.WriteLine("(7) Enter a shop by name.");
            Console.WriteLine("(0) Exit");
            Console.WriteLine();
        }
        bool? ChooseStart()
        {
            string choice = AnyInput("Please choose an option...");
            if (choice == "1")
            {
                return false;
            }
            else if (choice == "0")
            {
                Environment.Exit(-1);
            }
            return true;
        }
        bool ChooseMainPlaza()
        {
            string choice = AnyInput("Please choose an option...");
            switch (choice)
            {
                case "1":
                    Console.Clear();
                    Console.WriteLine(myPlaza.IsOpen().ToString());
                    AnyInput("Press any key to continue...");
                    return true;
                case "2":
                    Console.Clear();
                    myPlaza.Open();
                    Console.WriteLine("The plaza has just opened.");
                    Thread.Sleep(1000);
                    return true;
                case "3":
                    Console.Clear();
                    myPlaza.Close();
                    Console.WriteLine("The plaza has just opened.");
                    Thread.Sleep(1000);
                    return true;
                case "4":
                    Console.Clear();
                    if (myPlaza.GetShops().Count > 0)
                    {
                        foreach (Shop aShop in myPlaza.GetShops())
                        {
                            Console.WriteLine(aShop.ToString());
                        }
                    }
                    else
                    {
                        Console.WriteLine("There are no shops in the Plaza.");
                    }
                    AnyInput("Press any key to continue...");
                    return true;
                case "5":
                    Console.Clear();
                    string name = AnyInput("The name of the new shop?: ");
                    string owner = AnyInput("The owner of the new shop?: ");
                    Shop shop = new ShopImpl(name, owner);
                    myPlaza.AddShop(shop);
                    Console.WriteLine("A new shop has added the plaza.");
                    Thread.Sleep(1000);
                    return true;
                case "6":
                    Console.Clear();
                    AnyInput("Press any key to continue...");
                    return true;
                case "7":
                    Console.Clear();
                    AnyInput("Press any key to continue...");
                    return true;
                case "8":
                    Console.Clear();
                    AnyInput("Press any key to continue...");
                    return true;
                case "9":
                    Console.Clear();
                    return true;
                case "0":
                    Console.Clear();
                    return false;
                default:
                    return true;
            }

        }


        public int IntInput(string inputMessage)
        {
            int number;
            string input;
            while (true)
            {
                Console.Write(inputMessage);
                input = Console.ReadLine();
                if (int.TryParse(input, out number))
                {
                    return int.Parse(input);
                }
                else
                {
                    Console.WriteLine("It is not a number!");
                }
            }
        }
        public float FloatInput(string inputMessage)
        {
            float number;
            string input;
            while (true)
            {
                Console.Write(inputMessage);
                input = Console.ReadLine();
                if (float.TryParse(input, out number))
                {
                    return float.Parse(input);
                }
                else
                {
                    Console.WriteLine("It is not a number!");
                }
            }
        }
        public long LongInput(string inputMessage)
        {
            long number;
            string input;
            while (true)
            {
                Console.Write(inputMessage);
                input = Console.ReadLine();
                if (long.TryParse(input, out number))
                {
                    return long.Parse(input);
                }
                else
                {
                    Console.WriteLine("It is not a number!");
                }
            }
        }
        public string AnyInput(string inputMessage)
        {
            Console.Write(inputMessage);
            return Console.ReadLine();
        }
        public bool BoolInput(string inputMessage)
        {
            while (true)
            {
                Console.Write(inputMessage);
                string input = Console.ReadLine().ToLower();
                if (input == "y" || input == "yes")
                {
                    return true;
                }
                else if (input == "n" || input == "no")
                {
                    return false;
                }
                else
                {
                    Console.WriteLine("Wrong answer!");
                }
            }
        }
        public bool BoolTrans(string text)
        {
            if (text == "true") { return true; }
            else { return false; }
        }
    }
}
