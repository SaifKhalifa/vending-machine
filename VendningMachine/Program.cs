using System.Security.Cryptography.X509Certificates;

namespace VendningMachine
{
    internal class Program
    {
        List<float> sumNumbers = new List<float>();
        static Dictionary<float, int> frequencies = new Dictionary<float, int>();

        public void CountFreq()
        {
            foreach (float value in sumNumbers)
            {
                if (frequencies.ContainsKey(value))
                {
                    frequencies[value] = frequencies[value] + 1;
                }
                else
                {
                    frequencies[value] = 1;
                }
            }
        }

        static void Main(string[] args)
        {
            //float value = 211.5f, temp;

            //Console.WriteLine(ValidateMoney(value, numbers));

            //Console.WriteLine("The value can be summed up by: ");

            //foreach (var item in frequencies)
            //{
            //    Console.WriteLine($"x{item.Key} [{item.Value}]");
            //}
        }
    }
}
