using demobook.utils;
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

namespace demobook
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Password;

            // Вызываем метод аутентификации из класса DataAccess для проверки имени пользователя и пароля
            int userId = DataAccess.AuthenticateUser(username, password);

            if (userId != 0)
            {
                OpenUserRoleWindow(userId);
            }
            else
            {
                MessageBox.Show("Invalid username or password. Please try again.");
            }
        }

        private void OpenUserRoleWindow(int roleId)
        {
            int userId = 0;
            string username = txtUsername.Text;
            string password = txtPassword.Password;

            if (roleId != 1) // Если не гость, выполняем аутентификацию пользователя
            {
                userId = DataAccess.AuthenticateUser(username, password);
                if (userId == 0)
                {
                    MessageBox.Show("Invalid username or password. Please try again.");
                    return;
                }
            }

            Window userRoleWindow = null;

            switch (roleId)
            {
                case 1: // Гость
                    userRoleWindow = new GuestWindow(userId);
                    break;
                case 2: // Менеджер
                    userRoleWindow = new ManagerWindow();
                    break;
                case 3: // Администратор
                    userRoleWindow = new AdminWindow();
                    break;
                default:
                    MessageBox.Show("Unknown role. Please contact the administrator.");
                    break;
            }

            if (userRoleWindow != null)
            {
                userRoleWindow.Show();
                Close();
            }
        }
    }
}
