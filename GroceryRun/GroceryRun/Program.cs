using System;
using System.Collections.Generic;

namespace GroceryRun
{
    class Program
    {
        static void Main(string[] args)
        {
            // create store
            var store = LoadStore();

            // make new receipt and total
            var receipt = new Dictionary<string, decimal>();
            decimal total = 0;

            Console.WriteLine();

            // purchase items and add them to receipt | sum up total
            PurchaseItem(store, receipt, total);

            Console.WriteLine();
            PrintReceipt(receipt);
        }



        public static Dictionary<string, decimal> LoadStore()
        {
            var store = new Dictionary<string, decimal>();

            bool loading = true;
            while (loading)
            {
                Console.Clear();

                // get item name
                Console.Write("Item: ");
                string item = Console.ReadLine();

                // get item price
                Console.Write("Price: ");
                decimal price = Convert.ToDecimal(Console.ReadLine());

                store.Add(item, price);

                // ask if user wants to add another item to store
                Console.Write("Add another item? Hit 'y' for yes or anything else for no: ");
                string res = Console.ReadLine();

                // if they choose anything but 'y', then break from the loop
                if (res != "y")
                    loading = false;
            }

            return store;
        }
        public static void PurchaseItem(Dictionary<string, decimal> store, Dictionary<string, decimal> receipt, decimal total)
        {
            bool shopping = true;
            while (shopping)
            {
                Console.Clear();
                Console.WriteLine("Choose from the following list by typing the item name: ");

                // print out all items in store and format their values
                foreach (var item in store)
                    Console.WriteLine($"{item.Key} - {string.Format("{0:C}", item.Value)}");

                // get selection
                string selected = Console.ReadLine();

                // if selected item has been previously selected
                if (receipt.ContainsKey(selected))
                    receipt[selected] = receipt[selected] + receipt[selected];
                else
                    receipt.Add(selected, store[selected]);

                // add selected item's price to total price
                total += store[selected];

                Console.Write("Would you like to purchase another item? Hit 'y' for yes or anything else for no: ");

                string res = Console.ReadLine();

                // if user does not want to purchase another item
                if (res != "y")
                {
                    // add total to end of receipt
                    receipt.Add("Total", total);
                    shopping = false;
                }
            }
        }

        public static void PrintReceipt(Dictionary<string, decimal> receipt)
        {
            Console.WriteLine("Thanks for shopping!");
            Console.WriteLine("Your Receipt:");

            // print out all items in receipt and format their values
            foreach (var item in receipt)
                Console.WriteLine($"{item.Key} - {string.Format("{0:C}", item.Value)}");
        }
    }
}
