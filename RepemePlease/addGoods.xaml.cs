using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace RepemePlease
{
    /// <summary>
    /// Логика взаимодействия для addGoods.xaml
    /// </summary>
    public partial class addGoods : Window
    {
        bool flag_count;
        bool flag_article;
        bool flag_article_re;
        bool description;
        bool count;
        bool article;
        ElmiDBEntities db;
        public addGoods()
        {
            InitializeComponent();
            db = new ElmiDBEntities();
        }

        private void addGood(object sender, RoutedEventArgs e)
        {
            bool description = false;
            bool count = false;
            bool article = false;
            flag_count = true;
            flag_article = true;
            goods good = new goods();
            if (descriptionTB.Text != "" && descriptionTB.Text.Length <= 24) description = true;
            else sostoyanie.Text = "Ошибка при вводе данных";
            if (countTB.Text != "")
            {
                foreach (char c in countTB.Text)
                {
                    if (char.IsLetter(c))
                    {
                        flag_count = false;
                    }
                }
                if (flag_count) count = true;
                else MessageBox.Show("Количество - число, алло");
            }
            else sostoyanie.Text = "Ошибка при вводе данных";
            
            if (articleTB.Text != "")
            {
                foreach (char c in articleTB.Text)
                {
                    if (char.IsLetter(c))
                    {
                        flag_article = false;
                    }
                }
                if (flag_article)
                {
                    flag_article_re = false;
                    foreach (goods goo in db.goods)
                    {
                        if (articleTB.Text == Convert.ToString(goo.good_article)) flag_article_re = true;
                    }
                    if (flag_article_re) MessageBox.Show("Повторный артикул!");
                    else article = true;
                }
                else MessageBox.Show("Артикул - число, алло");
            }
            else sostoyanie.Text = "Ошибка при вводе данных";
            if (description && count && article)
            {
                good.good_description = descriptionTB.Text;
                good.good_count = Convert.ToInt32(countTB.Text);
                good.good_article = Convert.ToInt32(articleTB.Text);
                db.goods.Add(good);
                db.SaveChanges();
                this.Close();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
