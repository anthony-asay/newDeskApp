using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MyNewDesks
{
    //A list of the types of wood available
    public enum DeskType
    {
        Oak,
        Laminate,
        Pine,
        Plywood,
        Rosewood,
        Birch
    };

    //A structure that contains the type of wood and its price
    struct Wood
    {
        public DeskType woodType;
        public double price;
    };

    class Desk : IDesk
    {
        public string customerName, surfaceType;
        public double widthDesk, lengthDesk, area, rushDays, numberOfDrawers, price, shipping, priceTotal;

        static double[] getRushedPrices()
        {
            //Get prices from text file
            string filePath = @"rushOrderPrices.txt";
            double[] prices = new double[9];
            StreamReader reader = new StreamReader(filePath);
            int i = 0;
            //Each line from the text file is passed into the prices array
            while (reader.EndOfStream == false)
            {
                string line = reader.ReadLine();
                prices[i] = double.Parse(line);
                i++;
            }
            reader.Close();
            return prices;
        }

        public double CalculateArea(double width, double length)
        {
            this.area = width * length;
            return this.area;
        }

        public double CalculateShipping(int days, double area)
        {
            //Shipping is calculated based on the number of days and the surface area of the desk
            double[] prices = getRushedPrices();
            if (area > 2000)
            {
                switch (days)
                {
                    case 3:
                        this.shipping = prices[2];
                        break;
                    case 5:
                        this.shipping = prices[5];
                        break;
                    case 7:
                        this.shipping = prices[8];
                        break;
                }
            }
            else if (area > 1000)
            {
                switch (days)
                {
                    case 3:
                        this.shipping = prices[1];
                        break;
                    case 5:
                        this.shipping = prices[4];
                        break;
                    case 7:
                        this.shipping = prices[7];
                        break;
                }
            }
            else
            {
                switch (days)
                {
                    case 3:
                        this.shipping = prices[0];
                        break;
                    case 5:
                        this.shipping = prices[3];
                        break;
                    case 7:
                        this.shipping = prices[6];
                        break;
                }
            }
            return this.shipping;
        }

        public double CalculatePrice(double area, double drawers, string wood)
        {
            this.price = 0;
            this.price += this.PriceForArea(area);
            this.price += (drawers * 50);
            this.price += this.WoodPrice(wood);
            return this.price;
        }

        public double PriceForArea(double area)
        {
            double price;
            if (area > 1000)
            {
                price = ((area - 1000) * 5) + 200;
            }
            else
            {
                price = 200;
            }
            return price;
        }

        public double WoodPrice(string woodType)
        {
            double price = 0;
            bool stop = false;
            do
            {
                switch (woodType.ToUpper())
                {
                    case "OAK":
                        price = 500;
                        stop = true;
                        break;
                    case "LAMINATE":
                        price = 400;
                        stop = true;
                        break;
                    case "PINE":
                        price = 300;
                        stop = true;
                        break;
                    case "PLYWOOD":
                        price = 200;
                        stop = true;
                        break;
                    case "ROSEWOOD":
                        price = 100;
                        stop = true;
                        break;
                    case "BIRCH":
                        price = 50;
                        stop = true;
                        break;
                    default:
                        Console.WriteLine("Invalid selection");
                        break;
                }
            } while (!stop);

            return price;
        }

    }
}
