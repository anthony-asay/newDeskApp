using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MyNewDesks
{
    /// <summary>
    /// Interaction logic for MyNewDesksResults.xaml
    /// </summary>
    public partial class MyNewDesksResults : Page
    {
        public MyNewDesksResults(string name, string wood, double length, double width, double area, double days, double drawers, double price, double shipping, double totalPrice)
        {
            InitializeComponent();
            nameLabel.Content = name;
            woodLabel.Content = wood;
            lengthLabel.Content = length + " in";
            widthLabel.Content = width + " in";
            areaLabel.Content = area + " in squared";
            daysLabel.Content = days + " Days";
            drawerLabel.Content = drawers;
            priceLabel.Content = "$ " + price;
            shippingLabel.Content = "$ " + shipping;
            totalLabel.Content = "$ " + totalPrice;
        }
    }
}
