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
using SystemBank.DataAccess;

namespace SystemBank
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static Global global = new Global();
        public MainWindow()
        {
            global.Login.Show();
            using (var context = new Context.Context())
            {
                context.SaveChanges();
            }
            this.Hide();
            InitializeComponent();
        }
        public static Func<Account,int> action;
        private void AddThousand(object sender, RoutedEventArgs e)
        {
            using (var context = new Context.Context())
            {
                var account = context.Accounts.Where(a => a.Login == loginBox.Text).ToList();
                account[0].Cash += 1000;
                action = new Func<Account,int>(CashSetting);
                var result = action.BeginInvoke(account[0], CashResult, null);
            }
        }

        static private int CashSetting(Account account)
        {
            return account.Cash;
        }

        private static void CashResult(IAsyncResult result)
        {
            action.EndInvoke(result);
        }

        private void AddFiveHndr(object sender, RoutedEventArgs e)
        {
            using (var context = new Context.Context())
            {

                var account = context.Accounts.Where(a => a.Login == loginBox.Text).ToList();
                account[0].Cash += 500;
                action = new Func<Account, int>(CashSetting);
                var result = action.BeginInvoke(account[0], CashResult, null);
            }
        }

        private void MinusThousand(object sender, RoutedEventArgs e)
        {
            using (var context = new Context.Context())
            {

                var account = context.Accounts.Where(a => a.Login == loginBox.Text).ToList();
                account[0].Cash -= 1000;
                action = new Func<Account, int>(CashSetting);
                var result = action.BeginInvoke(account[0], CashResult, null);
            }
        }

        private void MinusFiveHndr(object sender, RoutedEventArgs e)
        {
            using (var context = new Context.Context())
            {

                var account = context.Accounts.Where(a => a.Login == loginBox.Text).ToList();
                account[0].Cash -= 500;
                action = new Func<Account, int>(CashSetting);
                var result = action.BeginInvoke(account[0], CashResult, null);
            }
        }
    }
}
