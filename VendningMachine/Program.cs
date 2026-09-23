using VendningMachine.App;

namespace VendningMachine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string dataFile = Path.Combine(AppContext.BaseDirectory, "items.txt");
            SnackMachine machine = new SnackMachine(dataFile);

            Console.WriteLine("Welcome to the Snack Vending Machine!");

            bool running = true;

            while (running)
            {
                machine.ShowMenu();
                Console.Write("Enter a slot number to buy (or 'exit' to quit): ");
                string? input = Console.ReadLine();

                if (input != null && input.ToLower() == "exit")
                {
                    running = false;
                    continue;
                }

                int slotNumber;

                if (int.TryParse(input, out slotNumber))
                {
                    machine.Purchase(slotNumber);
                }
                else
                {
                    Console.WriteLine("Please enter a valid number.");
                }
            }

            Console.WriteLine("Goodbye!");
        }
    }
}
