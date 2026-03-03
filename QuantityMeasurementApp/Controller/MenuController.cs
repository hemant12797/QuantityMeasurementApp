using System;
using QuantityMeasurementApp.Model;

namespace QuantityMeasurementApp.Controller
{
    public class MenuController
    {
        public void ShowMenu()
        {
            while (true)
            {
                Console.WriteLine("\n===== Quantity Measurement Menu =====");
                Console.WriteLine("1. Length Operations");
                Console.WriteLine("2. Weight Operations");
                Console.WriteLine("3. Volume Operations");
                Console.WriteLine("4. Exit");
                Console.Write("Enter choice: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        HandleLength();
                        break;
                    case "2":
                        HandleWeight();
                        break;
                    case "3":
                        HandleVolume();
                        break;
                    case "4":
                        return;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }

        // =========================
        // LENGTH
        // =========================
        private void HandleLength()
        {
            Console.WriteLine("\n--- Length Operations ---");
            Console.WriteLine("1. Add");
            Console.WriteLine("2. Subtract");
            Console.WriteLine("3. Divide");
            Console.Write("Choose operation: ");

            string operation = Console.ReadLine();

            var q1 = ReadLength("First");
            var q2 = ReadLength("Second");

            switch (operation)
            {
                case "1":
                    Console.WriteLine($"Result: {q1.Add(q2)}");
                    break;
                case "2":
                    Console.WriteLine($"Result: {q1.Subtract(q2)}");
                    break;
                case "3":
                    Console.WriteLine($"Result: {q1.Divide(q2)}");
                    break;
                default:
                    Console.WriteLine("Invalid operation.");
                    break;
            }
        }

        private Quantity<LengthUnit> ReadLength(string label)
        {
            Console.Write($"{label} value: ");
            double value = double.Parse(Console.ReadLine());

            Console.WriteLine("Choose Unit:");
            Console.WriteLine("1. FEET");
            Console.WriteLine("2. INCH");
            Console.WriteLine("3. YARD");
            Console.WriteLine("4. CENTIMETER");

            string unitChoice = Console.ReadLine();

            LengthUnit unit = unitChoice switch
            {
                "1" => LengthUnit.FEET,
                "2" => LengthUnit.INCH,
                "3" => LengthUnit.YARD,
                "4" => LengthUnit.CENTIMETER,
                _ => throw new ArgumentException("Invalid length unit")
            };

            return new Quantity<LengthUnit>(value, unit);
        }

        // =========================
        // WEIGHT
        // =========================
        private void HandleWeight()
        {
            Console.WriteLine("\n--- Weight Operations ---");
            Console.WriteLine("1. Add");
            Console.WriteLine("2. Subtract");
            Console.WriteLine("3. Divide");
            Console.Write("Choose operation: ");

            string operation = Console.ReadLine();

            var q1 = ReadWeight("First");
            var q2 = ReadWeight("Second");

            switch (operation)
            {
                case "1":
                    Console.WriteLine($"Result: {q1.Add(q2)}");
                    break;
                case "2":
                    Console.WriteLine($"Result: {q1.Subtract(q2)}");
                    break;
                case "3":
                    Console.WriteLine($"Result: {q1.Divide(q2)}");
                    break;
                default:
                    Console.WriteLine("Invalid operation.");
                    break;
            }
        }

        private Quantity<WeightUnit> ReadWeight(string label)
        {
            Console.Write($"{label} value: ");
            double value = double.Parse(Console.ReadLine());

            Console.WriteLine("Choose Unit:");
            Console.WriteLine("1. KILOGRAM");
            Console.WriteLine("2. GRAM");
            Console.WriteLine("3. POUND");

            string unitChoice = Console.ReadLine();

            WeightUnit unit = unitChoice switch
            {
                "1" => WeightUnit.KILOGRAM,
                "2" => WeightUnit.GRAM,
                "3" => WeightUnit.POUND,
                _ => throw new ArgumentException("Invalid weight unit")
            };

            return new Quantity<WeightUnit>(value, unit);
        }

        // =========================
        // VOLUME
        // =========================
        private void HandleVolume()
        {
            Console.WriteLine("\n--- Volume Operations ---");
            Console.WriteLine("1. Add");
            Console.WriteLine("2. Subtract");
            Console.WriteLine("3. Divide");
            Console.Write("Choose operation: ");

            string operation = Console.ReadLine();

            var q1 = ReadVolume("First");
            var q2 = ReadVolume("Second");

            switch (operation)
            {
                case "1":
                    Console.WriteLine($"Result: {q1.Add(q2)}");
                    break;
                case "2":
                    Console.WriteLine($"Result: {q1.Subtract(q2)}");
                    break;
                case "3":
                    Console.WriteLine($"Result: {q1.Divide(q2)}");
                    break;
                default:
                    Console.WriteLine("Invalid operation.");
                    break;
            }
        }

        private Quantity<VolumeUnit> ReadVolume(string label)
        {
            Console.Write($"{label} value: ");
            double value = double.Parse(Console.ReadLine());

            Console.WriteLine("Choose Unit:");
            Console.WriteLine("1. LITRE");
            Console.WriteLine("2. MILLILITRE");
            Console.WriteLine("3. GALLON");

            string unitChoice = Console.ReadLine();

            VolumeUnit unit = unitChoice switch
            {
                "1" => VolumeUnit.LITRE,
                "2" => VolumeUnit.MILLILITRE,
                "3" => VolumeUnit.GALLON,
                _ => throw new ArgumentException("Invalid volume unit")
            };

            return new Quantity<VolumeUnit>(value, unit);
        }
    }
}