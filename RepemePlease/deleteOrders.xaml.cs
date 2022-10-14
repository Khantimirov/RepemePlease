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
    /// Логика взаимодействия для deleteOrders.xaml
    /// </summary>
    public partial class deleteOrders : Window
    {
        ElmiDBEntities db;
        bool flag_id_digit;
        bool flag_id_applied;
        bool isid;
        public deleteOrders()
        {
            InitializeComponent();
            db = new ElmiDBEntities();
            CancelRB.IsChecked = true;
        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            flag_id_digit = true;

            if (idTB.Text != "")
            {
                foreach (char c in idTB.Text)
                {
                    if (char.IsLetter(c))
                    {
                        flag_id_digit = false;
                    }
                }
                if (flag_id_digit)
                {
                    flag_id_applied = false;
                    foreach (orders ooo in db.orders)
                    {
                        if (idTB.Text == Convert.ToString(ooo.order_id)) flag_id_applied = true;
                    }
                    if (!flag_id_applied) sostoyanie.Text = "Несуществующий номер заказа!";
                    else isid = true;
                }
                else MessageBox.Show("Номер - число, алло");
            }
            else sostoyanie.Text = "Ошибка при вводе данных";
            if (isid && CancelRB.IsChecked == true)
            {
                orders order = new orders();
                order = db.orders.Find(Convert.ToInt32(idTB.Text));
                db.orders.Remove(order);
                db.SaveChanges();
                this.Close();
            }
            if (isid && ExecRB.IsChecked == true)
            {
                orders order = new orders();
                order = db.orders.Find(Convert.ToInt32(idTB.Text));
                goods goo = new goods();
                goo = db.goods.Find(order.ordered_good);

                if (goo.good_count < order.order_count) MessageBox.Show("Товаров меньше чем в заказе!");
                else
                {
                    goo.good_count -= order.order_count;
                    db.orders.Remove(order);
                    db.SaveChanges();
                    this.Close();
                }
            }
        }
        private void exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ExecRB_Click(object sender, RoutedEventArgs e)
        {
            if (CancelRB.IsChecked == true)
            {
                CancelRB.IsChecked = false;
            }
            actionBtn.Content = "Выполнить";
        }

        private void CancelRB_Click(object sender, RoutedEventArgs e)
        {
            if (ExecRB.IsChecked == true)
            {
                ExecRB.IsChecked = false;
            }
            actionBtn.Content = "Отменить";
        }
    }
}
