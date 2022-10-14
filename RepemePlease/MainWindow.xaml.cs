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

namespace RepemePlease
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ElmiDBEntities db;
        bool flag;
        public MainWindow()
        {
            InitializeComponent();
            db = new ElmiDBEntities();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            flag = false;
            foreach (employees employee in db.employees)
            {
                if (Login_tb.Text == employee.employee_login.Trim() && Password_pb.Password == employee.employee_password.Trim())
                {
                    flag = true;
                }
            }
            if (flag)
            {
                HugeWindow huge = new HugeWindow();
                huge.Show();
                this.Hide();
            }
            else MessageBox.Show("Ошибка авторизации","Неверный логин или пароль");

        }
    }
}
