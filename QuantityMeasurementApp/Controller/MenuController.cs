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
                Console.WriteLine("\n--- Quantity Measurement UC5 ---");
                Console.WriteLine("1. Equality Check (any units)");
                Console.WriteLine("2. Convert (value from unit -> unit)");
                Console.WriteLine("3. Demo (given sample conversions)");
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
                        RunDemo();
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

            QuantityLength q1 = new QuantityLength(v1, u1);
            QuantityLength q2 = new QuantityLength(v2, u2);

            Console.WriteLine($"Equal: {q1.Equals(q2)}");
        }

        private void RunConversion()
        {
            Console.Write("Enter value: ");
            double value = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Select SOURCE unit:");
            LengthUnit from = AskUnit();

            Console.WriteLine("Select TARGET unit:");
            LengthUnit to = AskUnit();

            double result = QuantityLength.Convert(value, from, to);
            Console.WriteLine($"Result: {result}");
        }

        private void RunDemo()
        {
            // Required UC5 examples (plus some extras)
            QuantityMeasurementApi.DemonstrateLengthConversion(1.0, LengthUnit.FEET, LengthUnit.INCH);
            QuantityMeasurementApi.DemonstrateLengthConversion(3.0, LengthUnit.YARD, LengthUnit.FEET);
            QuantityMeasurementApi.DemonstrateLengthConversion(36.0, LengthUnit.INCH, LengthUnit.YARD);
            QuantityMeasurementApi.DemonstrateLengthConversion(1.0, LengthUnit.CENTIMETER, LengthUnit.INCH);
            QuantityMeasurementApi.DemonstrateLengthConversion(0.0, LengthUnit.FEET, LengthUnit.INCH);

            // Overload demo with QuantityLength instance
            QuantityLength q = new QuantityLength(1.0, LengthUnit.YARD);
            QuantityMeasurementApi.DemonstrateLengthConversion(q, LengthUnit.INCH);

            // Equality demo
            QuantityMeasurementApi.DemonstrateLengthEquality(
                new QuantityLength(1.0, LengthUnit.FEET),
                new QuantityLength(12.0, LengthUnit.INCH)
            );
        }

        private LengthUnit AskUnit()
        {
            Console.WriteLine("1. FEET");
            Console.WriteLine("2. INCH");
            Console.WriteLine("3. YARD");
            Console.WriteLine("4. CENTIMETER");
            Console.Write("Enter unit choice: ");

            int u = Convert.ToInt32(Console.ReadLine());
            return (LengthUnit)(u - 1);
        }
    }
}