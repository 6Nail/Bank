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
using SystemBank.DataAccess;

namespace SystemBank
{
    /// <summary>
    /// Interaction logic for LogInSystem.xaml
    /// </summary>
    public partial class LogInSystem : Window
    {
        public LogInSystem()
        {
            InitializeComponent();
        }

        private void SignInSystemButton(object sender, RoutedEventArgs e)
        {
            this.Close();
            MainWindow.global.Sign.Show();
        }

        private void LogInSystemButton(object sender, RoutedEventArgs e)
        {
            using (var context = new Context.Context())
            {
                var account = context.Accounts.Where(a => a.Login == loginBox.Text && a.Password == passwordBox.Password);
                if (account == null)
                {
                    MessageBox.Show("Неверно введён логин или пароль!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                    passwordBox.Password = null;
                }
                else
                {
                    this.Close();
                    MainWindow.global.Main.Show();
                }
            }
        }

        private void EnterSignIn(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                SignInSystemButton(sender, e);
        }
    }
}
