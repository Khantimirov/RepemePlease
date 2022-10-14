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
    /// Логика взаимодействия для addOrder.xaml
    /// </summary>
    public partial class addOrder : Window
    {
        ElmiDBEntities db;
        bool flag_count_digit;
        bool flag_article_digit;
        bool flag_article_applied;
        bool article;
        public addOrder()
        {
            InitializeComponent();
            db = new ElmiDBEntities();
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            flag_count_digit = true;
            flag_article_digit = true;

            if (countTB.Text != "")
            {
                foreach (char c in countTB.Text)
                {
                    if (char.IsLetter(c))
                    {
                        flag_count_digit = false;
                    }
                }
                if (!flag_count_digit) MessageBox.Show("Количество - число, алло");
            }
            else sostoyanie.Text = "Ошибка при вводе данных";

            if (articleTB.Text != "")
            {
                foreach (char c in articleTB.Text)
                {
                    if (char.IsLetter(c))
                    {
                        flag_article_digit = false;
                    }
                }
                if (flag_article_digit)
                {
                    flag_article_applied = false;
                    foreach (goods goo in db.goods)
                    {
                        if (articleTB.Text == Convert.ToString(goo.good_article)) flag_article_applied = true;
                    }
                    if (!flag_article_applied) sostoyanie.Text = "Несуществующий артикул";
                    else article = true;
                }
                else MessageBox.Show("Артикул - число, алло");
            }
            else sostoyanie.Text = "Ошибка при вводе данных";
            if (article && flag_count_digit)
            {
                orders order = new orders();
                order.order_count = Convert.ToInt32(countTB.Text);
                order.ordered_good = Convert.ToInt32(articleTB.Text);
                db.orders.Add(order);
                db.SaveChanges();
                this.Close();
            }
        }
        private void exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
