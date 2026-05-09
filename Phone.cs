using System;
using System.Collections.Generic;
using System.Text;

namespace MobileShopInventory
{
    class Phone
    {
        private string brand;
        private string model;
        private string storage;
        private double price;
        private int stock;
        public string Brand
        {
            get { return brand; }
            set { brand = value; }
        }
        public string Model
        {
            get { return model; }
            set { model = value; }
        }
        public string Storage
        {
            get { return storage; }
            set { storage = value; }
        }
        public double Price
        {
            get { return price; }
            set { if (value > 0) price = value; }
        }
        public int Stock
        {
            get { return stock; }
            set { if (value >= 0) stock = value; }
        }
        public Phone(string brand, string model, string storage, double price, int stock)
        {
            Brand = brand;
            Model = model;
            Storage = storage;
            Price = price;
            Stock = stock;
        }
        public virtual void DisplayInfo()
        {
            Console.WriteLine($"Brand: {Brand}, Model: {Model}, Storage: {Storage}, Price: ${Price}, Stock: {Stock}");
        }
    }
}
