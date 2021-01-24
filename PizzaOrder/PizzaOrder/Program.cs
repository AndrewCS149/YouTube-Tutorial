using System;

namespace PizzaOrder
{
    internal class Program
    {
        /*
               Pizza Order Exercise:

                  Write a console application that will send a friendly greetings to the user.
                  Ask the user how many small, medium and large pizzas they would like.
                  Use those values to calculate a subtotal price based on the value below.
                  If the user spends 100 dollars or more they receive a 20% discount. If they spend
                  50 dollars or more they receive a 10% discount. If they spend less than 50 dollars
                  they receive no discount. AFTER the discount is applied, then apply a 7% sales tax.
                  Then print out a receipt that contains the purchasers name, how many small, medium
                  and large pizzas they ordered and the overall total.

                 *NOTE*
                 You MUST convert the captured user input into an integer. User input is always compiled
                 as strings unless converted. Example:

                    int number = int.Parse(Console.ReadLIne());

                 There should be four methods:

                   1. A method to calculate the subtotal (not taxes or discounts applied)
                   2. A method to apply the discount
                   3. A method to apply the sales tax
                   4. A method to print out the receipt

                  Pizza Prices:

                      small - $8
                      medium - $12
                      large - $14

                  Discounts:

                      Spend over $100 - 20%
                      Spend over $50 - 10%

                  Tax - 7%

                   HINTS

                   1. Subtotal method should have three parameters:
                       - small pizza count
                       - medium pizza count
                       - large pizza count

                   2. Discount method should have one parameter: the subtotal

                   3. The sales tax method should have one parameter: the subtotal after the discount applied

                   4. The print receipt method should have 4 parameters:
                       - small pizza count
                       - medium pizza count
                       - large pizza count
                       - overall total

               */

        private static void Main(string[] args)
        {
            // Greet user and ask for name
            Console.Write("Welcome! can I please have your name? ");
            string name = Console.ReadLine();

            Console.WriteLine($"Hello {name}! How may I assist you today?");

            // Take orders and convert to ints
            Console.Write("Small Pizzas: ");
            int sm = int.Parse(Console.ReadLine());

            Console.Write("Medium Pizzas: ");
            int med = int.Parse(Console.ReadLine());

            Console.Write("Large Pizzas: ");
            int lg = int.Parse(Console.ReadLine());

            // calculate totals
            double subTotal = CalcOrder(sm, med, lg);
            double discountTotal = ApplyDiscount(subTotal);
            double total = ApplyTax(discountTotal);

            // Show receipt
            Console.WriteLine();
            PrintReceipt(name, total, sm, med, lg);
        }

        public static double CalcOrder(int sm, int med, int lg)
        {
            int smTotal = 8 * sm;
            int medTotal = 12 * med;
            int lgTotal = 14 * lg;

            return smTotal + medTotal + lgTotal;
        }

        public static double ApplyTax(double total)
        {
            return total * 1.07;
        }

        public static double ApplyDiscount(double total)
        {
            if (total >= 100)
                total *= 0.8;
            else if (total >= 50)
                total *= 0.9;

            return total;
        }

        public static void PrintReceipt(string name, double total, int sm, int med, int lg)
        {
            Console.WriteLine("Thank you for order!");

            Console.WriteLine();
            Console.WriteLine($"Name : {name}");
            Console.WriteLine();

            if (sm > 0)
                Console.WriteLine($"Small Pizza x{sm}");

            if (med > 0)
                Console.WriteLine($"Medium Pizza x{med}");

            if (lg > 0)
                Console.WriteLine($"Large Pizza x{lg}");

            Console.WriteLine($"Total : ${total}");

            // format currency
            //Console.WriteLine($"Total : {formatTotal}");
        }
    }
}