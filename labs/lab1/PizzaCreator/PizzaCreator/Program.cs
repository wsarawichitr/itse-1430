/*
 * William Sarawichitr
 * ITSE-1430
 * Spring 2020
 * PizzaCreator
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaCreator
{
    class Program
    {
        static void Main ( string[] args )
        {
            DisplayInfo();

            var done = false;
            do
            {
                switch (DisplayMenu())
                {
                    case Command.Add: AddOrder(); break;
                    case Command.Display: DisplayOrder(); break;
                    case Command.Modify: ModifyOrder(); break;
                    case Command.Quit: done = true; break;
                };
            } while (!done);

        }

        private static void DisplayInfo()
        {
            Console.WriteLine("William Sarawichitr");
            Console.WriteLine("ITSE-1430");
            Console.WriteLine("Spring 2020");
            Console.WriteLine("Pizza Creator");
        }
        enum Command
        {
            Quit = 0,
            Add = 1,
            Display = 2,
            Modify = 3
        }

        static string size;
        static bool bacon = false;
        static bool ham = false;
        static bool pepperoni = false;
        static bool sausage = false;
        static bool blackOlives = false;
        static bool mushrooms = false;
        static bool onions = false;
        static bool peppers = false;
        static string sauce;
        static string cheese;
        static string delivery;

        private static Command DisplayMenu()
        {
            Console.WriteLine("\nA)dd new order");
            Console.WriteLine("D)isplay order");
            Console.WriteLine("M)odify order");
            Console.WriteLine("Q)uit");

            do
            {
                var input = Console.ReadLine();
                switch (input.ToLower())
                {
                    case "a": return Command.Add;
                    case "d": return Command.Display;
                    case "m": return Command.Modify;
                    case "q": return Command.Quit;

                    default: Console.WriteLine("Invalid option"); break;
                }
            } while (true);
            
        }

        private static void AddOrder ()
        {
            if (!String.IsNullOrEmpty(size))
            {
                Console.WriteLine("There is already an existing order. Overwrite? (Y/N)");
                string input;
                do
                {
                    input = Console.ReadLine();
                    if (input.ToLower() == "y")
                    {
                        size = "";
                        bacon = false;
                        ham = false;
                        pepperoni = false;
                        sausage = false;
                        blackOlives = false;
                        mushrooms = false;
                        onions = false;
                        peppers = false;
                        sauce = "";
                        cheese = "";
                        delivery = "";
                    } else if (input.ToLower() == "n")
                        ;
                    else
                        Console.WriteLine("Not a valid input");

                } while (input.ToLower() != "y" && input.ToLower() != "n");
            }
            else
            {
                SelectSize();
                SelectMeats();
                SelectVegetables();
                sauce = SelectSauce();
                cheese = SelectCheese();
                delivery = SelectDelivery();

                DisplayOrder();
            }
            
        }

        private static void SelectSize ()
        {
            Console.WriteLine("\nSize (one is required)");
            Console.WriteLine("S)mall ($5)");
            Console.WriteLine("M)edium ($6.25)");
            Console.WriteLine("L)arge ($8.75)");

            string input;
            do
            {
                input = Console.ReadLine();
                switch (input.ToLower())
                {
                    case "s": size = "Small Pizza"; break;
                    case "m": size = "Medium Pizza"; break;
                    case "l": size = "Large Pizza"; break;

                    default: Console.WriteLine("Not a valid option"); break;
                }
            } while (input.ToLower() != "s" && input.ToLower() != "m" && input.ToLower() != "l");
        }

        private static void SelectMeats()
        {
            Console.WriteLine("\nMeats (Zero or more. Each option is $0.75 extra. You can select or unselect the options until done)");
            Console.WriteLine("B)acon");
            Console.WriteLine("H)am");
            Console.WriteLine("P)epperoni");
            Console.WriteLine("S)ausage");
            Console.WriteLine("D)one");

            var done = false;
            do
            {
                var input = Console.ReadLine();
                switch (input.ToLower())
                {
                    case "b": bacon = !bacon; break;
                    case "h": ham = !ham; break;
                    case "p": pepperoni = !pepperoni; break;
                    case "s": sausage = !sausage; break;
                    case "d": done = true; break;

                    default: Console.WriteLine("Not a valid option"); break;
                }
            } while (!done);
        }

        private static void SelectVegetables ()
        {
            Console.WriteLine("\nVegetables (Zero or more. Each option is $0.50 extra. You can select or unselect the options until done");
            Console.WriteLine("B)lack Olives");
            Console.WriteLine("M)ushrooms");
            Console.WriteLine("O)nions");
            Console.WriteLine("P)eppers");
            Console.WriteLine("D)one");

            var done = false;
            do
            {
                var input = Console.ReadLine();
                switch (input.ToLower())
                {
                    case "b": blackOlives = !blackOlives; break;
                    case "m": mushrooms = !mushrooms; break;
                    case "o": onions = !onions; break;
                    case "p": peppers = !peppers; break;
                    case "d": done = true; break;

                    default: Console.WriteLine("Not a valid option"); break;
                }
            } while (!done);
        }

        private static string SelectSauce ()
        {
            Console.WriteLine("\nSauce (one is required)");
            Console.WriteLine("T)raditional ($0)");
            Console.WriteLine("G)arlic ($1)");
            Console.WriteLine("O)regano ($1)");

            do
            {
                var input = Console.ReadLine();
                switch (input.ToLower())
                {
                    case "t": return "Traditional";
                    case "g": return "Garlic";
                    case "o": return "Oregano";

                    default: Console.WriteLine("Not a valid option"); break;
                }
            } while (true);

        }

        private static string SelectCheese ()
        {
            Console.WriteLine("\nCheese (one is required)");
            Console.WriteLine("R)egular ($0)");
            Console.WriteLine("E)xtra ($2.50)");

            do
            {
                var input = Console.ReadLine();
                switch (input.ToLower())
                {
                    case "r": return "Regular";
                    case "e": return "Extra";

                    default: Console.WriteLine("Not a valid option"); break;
                }
            } while (true);
        }

        private static string SelectDelivery ()
        {
            Console.WriteLine("\nDelivery (one is required)");
            Console.WriteLine("T)ake Out ($0)");
            Console.WriteLine("D)elivery ($2.50)");

            do
            {
                var input = Console.ReadLine();
                switch (input.ToLower())
                {
                    case "t": return "Take Out";
                    case "d": return "Delivery";

                    default: Console.WriteLine("Not a valid option"); break;
                }
            } while (true);
        }

        private static int SelectQuantity()
        {
            do
            {
                Console.Write("How many? ");
                var input = Console.ReadLine();

                if (Int32.TryParse(input, out var value))
                {
                    if (value >= 0)
                        return value;
                }

                Console.WriteLine("Value must be zero or greater");
            } while (true);
        }

        private static void DisplayOrder ()
        {
            double total = 0;
            if(String.IsNullOrEmpty(size))
                Console.WriteLine("Error. There is no existing order");
            else
            {
                Console.Write("\n" + size.PadRight(20, ' '));
                if (size == "Small Pizza")
                {
                    Console.WriteLine("$5.00");
                    total += 5.00;
                } else if (size == "Medium Pizza")
                {
                    Console.WriteLine("$6.25");
                    total += 6.25;
                } else
                {
                    Console.WriteLine("8.75");
                    total += 8.75;
                }
            }

            Console.Write(delivery.PadRight(20, ' '));
            if (delivery == "Delivery")
            {
                Console.WriteLine("$2.50");
                total += 2.50;
            } 
            else
                Console.WriteLine();

            Console.WriteLine("Meats");
            if(bacon)
            {
                Console.WriteLine("   Bacon            $0.75");
                total += 0.75;
            }
            if (ham)
            {
                Console.WriteLine("   Ham              $0.75");
                total += 0.75;
            }
            if (pepperoni)
            {
                Console.WriteLine("   Pepperoni        $0.75");
                total += 0.75;
            }
            if (sausage)
            {
                Console.WriteLine("   Sausage          $0.75");
                total += 0.75;
            }

            Console.WriteLine("Vegetables");
            if (blackOlives)
            {
                Console.WriteLine("   Black olives     $0.50");
                total += 0.50;
            }
            if (mushrooms)
            {
                Console.WriteLine("   Mushrooms        $0.50");
                total += 0.50;
            }
            if (onions)
            {
                Console.WriteLine("   Onions           $0.50");
                total += 0.50;
            }
            if (peppers)
            {
                Console.WriteLine("   Peppers          $0.50");
                total += 0.50;
            }

            Console.WriteLine("Sauce");
            Console.Write("  " + sauce.PadRight(18, ' '));
            if (sauce == "Traditional")
                Console.WriteLine();
            else if (sauce == "Garlic")
            {
                Console.WriteLine("$1.00");
                total += 1.00;
            }
            else
            {
                Console.WriteLine("$1.00");
                total += 1.00;
            }

            if (cheese == "Extra")
            {
                Console.WriteLine("Cheese");
                Console.Write("  " + cheese.PadRight(18, ' '));
                Console.WriteLine("$1.25");
                total += 1.25;
            }


            Console.WriteLine("".PadLeft(25, '-'));
            Console.Write("Total".PadRight(20));
            Console.WriteLine("$" + String.Format("{0:0.00}", total));
        }

        private static void ModifyOrder ()
        {
            if (!String.IsNullOrEmpty(size))
            {
                DisplayOrder();

                SelectSize();
                SelectMeats();
                SelectVegetables();
                sauce = SelectSauce();
                cheese = SelectCheese();
                delivery = SelectDelivery();

                DisplayOrder();
            } else
                Console.WriteLine("There is no existing order");
        }



    }
}

