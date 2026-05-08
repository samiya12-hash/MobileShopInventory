using System;
using System.Collections.Generic;
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

    }
}
