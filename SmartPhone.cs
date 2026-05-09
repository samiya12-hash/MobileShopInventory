using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace MobileShopInventory
{
    internal class SmartPhone:Phone
    {
        private int cameraMegapixels;
        public int CameraMegapixels
        {
            get { return cameraMegapixels; }
            set { if(value>0)cameraMegapixels = value; }
        }
        public SmartPhone(string brand,string model,string storage,double price,int stock,int cameraMegapixels):base(brand, model, storage, price, stock)
        {
            this.CameraMegapixels = cameraMegapixels;
        }
        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"Camera  : {cameraMegapixels} MP");
            Console.WriteLine($"Type    : Smartphone");
        }
    }
}
