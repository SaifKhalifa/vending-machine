using System;
using System.Collections.Generic;
using System.IO;

namespace VendningMachine.App
{
    internal class SnackMachine : VendingMachine
    {
        public List<SnackSlot> slots;

        public SnackMachine(string dataFilePath) : base()
        {
            slots = new List<SnackSlot>();
            LoadItems(dataFilePath);
        }

        private void LoadItems(string filePath)
        {
            string[] lines = File.ReadAllLines(filePath);
            int number = 1;

            foreach (string line in lines)
            {
                if (string.IsNullOrWhiteSpace(line))
                    continue;

                string[] parts = line.Split(',');

                string name = parts[0];
                float price = float.Parse(parts[1]);
                int quantity = int.Parse(parts[2]);

                slots.Add(new SnackSlot(number, name, price, quantity));
                number++;
            }
        }

        public void ShowMenu()
        {
            Console.WriteLine("\n----- SNACK MENU -----");

            foreach (SnackSlot slot in slots)
            {
                string status = slot.IsEmpty() ? "OUT OF STOCK" : slot.stock.Count + " left";
                Console.WriteLine($"[{slot.slotNumber}] {slot.itemName} - ${slot.price} ({status})");
            }

            Console.WriteLine("-----------------------\n");
        }

        public SnackSlot? FindSlot(int number)
        {
            foreach (SnackSlot slot in slots)
            {
                if (slot.slotNumber == number)
                    return slot;
            }

            return null;
        }

        public void Purchase(int slotNumber)
        {
            SnackSlot? slot = FindSlot(slotNumber);

            if (slot == null)
            {
                Console.WriteLine("Invalid selection!");
                return;
            }

            if (slot.IsEmpty())
            {
                Console.WriteLine($"Sorry, {slot.itemName} is out of stock!");
                return;
            }

            Console.WriteLine($"{slot.itemName} selected. Price: ${slot.price}");
            Console.WriteLine("Please insert money (type 'cancel' to stop):");

            while (insertedAmount < slot.price)
            {
                Console.Write("Insert amount: ");
                string? input = Console.ReadLine();

                if (input != null && input.ToLower() == "cancel")
                {
                    Console.WriteLine($"Purchase cancelled. Returning {insertedAmount}.");
                    insertedAmount = 0;
                    return;
                }

                float amount;

                if (float.TryParse(input, out amount) && amount > 0)
                {
                    InsertMoney(amount);
                }
                else
                {
                    Console.WriteLine("Invalid amount, try again.");
                }
            }

            Item dispensedItem = slot.Dispense();
            Console.WriteLine($"Dispensing: {dispensedItem.itemName}");

            GiveChange(slot.price);
        }
    }
}
