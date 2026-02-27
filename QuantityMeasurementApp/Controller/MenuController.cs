using System;
using QuantityMeasurementApp.Model;

namespace QuantityMeasurementApp.Controller
{
    public class MenuController
    {
        public void Run()
        {
            while (true)
            {
                Console.WriteLine("\n--- Quantity Measurement UC4 ---");
                Console.WriteLine("1. Compare Quantities");
                Console.WriteLine("2. Exit");
                Console.Write("Enter choice: ");

                int choice = Convert.ToInt32(Console.ReadLine());

                if (choice == 2)
                    return;

                Console.Write("Enter first value: ");
                double v1 = Convert.ToDouble(Console.ReadLine());
                LengthUnit u1 = AskUnit();

                Console.Write("Enter second value: ");
                double v2 = Convert.ToDouble(Console.ReadLine());
                LengthUnit u2 = AskUnit();

                QuantityLength q1 = new QuantityLength(v1, u1);
                QuantityLength q2 = new QuantityLength(v2, u2);

                Console.WriteLine($"Equal: {q1.Equals(q2)}");
            }
        }

        private LengthUnit AskUnit()
        {
            Console.WriteLine("Select Unit:");
            Console.WriteLine("1. Feet");
            Console.WriteLine("2. Inch");
            Console.WriteLine("3. Yard");
            Console.WriteLine("4. Centimeter");

            int u = Convert.ToInt32(Console.ReadLine());
            return (LengthUnit)(u - 1);
        }
    }
}