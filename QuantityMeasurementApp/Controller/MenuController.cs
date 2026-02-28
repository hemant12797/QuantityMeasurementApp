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
                Console.WriteLine("\n--- Quantity Measurement UC6 ---");
                Console.WriteLine("1. Equality Check");
                Console.WriteLine("2. Convert");
                Console.WriteLine("3. Add");
                Console.WriteLine("4. Exit");
                Console.Write("Enter choice: ");

                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        RunEquality();
                        break;

                    case 2:
                        RunConversion();
                        break;

                    case 3:
                        RunAddition();
                        break;

                    case 4:
                        return;

                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }

        private void RunEquality()
        {
            Console.Write("Enter first value: ");
            double v1 = Convert.ToDouble(Console.ReadLine());
            LengthUnit u1 = AskUnit();

            Console.Write("Enter second value: ");
            double v2 = Convert.ToDouble(Console.ReadLine());
            LengthUnit u2 = AskUnit();

            var q1 = new QuantityLength(v1, u1);
            var q2 = new QuantityLength(v2, u2);

            Console.WriteLine($"Equal: {q1.Equals(q2)}");
        }

        private void RunConversion()
        {
            Console.Write("Enter value: ");
            double value = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Select source unit:");
            LengthUnit from = AskUnit();

            Console.WriteLine("Select target unit:");
            LengthUnit to = AskUnit();

            double result = QuantityLength.Convert(value, from, to);

            Console.WriteLine($"Result: {result}");
        }

        private void RunAddition()
        {
            Console.Write("Enter first value: ");
            double v1 = Convert.ToDouble(Console.ReadLine());
            LengthUnit u1 = AskUnit();

            Console.Write("Enter second value: ");
            double v2 = Convert.ToDouble(Console.ReadLine());
            LengthUnit u2 = AskUnit();

            var q1 = new QuantityLength(v1, u1);
            var q2 = new QuantityLength(v2, u2);

            var result = QuantityLength.Add(q1, q2);

            Console.WriteLine($"Result: {result}");
        }

        private LengthUnit AskUnit()
        {
            Console.WriteLine("1. FEET");
            Console.WriteLine("2. INCH");
            Console.WriteLine("3. YARD");
            Console.WriteLine("4. CENTIMETER");
            Console.Write("Enter unit: ");

            int choice = Convert.ToInt32(Console.ReadLine());
            return (LengthUnit)(choice - 1);
        }
    }
}