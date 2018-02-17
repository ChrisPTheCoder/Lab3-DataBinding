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
using System.Windows.Shapes;
using CarLibrary;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for Car_Detail.xaml
    /// </summary>
    public partial class Car_Detail : Window

    {
        // cannot run so cannnot get ID car
        CarLib currentCar = CarLib.GetCarInfo(1);

        public Car_Detail()
        {
            InitializeComponent();
            DataContext = currentCar;
        }
        private void btnShowObject_Click(object sender, RoutedEventArgs e)
        {
            string result = $"Car ID: {currentCar.CarID}\n  Car Name{currentCar.CarName}. ";
            result += "\nCar Speed " + currentCar.CarSpeed;
            result += "\nCar Color " + currentCar.Color + "\n";
            result += (currentCar.Used) ? "[Used]" : "[New]";
            string accessories = currentCar.Accessory is null ? "" : string.Join(", ", currentCar.Accessory);
            result += "\n: " + accessories;
            MessageBox.Show(result, "Car's Details:", MessageBoxButton.OK);
        }

        private void btnModifyObject_Click(object sender, RoutedEventArgs e)
        {
            currentCar.CarName = carName.Text;
            currentCar.CarSpeed = Convert.ToDouble(carSpeed.Text);
            //fixing problem when value of type 'String' cannot be converted to 'System.Drawing.Color'
            currentCar.Color = System.Drawing.Color.FromName(color.Text);
            //fixing bool to bool
            if (chkUsed.IsChecked.GetValueOrDefault() == true)
            {
                currentCar.Used = true;
            }
            else
            {
                currentCar.Used = false;
            }
            // ko hieu vi minh display het item trong enum de user pick, hay delete from enum??
            //currentCar.Accessory = new List<ACCESSORIES>();
        }
    }
}

