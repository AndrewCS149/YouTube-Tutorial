using System;
using System.Collections.Generic;

namespace GroceryRun
{
    /*
    Grocery Run Exercise:

    Write a console application that will prompt a user to build a 'grocery store'
    containing item names and prices. 
    
    Then ask the user which items they would like to add to their cart. Make sure to 
    keep track of each item in the cart as well as their prices. 

    Keep a running total for the receipt.
    
    Use the cart to generate a receipt along with total price of the entire cart and 
    display it to the user. 
     
    
    Note - use dictionaries!


           store                     cart

    names    |   prices       names    |  prices
    -------------------       -------------------
      apple  | 1.25              apple |  2.50
      bacon  | 3.25              bacon |  3.25    
      bread  | 2.50                    |
             |                         |    
             |                         |    
             |                         |








     
    HINTS:
    total = 0

    CreateStore()
        store = new Dictionary()
        while()
        return store

    AddToCart(store, total)
        cart = new Dictionary()
        while()
        {
            add items to cart
            add to total
        }
        return cart

    PrintReceipt(cart)
        print out cart items

     */

    class Program
    {
        static void Main(string[] args)
        {
            decimal total = 0;

            // create store
            var store = CreateStore();

            Console.WriteLine();

            // purchase items and add them to receipt | sum up total
            var cart = AddToCart(store, total);

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
                string input = Console.ReadLine();

                // if they choose anything but 'y', then break from the loop
                if (input != "y")
                    loading = false;
            }

            return store;
        }
        public static Dictionary<string, decimal> AddToCart(Dictionary<string, decimal> store, decimal total)
        {
            var cart = new Dictionary<string, decimal>();

            bool shopping = true;
            while (shopping)
            {
                Console.Clear();
                Console.WriteLine("Add items to your cart from the following list by typing the item name: ");

                // print out all items in store and format their values
                foreach (var item in store)
                {
                    // format into US currency
                    string price = string.Format("{0:C}", item.Value);
                    Console.WriteLine($"{item.Key} - {price}");
                }

                // get selection
                string selected = Console.ReadLine();

                // if selected item has been previously selected
                if (cart.ContainsKey(selected))
                    cart[selected] = cart[selected] + store[selected];
                else
                    cart.Add(selected, store[selected]);

                // add selected item's price to total price
                total += store[selected];

                Console.Write("Would you like to purchase another item? Hit 'y' for yes or anything else for no: ");

                string input = Console.ReadLine();

                // if user does not want to purchase another item
                if (input != "y")
                {
                    // add total to end of receipt
                    cart.Add("Total", total);
                    shopping = false;
                }

            }
            return cart;
        }

        public static void PrintReceipt(Dictionary<string, decimal> cart)
        {
            Console.WriteLine("Thanks for shopping!");
            Console.WriteLine("Your Receipt:");

            // print out all items in receipt and format their values
            foreach (var item in cart)
            {
                // format into US currency
                string price = string.Format("{0:C}", item.Value);
                Console.WriteLine($"{item.Key} - {price}");
            }
        }
    }
}
