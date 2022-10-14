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
    /// Логика взаимодействия для deleteGoods.xaml
    /// </summary>
    public partial class deleteGoods : Window
    {
        bool flag_article_digit;
        ElmiDBEntities db;
        bool article;
        public deleteGoods()
        {
            InitializeComponent();
            db = new ElmiDBEntities();
        }
        private void delete_Click(object sender, RoutedEventArgs e)
        {
            flag_article_digit = true;
            article = false;
            foreach (char c in articleTB.Text)
            {
                if (char.IsLetter(c))
                {
                    flag_article_digit = false;
                }
            }
            if (flag_article_digit)
            {
                foreach (goods goo in db.goods)
                {
                    if (goo.good_article == Convert.ToInt32(articleTB.Text)) article = true;
                }
                if (article)
                {
                    goods good = new goods();
                    good = db.goods.Find(Convert.ToInt32(articleTB.Text));
                    db.goods.Remove(good);
                    db.SaveChanges();
                    this.Close();
                }
                else sostoyanie.Text = "Не найден артикул";
            }
            else sostoyanie.Text = "Не корректный артикул";
        }
        private void exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
