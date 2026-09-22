using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendningMachine.App
{
    internal class Item
    {
        public static short ID { get; private set; }
        public float price;
        public string itemName;
        public int quantiy;

        internal Item(string name, float itemPrice, int itemQuantity)
        {            
            if (ValidateItemInfo(name, itemPrice, itemQuantity))
            {
                if (ID == 0)
                    ID = 0;

                ID += 1;
                itemName = name;
                price = itemPrice;
                quantiy = itemQuantity;
            }
        }

        private bool ValidateItemInfo(string name, float itemPrice, int itemQuantity)
        {
            short whiteSpaceFlag = 0;

            foreach (char c in name)
            {
                if (char.IsWhiteSpace(c))
                {
                    whiteSpaceFlag++;
                }
                continue;
            }

            if (name == null || whiteSpaceFlag == name.Length)
            {
                Console.WriteLine("Item name cannot be empty!");
                return false;
            }
            else if (itemPrice < 0)
            {
                Console.WriteLine("Price cannot be less than zero '0'!");
                return false;
            }
            else if (itemQuantity < 0)
            {
                Console.WriteLine("Quantitiy cannot be less than zero '0'!");
                return false;
            }

            return true;
        }
    }
}
