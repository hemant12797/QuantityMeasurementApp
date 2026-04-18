using System;

namespace QuantityMeasurementApp.FeetApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter first value:");
            double value1 = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Enter second value:");
            double value2 = Convert.ToDouble(Console.ReadLine());

            FeetApp1 Feet1 = new FeetApp1(value1);
            FeetApp1 Feet2 = new FeetApp1(value2);

            while (true)
            {
                Console.WriteLine("\nMenu:");
                Console.WriteLine("1. Check reference");
                Console.WriteLine("2. Check null or type");
                Console.WriteLine("3. Cast object safely");
                Console.WriteLine("4. Compare values");
                Console.WriteLine("5. Exit");

                Console.WriteLine("Enter choice:");
                int n = Convert.ToInt32(Console.ReadLine());

                switch (n)
                {
                    case 1:
                        Feet1.Reference(Feet2);
                        break;

                    case 2:
                        Feet1.NullCheck(Feet2);
                        break;

                    case 3:
                        Feet1.Cast(Feet2);
                        break;

                    case 4:
                        Feet1.Compare(Feet2);
                        break;

                    case 5:
                        Console.WriteLine("Thank you");
                        return;

                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }
            }
        }
    }
}