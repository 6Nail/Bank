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
    /// Interaction logic for SignInSystem.xaml
    /// </summary>
    public partial class SignInSystem : Window
    {
        public SignInSystem()
        {
            InitializeComponent();
        }

        private void TelephoneInput(object sender, TextCompositionEventArgs e)
        {
            TextBox text = sender as TextBox;
            e.Handled = "0123456789".IndexOf(e.Text) < 0;
            text.MaxLength = 11;
        }

        private void SignInAccount(object sender, RoutedEventArgs e)
        {
            bool isCorrect = true;
            if (loginBox.Text == null || loginBox.Text.Length <= 5)
            {
                isCorrect = false;
                MessageBox.Show("Логин должен быть больше 5 символов!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            using (var context = new Context.Context())
            {
                foreach (var account in context.Accounts)
                {
                    if (account.Login == loginBox.Text)
                    {
                        MessageBox.Show("Такой логин уже существует!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                        isCorrect = false;
                    }
                }
            }

            if (passwordBox.Password == null || passwordBox.Password.Length <= 5)
            {
                isCorrect = false;
                MessageBox.Show("Пароль должен быть больше 5 символов!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            if (telephoneBox.Text.Length != 11)
            {
                isCorrect = false;
                MessageBox.Show("Номер телефона должен состоять из 10 цифр!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            if (isCorrect)
            {
                using (var context = new Context.Context())
                {
                    var account = new Account()
                    {
                        Cash = 0,
                        Login = loginBox.Text,
                        Password = passwordBox.Password,
                        Telephone = telephoneBox.Text
                    };
                    context.Accounts.Add(account);
                    context.SaveChanges();
                    this.Close();
                    MainWindow.global.Sign.Show();
                }
            }
            else
            {
                passwordBox.Password = null;
            }
        }

        private void EnterDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                SignInAccount(sender, e);
        }
    }
}
