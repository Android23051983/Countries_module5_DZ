using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Net.Mime.MediaTypeNames;

namespace Countries_module5_DZ
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        SqlConnection conn = null;
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void Button_ClickAsync(object sender, RoutedEventArgs e)
        {
            await Task.Delay(3000);
            if (rButton1_1.IsChecked == true)
            {
                DataClasses1DataContext db = new DataClasses1DataContext();
                var queryResults = from c in db.Table1 select c;
                dataGrid.ItemsSource = null;
                dataGrid.ItemsSource = queryResults;
            }
            else if (rButton1_2.IsChecked == true)
            {
                DataClasses1DataContext db = new DataClasses1DataContext();
                var queryResults = from c in db.Table1 select new { c.CountryName };
                dataGrid.ItemsSource = null;
                dataGrid.ItemsSource = queryResults;
            }
            else if (rButton1_3.IsChecked == true)
            {
                DataClasses1DataContext db = new DataClasses1DataContext();
                var queryResults = from c in db.Table1 select new { c.CapitalName };
                dataGrid.ItemsSource = null;
                dataGrid.ItemsSource = queryResults;
            }
            else if (rButton1_4.IsChecked == true)
            {
                DataClasses1DataContext db = new DataClasses1DataContext();
                var queryResults = from c in db.Table1 where c.WorldPart == "Европа" select new { c.CountryName, c.WorldPart };
                dataGrid.ItemsSource = null;
                dataGrid.ItemsSource = queryResults;
            }
            else if (rButton1_5.IsChecked == true)
            {
                DataClasses1DataContext db = new DataClasses1DataContext();
                var queryResults = from c in db.Table1 where c.SquareArea > Convert.ToInt32(number1_1.Text) select new { c.CountryName, c.SquareArea };
                dataGrid.ItemsSource = null;
                dataGrid.ItemsSource = queryResults;
            }
        }

        private async void Button1_ClickAsync(object sender, RoutedEventArgs e)
        {
            await Task.Delay(3000);
            if (rButton2_1.IsChecked == true)
            {
                DataClasses1DataContext db = new DataClasses1DataContext();
                var queryResults = from c in db.Table1 where c.CountryName.Contains(letter2_1.Text) && c.CountryName.Contains(letter2_2.Text) select new { c.CountryName };
                dataGrid1.ItemsSource = null;
                dataGrid1.ItemsSource = queryResults;
            }
            else if (rButton2_2.IsChecked == true)
            {
                DataClasses1DataContext db = new DataClasses1DataContext();
                var queryResults = from c in db.Table1 where c.CountryName.Contains(letter2_3.Text)  select new { c.CountryName};
                dataGrid1.ItemsSource = null;
                dataGrid1.ItemsSource = queryResults;
            }
            else if (rButton2_3.IsChecked == true)
            {
                DataClasses1DataContext db = new DataClasses1DataContext();
                var queryResults = from c in db.Table1 where c.SquareArea >= Convert.ToDouble(number2_1.Text) && c.SquareArea <= Convert.ToDouble(number2_2.Text) select new { c.CountryName, c.SquareArea };
                dataGrid1.ItemsSource = null;
                dataGrid1.ItemsSource = queryResults;
            }
            else if (rButton2_4.IsChecked == true)
            {
                DataClasses1DataContext db = new DataClasses1DataContext();
                var queryResults = from c in db.Table1 where c.InhabitantsNumber > Convert.ToInt32(number2_3.Text) select new { c.CountryName, c.InhabitantsNumber };
                dataGrid1.ItemsSource = null;
                dataGrid1.ItemsSource = queryResults;
            }
        }

        private async void Button2_ClickAsync(object sender, RoutedEventArgs e)
        {
            await Task.Delay(3000);
            if (rButton3_1.IsChecked == true)
            {
                DataClasses1DataContext db = new DataClasses1DataContext();
                var queryResults = db.Table1.OrderByDescending(c => c.SquareArea).Take(5);
                dataGrid2.ItemsSource = null;
                dataGrid2.ItemsSource = queryResults;
            }
            else if (rButton3_2.IsChecked == true)
            {
                DataClasses1DataContext db = new DataClasses1DataContext();
                var queryResults = db.Table1.OrderByDescending(c => c.InhabitantsNumber).Take(5);
                dataGrid2.ItemsSource = null;
                dataGrid2.ItemsSource = queryResults;
            }
            else if (rButton3_3.IsChecked == true)
            {
                DataClasses1DataContext db = new DataClasses1DataContext();
                var maxSqareArea = db.Table1.Select(c => c.SquareArea).Max();
                var queryResults = db.Table1.Where(c => c.SquareArea == maxSqareArea);
                dataGrid2.ItemsSource = null;
                dataGrid2.ItemsSource = queryResults;
            }
            else if (rButton3_4.IsChecked == true)
            {
                DataClasses1DataContext db = new DataClasses1DataContext();
                var maxInhabitantsNumber = db.Table1.Select(c => c.InhabitantsNumber).Max();
                var queryResults = db.Table1.Where(c => c.InhabitantsNumber == maxInhabitantsNumber);
                dataGrid2.ItemsSource = null;
                dataGrid2.ItemsSource = queryResults;
            }
            else if (rButton3_5.IsChecked == true)
            {
                DataClasses1DataContext db = new DataClasses1DataContext();
                var minSqareArea = db.Table1.Where(c => c.WorldPart == "Африка").Select(c => c.SquareArea).Min();
                var queryResults = db.Table1.Where(c => c.SquareArea == minSqareArea);
                dataGrid2.ItemsSource = null;
                dataGrid2.ItemsSource = queryResults;
            }
            else if (rButton3_6.IsChecked == true)
            {
                DataClasses1DataContext db = new DataClasses1DataContext();
                var avgSqareArea = db.Table1.Where(c => c.WorldPart == "Азия").Select(c => c.SquareArea).Average();
                var queryResults = db.Table1.Where(c => c.WorldPart == "Азия").Distinct();
                dataGrid2.ItemsSource = queryResults.ToList();
                number3_1.Text = avgSqareArea.ToString();
            }
        }
    }
}
