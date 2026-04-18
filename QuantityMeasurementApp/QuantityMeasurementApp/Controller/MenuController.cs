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
                Console.WriteLine("\nSelect Unit:");
                Console.WriteLine("1. Feet");
                Console.WriteLine("2. Inches");
                Console.WriteLine("3. Exit");

                int unitChoice = Convert.ToInt32(Console.ReadLine());

                if (unitChoice == 3)
                    return;

                Console.WriteLine("Enter first value:");
                double v1 = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("Enter second value:");
                double v2 = Convert.ToDouble(Console.ReadLine());

                if (unitChoice == 1)
                {
                    Feet f1 = new Feet(v1);
                    Feet f2 = new Feet(v2);
                    UnitMenu(f1, f2);
                }
                else if (unitChoice == 2)
                {
                    Inches i1 = new Inches(v1);
                    Inches i2 = new Inches(v2);
                    UnitMenu(i1, i2);
                }
            }
        }

        private void UnitMenu(object obj1, object obj2)
        {
            while (true)
            {
                Console.WriteLine("\nSelect Operation:");
                Console.WriteLine("1. Reference Check");
                Console.WriteLine("2. Null or Type Check");
                Console.WriteLine("3. Safe Cast");
                Console.WriteLine("4. Compare Values");
                Console.WriteLine("5. Back");

                int op = Convert.ToInt32(Console.ReadLine());

                switch (op)
                {
                    case 1:
                        Console.WriteLine(obj1.Equals(obj1));
                        break;
                    case 2:
                        Console.WriteLine(obj1 == null || obj1.GetType() != obj2.GetType());
                        break;
                    case 3:
                        Console.WriteLine(obj1.GetType() == obj2.GetType());
                        break;
                    case 4:
                        dynamic d1 = obj1;
                        Console.WriteLine(d1.Compare(obj2));
                        break;
                    case 5:
                        return;
                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }
            }
        }
    }
}
