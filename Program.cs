using System;
using System.Collections.Generic;
using System.IO;

namespace tovari
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> stuff = new List<string>() { "banan", "iphone_12", "burger", "apple", "dog", "car", "tv", "mouse", "cap", "hoodie", "iphone_13_pro" };
            List<string> ShoppingBasket = new List<string>() { };
            bool program = true;

            while (program)
            {
                string item;
                Console.WriteLine("Write one of case below");
                string choise = Console.ReadLine();
                int NumofOrder = 1;

                switch (choise.ToLower())
                {
                    case "add":
                        {
                            Console.Clear();

                            if (ShoppingBasket.Count > 10)
                            {
                                Console.WriteLine("Your Shopping basket is overloaded");
                                continue;
                            }

                            ShowItemes(stuff, "current katalog include: ");
                            Console.WriteLine("Chose item which you want to buy");

                            item = Console.ReadLine();

                            if (stuff.Contains(item))
                            {
                                ShoppingBasket.Add(item);
                                stuff.Remove(item);
                            }
                            break;
                        }

                    case "remove":
                        {
                            Console.Clear();
                            ShowItemes(ShoppingBasket, " what do you want to remove from your Shopping basket : ");
                            item = Console.ReadLine();

                            if (ShoppingBasket.Contains(item))
                            {
                                stuff.Add(item);
                                ShoppingBasket.Remove(item);
                            }
                            break;
                        }

                    case "confirm":
                        {
                            Console.Clear();
                            Console.WriteLine("Your order is confirmed");

                            string msg = "";

                            foreach (string it in ShoppingBasket)
                            {
                                stuff.Add(it);
                                msg += it + "\n";
                            }

                            ShoppingBasket.Clear();

                            File.AppendAllText(@"C:\Users\Admin\source\repos\tovar\tovar\ds.txt", " " + "num od your order is: " + NumofOrder + " \n" + msg);
                            NumofOrder++;
                            Console.WriteLine("Press any button if you want to continue");
                            Console.ReadKey();

                            break;
                        }

                    default:
                        break;
                }
            }

            void ShowItemes(List<string> list, string b)
            {
                Console.WriteLine(b);

                foreach (string it in list)
                {
                    Console.WriteLine(it);
                }

                Console.WriteLine("------------------------------------------------");
            }
        }
    }
}
