using System;
using System.Collections.Generic;
using System.Threading;
using com.codecool.plaza.api;

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
                    Console.WriteLine("The plaza has just closed.");
                    Thread.Sleep(1000);
                    return true;
                case "4":
                    Console.Clear();
                    try
                    {
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
                    }
                    catch (PlazaIsClosedException)
                    {
                        Console.WriteLine("The Plaza is closed.");
                    }
                    AnyInput("Press any key to continue...");
                    return true;
                case "5":
                    Console.Clear();
                    string shopName = AnyInput("The name of the new shop?: ");
                    string owner = AnyInput("The owner of the new shop?: ");
                    try
                    {
                        Shop shop = new ShopImpl(shopName, owner);
                        myPlaza.AddShop(shop);
                        Console.WriteLine("A new shop has added the plaza.");
                    }
                    catch (PlazaIsClosedException)
                    {
                        Console.WriteLine("The Plaza is closed.");
                    }
                    catch (ShopAlreadyExistsException)
                    {
                        Console.WriteLine("This shop is already exist.");
                    }
                    Thread.Sleep(1000);
                    return true;
                case "6":
                    Console.Clear();
                    shopName = AnyInput("The shop name to remove?: ");
                    try
                    {
                        myPlaza.RemoveShop(myPlaza.FindShopByName(shopName));
                    }
                    catch (PlazaIsClosedException)
                    {
                        Console.WriteLine("The Plaza is closed.");
                    }
                    catch (NoSuchShopException)
                    {
                        Console.WriteLine("No shop is exist with this name.");
                    }
                    Thread.Sleep(1000);
                    return true;
                case "7":
                    Console.Clear();
                    shopName = AnyInput("Which shop you want to enter?: ");
                    try
                    {
                        bool shopbool = true;
                        while (shopbool)
                        {
                            MenuShop(myPlaza.FindShopByName(shopName));
                            shopbool = ChooseShop();
                        }
                    }
                    catch (PlazaIsClosedException)
                    {
                        Console.WriteLine("The Plaza is closed.");
                    }
                    catch (NoSuchShopException)
                    {
                        Console.WriteLine("No shop is exist with this name.");
                    }
                    Console.WriteLine("Entering the shop.");
                    Thread.Sleep(1000);
                    return true;
                case "0":
                    Console.Clear();
                    return false;
                default:
                    return true;
            }
        }
        void MenuShop(Shop shop)
        {
            Console.Clear();
            Console.WriteLine("Welcome the the " + shop.GetName() + " plaza!");
            Console.WriteLine();
            Console.WriteLine("(4) Open the shop");
            Console.WriteLine("(4) Close the shop");
            Console.WriteLine("(1) List available products");
            Console.WriteLine("(2) Find a product by name.");
            Console.WriteLine("(3) Display the shop's owner");
            Console.WriteLine("(5) Add new product to the shop");
            Console.WriteLine("(6) Add existing products to the shop");
            Console.WriteLine("(7) Buy a product by barcode");
            Console.WriteLine("(7) Check price by barcode");
            Console.WriteLine("(0) Exit");
            Console.WriteLine();
        }
        bool ChooseShop()
        {
            string choice = AnyInput("Please choose an option...");
            switch (choice)
            {
                case "1":
                    Console.Clear();
                    AnyInput("Press any key to continue...");
                    return true;
                case "2":
                    Console.Clear();
                    Thread.Sleep(1000);
                    return true;
                case "3":
                    Console.Clear();
                    Thread.Sleep(1000);
                    return true;
                case "4":
                    Console.Clear();
                    AnyInput("Press any key to continue...");
                    return true;
                case "5":
                    Console.Clear();
                    Thread.Sleep(1000);
                    return true;
                case "6":
                    Console.Clear();

                    Thread.Sleep(1000);
                    return true;
                case "7":
                    Console.Clear();
                    Thread.Sleep(1000);
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
