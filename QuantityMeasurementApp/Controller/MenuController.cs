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
                Console.WriteLine("\n--- Quantity Measurement UC7 ---");
                Console.WriteLine("1. Equality Check");
                Console.WriteLine("2. Convert");
                Console.WriteLine("3. Add (Default First Unit)");
                Console.WriteLine("4. Add (Explicit Target Unit)");
                Console.WriteLine("5. Exit");
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
                        RunAdditionDefault();
                        break;
                    case 4:
                        RunAdditionExplicit();
                        break;
                    case 5:
                        return;
                }
            }
        }

        private void RunAdditionExplicit()
        {
            var q1 = ReadQuantity("First");
            var q2 = ReadQuantity("Second");

            Console.WriteLine("Select Target Unit:");
            LengthUnit target = AskUnit();

            var result = QuantityLength.Add(q1, q2, target);

            Console.WriteLine($"Result: {result}");
        }

        private void RunAdditionDefault()
        {
            var q1 = ReadQuantity("First");
            var q2 = ReadQuantity("Second");

            var result = QuantityLength.Add(q1, q2);

            Console.WriteLine($"Result: {result}");
        }

        private void RunEquality()
        {
            var q1 = ReadQuantity("First");
            var q2 = ReadQuantity("Second");

            Console.WriteLine($"Equal: {q1.Equals(q2)}");
        }

        private void RunConversion()
        {
            Console.Write("Enter value: ");
            double value = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Source Unit:");
            LengthUnit from = AskUnit();

            Console.WriteLine("Target Unit:");
            LengthUnit to = AskUnit();

            double result = QuantityLength.Convert(value, from, to);

            Console.WriteLine($"Result: {result}");
        }

        private QuantityLength ReadQuantity(string label)
        {
            Console.Write($"{label} Value: ");
            double value = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine($"{label} Unit:");
            LengthUnit unit = AskUnit();

            return new QuantityLength(value, unit);
        }

        private LengthUnit AskUnit()
        {
            Console.WriteLine("1. FEET");
            Console.WriteLine("2. INCH");
            Console.WriteLine("3. YARD");
            Console.WriteLine("4. CENTIMETER");

            int choice = Convert.ToInt32(Console.ReadLine());
            return (LengthUnit)(choice - 1);
        }
    }
}