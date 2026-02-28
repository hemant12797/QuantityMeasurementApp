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
                Console.WriteLine("\n===== Quantity Measurement App =====");
                Console.WriteLine("1. Length Operations");
                Console.WriteLine("2. Weight Operations");
                Console.WriteLine("3. Exit");
                Console.Write("Select option: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        LengthMenu();
                        break;
                    case "2":
                        WeightMenu();
                        break;
                    case "3":
                        return;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }

        // =========================================
        // LENGTH MENU
        // =========================================

        private static void LengthMenu()
        {
            Console.WriteLine("\n--- Length Operations ---");
            Console.WriteLine("1. Compare Lengths");
            Console.WriteLine("2. Convert Length");
            Console.WriteLine("3. Add Lengths");
            Console.Write("Select option: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    var l1 = ReadLength();
                    var l2 = ReadLength();
                    Console.WriteLine("Equal? " + l1.Equals(l2));
                    break;

                case "2":
                    var length = ReadLength();
                    var targetUnit = ReadLengthUnit();
                    var converted = length.ConvertTo(targetUnit);
                    Console.WriteLine("Converted: " + converted);
                    break;

                case "3":
                    var a = ReadLength();
                    var b = ReadLength();
                    Console.WriteLine("Target Unit?");
                    var target = ReadLengthUnit();
                    var sum = QuantityLength.Add(a, b, target);
                    Console.WriteLine("Result: " + sum);
                    break;

                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }

        // =========================================
        // WEIGHT MENU
        // =========================================

        private static void WeightMenu()
        {
            Console.WriteLine("\n--- Weight Operations ---");
            Console.WriteLine("1. Compare Weights");
            Console.WriteLine("2. Convert Weight");
            Console.WriteLine("3. Add Weights");
            Console.Write("Select option: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    var w1 = ReadWeight();
                    var w2 = ReadWeight();
                    Console.WriteLine("Equal? " + w1.Equals(w2));
                    break;

                case "2":
                    var weight = ReadWeight();
                    var targetUnit = ReadWeightUnit();
                    var converted = weight.ConvertTo(targetUnit);
                    Console.WriteLine("Converted: " + converted);
                    break;

                case "3":
                    var a = ReadWeight();
                    var b = ReadWeight();
                    Console.WriteLine("Target Unit?");
                    var target = ReadWeightUnit();
                    var sum = QuantityWeight.Add(a, b, target);
                    Console.WriteLine("Result: " + sum);
                    break;

                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }

        // =========================================
        // INPUT HELPERS
        // =========================================

        private static QuantityLength ReadLength()
        {
            Console.Write("Enter value: ");
            double value = double.Parse(Console.ReadLine());

            LengthUnit unit = ReadLengthUnit();
            return new QuantityLength(value, unit);
        }

        private static LengthUnit ReadLengthUnit()
        {
            Console.WriteLine("Select Length Unit:");
            Console.WriteLine("1. FEET");
            Console.WriteLine("2. INCH");
            Console.WriteLine("3. YARD");
            Console.WriteLine("4. CENTIMETER");

            string unitChoice = Console.ReadLine();

            return unitChoice switch
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

            WeightUnit unit = ReadWeightUnit();
            return new QuantityWeight(value, unit);
        }

        private static WeightUnit ReadWeightUnit()
        {
            Console.WriteLine("Select Weight Unit:");
            Console.WriteLine("1. KILOGRAM");
            Console.WriteLine("2. GRAM");
            Console.WriteLine("3. POUND");

            string unitChoice = Console.ReadLine();

            return unitChoice switch
            {
                "1" => WeightUnit.KILOGRAM,
                "2" => WeightUnit.GRAM,
                "3" => WeightUnit.POUND,
                _ => throw new ArgumentException("Invalid unit selection")
            };
        }
    }
}