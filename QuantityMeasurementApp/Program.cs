using QuantityMeasurementApp.Controller;

namespace QuantityMeasurementApp
{
    class Program
    {
        static void Main(string[] args)
        {
            MenuController menu = new MenuController();
            menu.ShowMenu();
        }
    }
}