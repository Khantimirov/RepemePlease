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

namespace RepemePlease
{
    /// <summary>
    /// Логика взаимодействия для HugeWindow.xaml
    /// </summary>
    public partial class HugeWindow : Window
    {
        ElmiDBEntities db;
        public HugeWindow()
        {
            InitializeComponent();
            db = new ElmiDBEntities();
        }
        private void MenuItem_Exit(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
        private void MenuItem_addGoods(object sender, RoutedEventArgs e)
        {
            addGoods addGood = new addGoods();
            addGood.Show();
        }
        private void MenuItem_editGoods(object sender, RoutedEventArgs e)
        {
            editGoods ed = new editGoods();
            ed.Show();
        }
        private void MenuItem_deleteGoods(object sender, RoutedEventArgs e)
        {
            deleteGoods de = new deleteGoods();
            de.Show();
        }

        private void MenuItem_addOrders(object sender, RoutedEventArgs e)
        {
            addOrder ador = new addOrder();
            ador.Show();
        }

        private void MenuItem_deleteOrders(object sender, RoutedEventArgs e)
        {
            deleteOrders deor = new deleteOrders();
            deor.Show();
        }

        private void MenuItem_addSupply(object sender, RoutedEventArgs e)
        {
            addSupply adsu = new addSupply();
            adsu.Show();
        }

        private void MenuItem_deleteSupply(object sender, RoutedEventArgs e)
        {
            deleteSupply desu = new deleteSupply();
            desu.Show();
        }
    }
}
