using System;
using System.Collections.Generic;
using System.Linq;

namespace UCLANProject
{
    class VendingMachine
    {

        private readonly IDictionary<string, double> products = new Dictionary<string, double>();
        private double credits;
        private double subTotal;

        public VendingMachine()
        {
            initializeProducts();
            credits = 0.00;
            subTotal = 0.00;
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
            Console.Write("\nPlease enter how many credits you would like to add to your balance: ");
            credits += double.Parse(Console.ReadLine());
            Console.WriteLine("\n");
        }

        public void selectProduct()
        {
            int choice;
            do
            {
                displayProductMenu();
                choice = int.Parse(Console.ReadLine());
                if (choice == 6)
                {
                    break;
                }
                else
                {
                    if (choice > 0 && choice < 6)
                    {
                        String addCreditsChoice;
                        String productSelected = products.Keys.ToList().ElementAt(choice - 1);
                        subTotal += products[productSelected];

                        Console.WriteLine("\nYou have added " + productSelected + " to your selection");
                        Console.WriteLine("Your current sub-total = " + string.Format("{0:0.00}", subTotal) + " credits\n");
                        Console.Write("Do you want to add more products \n\n Please enter 'Y' for YES and 'N' for NO:");
                        addCreditsChoice = Console.ReadLine();

                        if (String.Compare(addCreditsChoice, "Y", true) == 0)
                        {
                            continue;
                        }
                        else
                        {
                            if (String.Compare(addCreditsChoice, "N", true) == 0)
                            {
                                if (manageCredits())
                                {
                                    checkOut();
                                    Console.WriteLine("\n\nThank you for buying with us");
                                }
                                else
                                {
                                    Console.WriteLine("\n\nSorry your purchase cannot be processed.");
                                }
                                break;
                            }
                            else
                            {
                                Console.WriteLine("\nInvalid choice!");
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid choice. Please enter a number between 1-6");
                    }
                }

            } while (true);

        }

        private bool manageCredits()
        {
            bool areCreditsManaged = false;
            do
            {
                if (areCreditsSufficient())
                {
                    areCreditsManaged = true;
                    break;
                }
                else
                {
                    String addCreditsChoice;
                    Console.WriteLine("\nYou have insufficent credits avaiable. You require more " + string.Format("{0:0.00}", (subTotal - credits)) + " credits.");
                    Console.Write("\nDo you want to add more credits? \nPlease enter 'Y' for YES and 'N' for NO:");

                    addCreditsChoice = Console.ReadLine();
                    if (String.Compare(addCreditsChoice, "Y", true) == 0)
                    {
                        addCredits();
                    }
                    else
                    {
                        if (String.Compare(addCreditsChoice, "N", true) == 0)
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("\nInvalid choice!");
                        }
                    }
                }

            } while (true);

            return areCreditsManaged;
        }

        private void checkOut()
        {
            const String dashline = "\n*******************************************************\n";
            Console.WriteLine(dashline);
            Console.WriteLine("Available Balance".PadRight(20, ' ') + " = " + string.Format("{0:0.00}", credits) + " credits");
            Console.WriteLine("Grand Total".PadRight(20, ' ') + " = " + string.Format("{0:0.00}", subTotal) + " credits");
            Console.WriteLine(dashline);
            Console.WriteLine("Your new Balance".PadRight(20, ' ') + " = " + string.Format("{0:0.00}", (credits - subTotal)) + " credits");
            Console.WriteLine(dashline);
            credits -= subTotal;
            subTotal = 0.00;
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

            Console.WriteLine(index + ") Return to Main Menu and Exit".PadRight(20, ' '));
            Console.Write("Please enter a number to select a Product: ");
        }

        public void displayMainMenu()
        {
            const String dashline = "\n*******************************************************\n";
            const String headerMessage = "UCLAN Vending Machines LTD";
            const String mainMenu = "\nMAIN MENU\n\n";
            String addCredits = "1) Add Credits (current credits = " + string.Format("{0:0.00}", credits) + " )\n";
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
            Console.Write("\nPlease enter a choice: ");
        }

        private bool areCreditsSufficient()
        {
            return (credits - subTotal) > 0;
        }

        static void Main(string[] args)
        {
            int choice;
            VendingMachine aVendingMachine = new VendingMachine();

            do
            {
                aVendingMachine.displayMainMenu();
                choice = int.Parse(Console.ReadLine());
                if (choice == 3)
                {
                    break;
                }
                else
                {
                    if (choice > 0 && choice < 3)
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
                }

            } while (true);

        }
    }
}
