using System;
using System.Collections.Generic;

namespace GroceryRun
{
    /*
    Grocery Run Description:

    Write a console application that will prompt a user to build a 'grocery store'
    containing item names and prices. 

    Then ask the user which items they would like to add to their cart. make sure to 
    keep track of each item in the cart as well as their prices. 

    Keep a running total for the receipt.

    Use the cart to generate a receipt along with total price of the entire cart and 
    display it to the user. 
     

    Note - use dictionaries!




     
    HINTS:

    cart = new Dictionary()
    total = 0

    CreateStore()
        store = new Dictionary()
        while()
        return store

    PurchaseItems(store, cart, total)
        while()
        {
            add items to cart
            add to total
        }

    PrintReceipt(cart, total)
        print out cart items and total

     */

    class Program
    {
        static void Main(string[] args)
        {
            // create store
            var store = CreateStore();

            // make new receipt and total
            var cart = new Dictionary<string, decimal>();
            decimal total = 0;

            Console.WriteLine();

            // purchase items and add them to receipt | sum up total
            PurchaseItem(store, cart, total);

            Console.WriteLine();
            PrintReceipt(cart);
        }



        public static Dictionary<string, decimal> CreateStore()
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
        public static void PurchaseItem(Dictionary<string, decimal> store, Dictionary<string, decimal> cart, decimal total)
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
                if (cart.ContainsKey(selected))
                    cart[selected] = cart[selected] + cart[selected];
                else
                    cart.Add(selected, store[selected]);

                // add selected item's price to total price
                total += store[selected];

                Console.Write("Would you like to purchase another item? Hit 'y' for yes or anything else for no: ");

                string res = Console.ReadLine();

                // if user does not want to purchase another item
                if (res != "y")
                {
                    // add total to end of receipt
                    cart.Add("Total", total);
                    shopping = false;
                }
            }
        }

        public static void PrintReceipt(Dictionary<string, decimal> cart)
        {
            Console.WriteLine("Thanks for shopping!");
            Console.WriteLine("Your Receipt:");

            // print out all items in receipt and format their values
            foreach (var item in cart)
                Console.WriteLine($"{item.Key} - {string.Format("{0:C}", item.Value)}");
        }
    }
}
