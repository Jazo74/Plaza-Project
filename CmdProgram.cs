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
                    if (myPlaza.IsOpen())
                    {
                        Console.WriteLine("The plaza is open.");
                    }
                    else
                    {
                        Console.WriteLine("The plaza is close");
                    }
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
                            Console.WriteLine("Entering the shop.");
                            Thread.Sleep(1000);
                            MenuShop(myPlaza.FindShopByName(shopName));
                            shopbool = ChooseShop(myPlaza.FindShopByName(shopName));
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
            Console.WriteLine("Welcome the the " + shop.GetName() + " !");
            Console.WriteLine();
            Console.WriteLine("(1)  Is the shop open?");
            Console.WriteLine("(2)  Open the shop");
            Console.WriteLine("(3)  Close the shop");
            Console.WriteLine("(4)  List available products");
            Console.WriteLine("(5)  Find a product by name.");
            Console.WriteLine("(6)  Display the shop's owner");
            Console.WriteLine("(7)  Add new product to the shop");
            Console.WriteLine("(8)  Add existing products to the shop");
            Console.WriteLine("(9)  Buy a product by barcode");
            Console.WriteLine("(10) Buy multiple products by barcode");
            Console.WriteLine("(11) Check price by barcode");
            Console.WriteLine("(0)  Back to the main menu");
            Console.WriteLine();
        }
        bool ChooseShop(Shop shop)
        {
            string choice = AnyInput("Please choose an option...");
            switch (choice)
            {
                case "1": // is the shop open?
                    Console.Clear();
                    if (shop.IsOpen())
                    {
                        Console.WriteLine("The shop is open.");
                    }
                    else
                    {
                        Console.WriteLine("The shop is closed.");
                    }
                    AnyInput("Press any key to continue...");
                    return true;
                case "2": // open shop
                    Console.Clear();
                    shop.Open();
                    Console.WriteLine("The shop has just opened.");
                    Thread.Sleep(1000);
                    return true;
                case "3": // close shop
                    Console.Clear();
                    shop.Close();
                    Console.WriteLine("The shop has just closed.");
                    Thread.Sleep(1000);
                    return true;
                case "4": // list the products
                    Console.Clear();
                    try
                    {
                        foreach (Product product in shop.GetProducts())
                        {
                            Console.WriteLine(product.ToString());
                        }
                    }
                    catch (ShopIsClosedException)
                    {
                        Console.WriteLine("The shop is closed.");
                        Thread.Sleep(1000);
                    }
                    AnyInput("Press any key to continue...");
                    return true;
                case "5": // find a product by name
                    Console.Clear();
                    try
                    {
                        string productName = AnyInput("The name of the product: ");
                        Product product = shop.FindByName(productName);
                        Console.WriteLine(product.ToString());
                        AnyInput("Press any key to continue...");
                    }
                    catch (ShopIsClosedException)
                    {
                        Console.WriteLine("The shop is closed.");
                        Thread.Sleep(1000);
                    }
                    catch (NoSuchProductException)
                    {
                        Console.WriteLine("There is no such product with this name.");
                        Thread.Sleep(1000);
                    }
                    return true;
                case "6": // get the owner of the shop
                    Console.Clear();
                    Console.WriteLine(shop.GetOwner());
                    AnyInput("Press any key to continue...");
                    return true;
                case "7": // add new product
                    try
                    {
                        Console.Clear();
                        Console.WriteLine("(1) Add a new foodproduct");
                        Console.WriteLine("(2) Add a new clothing product");
                        while (true)
                        {
                            if (!shop.IsOpen()) { throw new ShopIsClosedException(); }
                            int input = IntInput("Choose an option...");
                            long barcode = LongInput("The barcode of the product: ");
                            string name = AnyInput("The name of the product: ");
                            string manufacturer = AnyInput("The manufacturer of the product: ");
                            if (input == 1)
                            {
                                int calories = IntInput("The calorie of the product: ");
                                DateTime bestBefore = DateTimeInput("The expiration date of the product: ");
                                FoodProduct foodProduct = new FoodProduct(barcode, name, manufacturer, calories, bestBefore);
                                int quantity = IntInput("The quantity of the product: ");
                                int price = IntInput("The price of the product: ");
                                shop.AddNewProduct(foodProduct, quantity, price);
                                Console.WriteLine("The new product has added to the shop.");
                                Thread.Sleep(1000);
                                break;
                            }
                            else if (input == 2)
                            {
                                string material = AnyInput("The material of the product: ");
                                string type = AnyInput("The type of the product: ");
                                ClothingProduct clothingProduct = new ClothingProduct(barcode, name, manufacturer, material, type);
                                int quantity = IntInput("The quantity of the product: ");
                                int price = IntInput("The price of the product: ");
                                shop.AddNewProduct(clothingProduct, quantity, price);
                                Console.WriteLine("The new product has added to the shop.");
                                Thread.Sleep(1000);
                                break;
                            }
                        }
                    }
                    catch (ShopIsClosedException)
                    {
                        Console.WriteLine("The shop is closed");
                        Thread.Sleep(1000);
                    }
                    catch (ProductAlreadyExistsException)
                    {
                        Console.WriteLine("The product is already exist");
                        Thread.Sleep(1000);
                    }
                    return true;
                case "8": // add existing product
                    Console.Clear();
                    try
                    {
                        if (!shop.IsOpen()) { throw new ShopIsClosedException(); }
                        long barcode = shop.FindByName(AnyInput("The name of the product")).GetBarcode();
                        int quantity = IntInput("The quantity");
                        shop.AddProduct(barcode, quantity);
                        Console.WriteLine("The product is added to the shop");
                        Thread.Sleep(1000);
                    }
                    catch (ShopIsClosedException)
                    {
                        Console.WriteLine("The shop is closed");
                        Thread.Sleep(1000);
                    }
                    catch (NoSuchProductException)
                    {
                        Console.WriteLine("There is no product with this name");
                        Thread.Sleep(1000);
                    }
                    return true;
                case "9": //Buy a product
                    Console.Clear();
                    try
                    {
                        if (!shop.IsOpen()) { throw new ShopIsClosedException(); }
                        long barcode = LongInput("The barcode of the product");
                        shop.BuyProduct(barcode);
                        Console.WriteLine("The product is bought from the shop");
                        Thread.Sleep(1000);
                    }
                    catch (ShopIsClosedException)
                    {
                        Console.WriteLine("The shop is closed");
                        Thread.Sleep(1000);
                    }
                    catch (NoSuchProductException)
                    {
                        Console.WriteLine("There is no product with this name");
                        Thread.Sleep(1000);
                    }
                    catch (OutOfStockException)
                    {
                        Console.WriteLine("The shop has run out of this product");
                        Thread.Sleep(1000);
                    }
                    return true;
                case "10": // Buy products
                    Console.Clear();
                    try
                    {
                        if (!shop.IsOpen()) { throw new ShopIsClosedException(); }
                        long barcode = LongInput("The barcode of the product");
                        int quantity = IntInput("The quantity");
                        shop.BuyProducts(barcode, quantity);
                        Console.WriteLine("The products are bought from the shop");
                        Thread.Sleep(1000);
                    }
                    catch (ShopIsClosedException)
                    {
                        Console.WriteLine("The shop is closed");
                        Thread.Sleep(1000);
                    }
                    catch (NoSuchProductException)
                    {
                        Console.WriteLine("There is no product with this name");
                        Thread.Sleep(1000);
                    }
                    catch (OutOfStockException)
                    {
                        Console.WriteLine("The shop has not enough from this product");
                        Thread.Sleep(1000);
                    }
                    return true;
                case "11": // Get the price
                    Console.Clear();
                    try
                    {
                        long barcode = LongInput("The barcode of the product");
                        Console.WriteLine("The price is: " + shop.GetPrice(barcode).ToString());
                        AnyInput("Press any key to continue...");
                    }
                    catch (ShopIsClosedException)
                    {
                        Console.WriteLine("The shop is closed");
                        Thread.Sleep(1000);
                    }
                    catch (NoSuchProductException)
                    {
                        Console.WriteLine("There is no product with this name");
                        Thread.Sleep(1000);
                    }
                    catch (OutOfStockException)
                    {
                        Console.WriteLine("The shop has not enough from this product");
                        Thread.Sleep(1000);
                    }
                    return true;
                case "0":
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
        public DateTime DateTimeInput(string inputMessage)
        {
            while (true)
            {
                Console.Write(inputMessage);
                DateTime date = new DateTime();
                string input = Console.ReadLine();
                if (DateTime.TryParse(input, out date))
                {
                    return DateTime.Parse(input);
                }
            }
        }
    }
}
