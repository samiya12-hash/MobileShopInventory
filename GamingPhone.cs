using System;
using System.Collections.Generic;
using System.Text;

namespace MobileShopInventory
{
    internal class GamingPhone:SmartPhone
    {
            private int refreshRate;
            public int RefreshRate
            {
                get { return refreshRate; }
                set
                {
                    if (value > 0)
                        refreshRate = value;
                }
            }
            public GamingPhone(string brand, string model, string storage, double price, int stock, int cameraMP, int refreshRate)
                : base(brand, model, storage, price, stock, cameraMP)
            {
                RefreshRate = refreshRate;
            }

            
            public override void DisplayInfo()
            {
                base.DisplayInfo();
                Console.WriteLine($"Refresh Rate : {RefreshRate} Hz");
                Console.WriteLine($"Type    : Gaming Phone");
            }
        }
}
