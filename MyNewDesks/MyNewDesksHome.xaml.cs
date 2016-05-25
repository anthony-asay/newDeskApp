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
using Newtonsoft.Json;
using System.IO;
using System.Runtime.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using System.Collections;

namespace MyNewDesks
{
    /// <summary>
    /// Interaction logic for MyNewDesksHome.xaml
    /// </summary>
    public partial class MyNewDesksHome : Page
    {
        Desk desk = new Desk();

        //variables for the desk
        string name;
        string wood;

        double lengthValue;
        double widthValue;
        double area;
        double days;
        double drawers;
        double price;
        double shipping;
        double totalPrice;

        public MyNewDesksHome()
        {
            InitializeComponent();
        }

        private void length_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void buyButton_Click(object sender, RoutedEventArgs e)
        {
            //Verify that all inputs are set
            if((nameCustomer.Text.Length > 0) && (length.Text.Length > 0) && (width.Text.Length > 0) && (drawerNumber.Text.Length > 0) && (woodType.Text.Length > 0)  && (rushDay.Text.Length > 0))
            {
                //call to the method that will calculate values
                CalculateCost();
                //Create a results page object and add values to the page
                MyNewDesksResults resultsPage = new MyNewDesksResults(name, wood, lengthValue, widthValue, area, days, drawers, price, shipping, totalPrice);
                this.NavigationService.Navigate(resultsPage);
            }
            else
            {
                //Message is displayed when not all inputs are entered
                MessageBox.Show("All fields must be entered.");
            }
            
        }

        static string readFileString(string filePath)
        {
            string textString = File.ReadAllText(filePath);
            return textString;
        }

        public void CalculateCost()
        {
            //Get values from input and assign them to variables
            name = nameCustomer.Text;
            wood = woodType.Text;
            lengthValue = Convert.ToDouble(length.Text);
            widthValue = Convert.ToDouble(width.Text);
            area = lengthValue * widthValue;
            days = Convert.ToDouble(rushDay.Text.Remove(1, 5));
            drawers = Convert.ToDouble(drawerNumber.Text);
            price = desk.CalculatePrice(area, drawers, wood);
            shipping = desk.CalculateShipping(Convert.ToInt16(days), area);
            totalPrice = price + shipping;
            //assign values to desk object
            desk.customerName = name;
            desk.lengthDesk = lengthValue;
            desk.widthDesk = widthValue;
            desk.numberOfDrawers = drawers;
            desk.surfaceType = wood;
            desk.rushDays = days;
            desk.area = area;
            desk.price = price;
            desk.shipping = shipping;
            desk.priceTotal = price + shipping;

            //write desk to json file
            string filePath = @"desks.json";
            string path = System.IO.Path.Combine(Environment.CurrentDirectory, filePath);
            string jsonData = readFileString(filePath);
            List<Desk> desks = JsonConvert.DeserializeObject<List<Desk>>(jsonData) ?? new List<Desk>();
            //add new JSON to list
            desks.Add(desk);
            //serialize and write list to a file
            jsonData = JsonConvert.SerializeObject(desks, Formatting.Indented);
            File.WriteAllText(filePath, jsonData);
            
        }
    }
}
