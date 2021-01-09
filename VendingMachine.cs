using System;
using System.Collections.Generic;

namespace UCLANProject
{
    class VendingMachine
    {

        private readonly IDictionary<string, double> products = new Dictionary<string, double>();
        private double credits;

        public VendingMachine()
        {
            initializeProducts();
            credits = 0.00;
        }

        public double getCredits()
        {
            return credits;
        }

        private void initializeProducts()
        {
            products.Add("Chocolate Bar", 0.80);
            products.Add("Soda Can", 0.70);
            products.Add("Soda Bottle", 1.25);
            products.Add("Crisps", 0.50);
            products.Add("Cookies", 1.10);
        }

        public void addCredits()
        {
            Console.Write("Please enter how many credits you would like to add to your balance: ");
            credits += double.Parse(Console.ReadLine());
            Console.WriteLine("\n");
        }

        public void selectProduct()
        {
            displayProductMenu();
        }

        public void displayProductMenu()
        {
            int index = 1;
            const String dashline = "\n*******************************************************\n";
            Console.WriteLine("\n" + dashline);
            Console.WriteLine("Product".PadRight(20, ' ') + "Cost (Credits)".PadRight(50, ' '));
            Console.WriteLine(dashline);
            foreach (var item in products)
            {
                Console.WriteLine(index++ + ") " + item.Key.PadRight(20, ' ') + item.Value.ToString().PadRight(60, ' '));
            }
        }

        public void displayMainMenu()
        {
            const String dashline = "\n*******************************************************\n";
            const String headerMessage = "UCLAN Vending Machines LTD";
            const String mainMenu = "\nMAIN MENU\n\n";
            String addCredits = "1) Add Credits (current credits = " + credits + " )\n";
            const String selectProducts = "2) Select products\n";
            const String exit = "3) Exit\n";
            Console.WriteLine(dashline);
            Console.WriteLine(headerMessage);
            Console.WriteLine(dashline);
            Console.WriteLine(mainMenu);
            Console.WriteLine(addCredits);
            Console.WriteLine(selectProducts);
            Console.WriteLine(exit);
            Console.WriteLine(dashline);
            Console.Write("Please enter a choice: ");
        }

        static void Main(string[] args)
        {
            int choice;
            VendingMachine aVendingMachine = new VendingMachine();

            do
            {
                aVendingMachine.displayMainMenu();
                choice = int.Parse(Console.ReadLine());

                if (choice > 0 && choice < 4)
                {
                    switch (choice)
                    {
                        case 1:
                            aVendingMachine.addCredits();
                            break;
                        case 2:
                            aVendingMachine.selectProduct();
                            break;
                        case 3:
                            Console.WriteLine("Thank You");
                            break;
                        default:
                            Console.WriteLine("\nInvalid choice");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("\nInvalid choice. Choices can be (Between 1 to 3)\n");
                }

            } while (choice != 3);

        }
    }
}
