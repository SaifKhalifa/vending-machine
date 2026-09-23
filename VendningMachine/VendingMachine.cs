using System;
using System.Collections.Generic;
using System.Linq;

namespace VendningMachine.App
{
    internal class VendingMachine
    {
        public float insertedAmount;

        public VendingMachine()
        {
            insertedAmount = 0;
        }

        public void InsertMoney(float amount)
        {
            insertedAmount += amount;
            Console.WriteLine($"Inserted: {amount}");
            Console.WriteLine($"Total inserted so far: {insertedAmount}");
        }

        public float GiveChange(float price)
        {
            float change = insertedAmount - price;
            insertedAmount = 0;

            if (change <= 0)
                return 0;

            List<float> changeCoins = new List<float>();
            float remainder = CoinSlot.ValidateMoney(change, changeCoins);

            if (remainder == -1)
            {
                Console.WriteLine("Could not make exact change for this amount!");
                return change;
            }

            Console.WriteLine($"Your change is: {change}");
            Console.WriteLine("Given as:");

            Dictionary<float, int> frequencies = new Dictionary<float, int>();

            foreach (float coin in changeCoins)
            {
                if (frequencies.ContainsKey(coin))
                    frequencies[coin] = frequencies[coin] + 1;
                else
                    frequencies[coin] = 1;
            }

            foreach (KeyValuePair<float, int> pair in frequencies)
            {
                float denomination = pair.Key;
                int count = pair.Value;

                if (!CoinSlot.IsAcceptedDenomination(denomination))
                {
                    Console.WriteLine($"WARNING: {denomination} is not an accepted denomination!");
                    continue;
                }

                Console.WriteLine($"{count} coin(s) of ${denomination} = ${count * denomination}");
            }

            return change;
        }
    }
}
