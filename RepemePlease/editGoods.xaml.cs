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
    /// Логика взаимодействия для editGoods.xaml
    /// </summary>
    public partial class editGoods : Window
    {
        bool flag_article_digit;
        ElmiDBEntities db;
        bool description;
        bool flag_count_digit;
        bool count;
        bool article;
        public editGoods()
        {
            InitializeComponent();
            db = new ElmiDBEntities();

        }

        private void change_Click(object sender, RoutedEventArgs e)
        {
            flag_article_digit = true;
            article = false;
            count = false;
            description = false;
            flag_count_digit = true;
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
                    if (descriptionTB.Text != "" && descriptionTB.Text.Length <= 24) description = true;
                    else sostoyanie.Text = "Ошибка при вводе данных";
                    if (countTB.Text != "")
                    {
                        foreach (char c in countTB.Text)
                        {
                            if (char.IsLetter(c))
                            {
                                flag_count_digit = false;
                            }
                        }
                        if (flag_count_digit) count = true;
                        else MessageBox.Show("Количество - число, алло");
                    }
                    else sostoyanie.Text = "Ошибка при вводе данных";
                    if (description && count)
                    {
                        good.good_description = descriptionTB.Text;
                        good.good_count = Convert.ToInt32(countTB.Text);
                        db.SaveChanges();
                        this.Close();
                    }
                }
                else sostoyanie.Text = "Не найден артикул";
            }
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
