using System;
using QuantityMeasurementApp.Model;

namespace QuantityMeasurementApp.Controller
{
    public class MenuController
    {
        public void Run()
        {
            Console.WriteLine("Enter first value:");
            double v1 = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Select unit (1 Feet, 2 Inch):");
            LengthUnit u1 = (LengthUnit)(Convert.ToInt32(Console.ReadLine()) - 1);

            Console.WriteLine("Enter second value:");
            double v2 = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Select unit (1 Feet, 2 Inch):");
            LengthUnit u2 = (LengthUnit)(Convert.ToInt32(Console.ReadLine()) - 1);

            QuantityLength q1 = new QuantityLength(v1, u1);
            QuantityLength q2 = new QuantityLength(v2, u2);

            Console.WriteLine($"Equal: {q1.Equals(q2)}");
        }
    }
}