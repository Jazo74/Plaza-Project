using System;
using System.Collections.Generic;

namespace com.codedool.plaza.cmdprog
{
    public class CmdProgram
    {
        private List<Product> cart;
        private List<float> prices;

        public CmdProgram(String[] args)
        {
        }
        public void run()
        {
            bool loop = true;
            while (loop)
            {
                MenuMainPlaza();
                loop = Choose();
            }
        }
        void MenuMainPlaza()
        {
            Console.WriteLine("Welcome the the PLAZA simulation");
            Console.Clear();
            Console.WriteLine("(1) Create a new Plaza");
            Console.WriteLine("(2) Check if the plaza is open or not.");
            Console.WriteLine("(3) Open the plaza.");
            Console.WriteLine("(4) Close the plaza.");
            Console.WriteLine("(5) List all shops.");
            Console.WriteLine("(6) Add a new shop.");
            Console.WriteLine("(7) Remove an existing shop.");
            Console.WriteLine("(8) Enter a shop by name.");
            Console.WriteLine("(0) Exit");
        }
        bool ChooseMainPlaza()
        {
            
            string choice = AnyInput("Please choose an option...");
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
