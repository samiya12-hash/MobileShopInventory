using System;
using System.Collections.Generic;
using System.Text;

namespace MobileShopInventory
{
    internal class SalesRecord
    {
        public string CustomerName { get; set; }
        public string PhoneModel { get; set; }
        public int Quantity { get; set; }
        public double TotalPrice { get; set; }
        public SalesRecord(string customerName, string phoneModel, int quantity, double totalPrice)
        {
            CustomerName = customerName;
            PhoneModel = phoneModel;
            Quantity = quantity;
            TotalPrice = totalPrice;
        }
        public void ShowSale()
        {
            Console.WriteLine("-------------------------");
            Console.WriteLine($"Customer Name : {CustomerName}");
            Console.WriteLine($"Phone Model   : {PhoneModel}");
            Console.WriteLine($"Quantity      : {Quantity}");
            Console.WriteLine($"Total Price   : {TotalPrice} BDT");
        }

    }
}
