using System;
using QuantityMeasurementApp.Model;

namespace QuantityMeasurementApp.Controller
{
    public class MenuController
    {
        public static void Start()
        {
            while (true)
            {
                Console.WriteLine("\n===== Quantity Measurement App (UC10) =====");
                Console.WriteLine("1. Length Operations");
                Console.WriteLine("2. Weight Operations");
                Console.WriteLine("3. Exit");
                Console.Write("Select option: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1": LengthMenu(); break;
                    case "2": WeightMenu(); break;
                    case "3": return;
                    default: Console.WriteLine("Invalid choice."); break;
                }
            }
        }

        private static void LengthMenu()
        {
            Console.WriteLine("\n--- Length Operations ---");
            Console.WriteLine("1. Compare");
            Console.WriteLine("2. Convert");
            Console.WriteLine("3. Add");
            Console.Write("Select option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    var a = ReadLength();
                    var b = ReadLength();
                    Console.WriteLine("Equal? " + a.Equals(b));
                    break;

                case "2":
                    var l = ReadLength();
                    var target = ReadLengthUnit();
                    Console.WriteLine("Converted: " + l.ConvertTo(target));
                    break;

                case "3":
                    var x = ReadLength();
                    var y = ReadLength();
                    Console.WriteLine("Target Unit?");
                    var t = ReadLengthUnit();
                    Console.WriteLine("Result: " + QuantityLength.Add(x, y, t));
                    break;

                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }

        private static void WeightMenu()
        {
            Console.WriteLine("\n--- Weight Operations ---");
            Console.WriteLine("1. Compare");
            Console.WriteLine("2. Convert");
            Console.WriteLine("3. Add");
            Console.Write("Select option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    var a = ReadWeight();
                    var b = ReadWeight();
                    Console.WriteLine("Equal? " + a.Equals(b));
                    break;

                case "2":
                    var w = ReadWeight();
                    var target = ReadWeightUnit();
                    Console.WriteLine("Converted: " + w.ConvertTo(target));
                    break;

                case "3":
                    var x = ReadWeight();
                    var y = ReadWeight();
                    Console.WriteLine("Target Unit?");
                    var t = ReadWeightUnit();
                    Console.WriteLine("Result: " + QuantityWeight.Add(x, y, t));
                    break;

                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }

        // ------- Input helpers -------

        private static QuantityLength ReadLength()
        {
            Console.Write("Enter value: ");
            double value = double.Parse(Console.ReadLine());
            var unit = ReadLengthUnit();
            return new QuantityLength(value, unit);
        }

        private static LengthUnit ReadLengthUnit()
        {
            Console.WriteLine("Select Length Unit:");
            Console.WriteLine("1. FEET");
            Console.WriteLine("2. INCH");
            Console.WriteLine("3. YARD");
            Console.WriteLine("4. CENTIMETER");
            string c = Console.ReadLine();

            return c switch
            {
                "1" => LengthUnit.FEET,
                "2" => LengthUnit.INCH,
                "3" => LengthUnit.YARD,
                "4" => LengthUnit.CENTIMETER,
                _ => throw new ArgumentException("Invalid unit selection")
            };
        }

        private static QuantityWeight ReadWeight()
        {
            Console.Write("Enter value: ");
            double value = double.Parse(Console.ReadLine());
            var unit = ReadWeightUnit();
            return new QuantityWeight(value, unit);
        }

        private static WeightUnit ReadWeightUnit()
        {
            Console.WriteLine("Select Weight Unit:");
            Console.WriteLine("1. KILOGRAM");
            Console.WriteLine("2. GRAM");
            Console.WriteLine("3. POUND");
            string c = Console.ReadLine();

            return c switch
            {
                "1" => WeightUnit.KILOGRAM,
                "2" => WeightUnit.GRAM,
                "3" => WeightUnit.POUND,
                _ => throw new ArgumentException("Invalid unit selection")
            };
        }
    }
}