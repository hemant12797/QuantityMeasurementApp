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
                Console.WriteLine("4. Temperature Operations");
                Console.WriteLine("5. Exit");
                Console.Write("Enter choice: ");

                string? choice = Console.ReadLine();

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
                        HandleTemperature();
                        break;
                    case "5":
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
            Console.WriteLine("\n--- Length Addition ---");

            var q1 = ReadLength("First");
            var q2 = ReadLength("Second");

            var result = q1.Add(q2);
            Console.WriteLine($"Result: {result}");
        }

        private Quantity<LengthUnit> ReadLength(string label)
        {
            Console.Write($"{label} value: ");
            double value = double.Parse(Console.ReadLine()!);

            Console.WriteLine("Choose Unit:");
            Console.WriteLine("1. FEET");
            Console.WriteLine("2. INCH");
            Console.WriteLine("3. YARD");
            Console.WriteLine("4. CENTIMETER");

            string? unitChoice = Console.ReadLine();

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
            Console.WriteLine("\n--- Weight Addition ---");

            var q1 = ReadWeight("First");
            var q2 = ReadWeight("Second");

            var result = q1.Add(q2);
            Console.WriteLine($"Result: {result}");
        }

        private Quantity<WeightUnit> ReadWeight(string label)
        {
            Console.Write($"{label} value: ");
            double value = double.Parse(Console.ReadLine()!);

            Console.WriteLine("Choose Unit:");
            Console.WriteLine("1. KILOGRAM");
            Console.WriteLine("2. GRAM");
            Console.WriteLine("3. POUND");

            string? unitChoice = Console.ReadLine();

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
            Console.WriteLine("\n--- Volume Addition ---");

            var q1 = ReadVolume("First");
            var q2 = ReadVolume("Second");

            var result = q1.Add(q2);
            Console.WriteLine($"Result: {result}");
        }

        private Quantity<VolumeUnit> ReadVolume(string label)
        {
            Console.Write($"{label} value: ");
            double value = double.Parse(Console.ReadLine()!);

            Console.WriteLine("Choose Unit:");
            Console.WriteLine("1. LITRE");
            Console.WriteLine("2. MILLILITRE");
            Console.WriteLine("3. GALLON");

            string? unitChoice = Console.ReadLine();

            VolumeUnit unit = unitChoice switch
            {
                "1" => VolumeUnit.LITRE,
                "2" => VolumeUnit.MILLILITRE,
                "3" => VolumeUnit.GALLON,
                _ => throw new ArgumentException("Invalid volume unit")
            };

            return new Quantity<VolumeUnit>(value, unit);
        }

        // =========================
        // TEMPERATURE (UC14)
        // =========================
        private void HandleTemperature()
        {
            Console.WriteLine("\n--- Temperature Conversion ---");

            var q = ReadTemperature("Enter Temperature");

            Console.WriteLine("Convert To:");
            Console.WriteLine("1. CELSIUS");
            Console.WriteLine("2. FAHRENHEIT");
            Console.WriteLine("3. KELVIN");

            string? unitChoice = Console.ReadLine();

            TemperatureUnit target = unitChoice switch
            {
                "1" => TemperatureUnit.CELSIUS,
                "2" => TemperatureUnit.FAHRENHEIT,
                "3" => TemperatureUnit.KELVIN,
                _ => throw new ArgumentException("Invalid temperature unit")
            };

            var result = q.ConvertTo(target);
            Console.WriteLine($"Converted Result: {result}");

            Console.WriteLine("\nAttempting Addition (Should Fail):");

            try
            {
                var test = q.Add(q);
                Console.WriteLine(test);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        private Quantity<TemperatureUnit> ReadTemperature(string label)
        {
            Console.Write($"{label} value: ");
            double value = double.Parse(Console.ReadLine()!);

            Console.WriteLine("Choose Unit:");
            Console.WriteLine("1. CELSIUS");
            Console.WriteLine("2. FAHRENHEIT");
            Console.WriteLine("3. KELVIN");

            string? unitChoice = Console.ReadLine();

            TemperatureUnit unit = unitChoice switch
            {
                "1" => TemperatureUnit.CELSIUS,
                "2" => TemperatureUnit.FAHRENHEIT,
                "3" => TemperatureUnit.KELVIN,
                _ => throw new ArgumentException("Invalid temperature unit")
            };

            return new Quantity<TemperatureUnit>(value, unit);
        }
    }
}