using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNewDesks
{
    interface IDesk
    {
        double CalculateArea(double width, double length);
        double CalculateShipping(int days, double area);
        double PriceForArea(double area);
        double CalculatePrice(double area, double drawers, string wood);
        double WoodPrice(string wood);
    }
}
