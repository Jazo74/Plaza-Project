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
                Menu();
                loop = Choose();
            }
        }
        void Menu()
        {
            Console.Clear();
            Console.WriteLine("option 1");
            Console.WriteLine("option 2");
            Console.WriteLine("option 3");
            Console.WriteLine("option 4");
            Console.WriteLine("option 5");
            Console.WriteLine("option 6");
            Console.WriteLine("option 7");
            Console.WriteLine("option 8");
            Console.WriteLine("option 9");
            Console.WriteLine("option 0");
            Console.WriteLine();
        }
        bool Choose()
        {

        }
    }
}
