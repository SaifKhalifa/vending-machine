using System;
using System.Collections.Generic;

namespace VendningMachine.App
{
    internal class SnackSlot
    {
        public int slotNumber;
        public string itemName;
        public float price;
        public Stack<Item> stock;

        public SnackSlot(int number, string name, float itemPrice, int quantity)
        {
            slotNumber = number;
            itemName = name;
            price = itemPrice;
            stock = new Stack<Item>();

            for (int i = 0; i < quantity; i++)
            {
                stock.Push(new Item(name, itemPrice, 1));
            }
        }

        public bool IsEmpty()
        {
            return stock.Count == 0;
        }

        public Item Dispense()
        {
            return stock.Pop();
        }
    }
}
