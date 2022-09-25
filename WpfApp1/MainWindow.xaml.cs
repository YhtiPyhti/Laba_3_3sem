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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }
        private void Button_Reg_Click(object sender, RoutedEventArgs e)
        {
            string login = textBoxLogin.Text.Trim();
            string pass = textBoxPassword.Password.Trim();
            string repPass = textBoxRepPassword.Password.Trim();
            string email = textBoxEmail.Text.Trim();

            if (login.Length < 1)
            {
                textBoxLogin.ToolTip = "Form empty";
                textBoxLogin.Background = Brushes.DarkRed;
            }
            else if (pass != repPass || pass.Length < 1 || repPass.Length < 1)
            {
                textBoxPassword.ToolTip = "Passwords don't match";
                textBoxRepPassword.Background = Brushes.DarkRed;
            }
            else if(!email.Contains("@") || !email.Contains(".") || email.Length < 1)
            {
                textBoxEmail.ToolTip = "Incorrect email";
                textBoxEmail.Background = Brushes.DarkRed;
            }
            else
            {
                textBoxLogin.ToolTip = "";
                textBoxLogin.Background = Brushes.Transparent;
                
                textBoxPassword.ToolTip = "";
                textBoxPassword.Background = Brushes.Transparent;
                
                textBoxRepPassword.ToolTip = "";
                textBoxRepPassword.Background = Brushes.Transparent;
                
                textBoxEmail.ToolTip = "";
                textBoxEmail.Background = Brushes.Transparent;

                User person = new User(login, pass, email);

                UserSerDeser windowSerDesr = new UserSerDeser(person);
                windowSerDesr.Owner = this;
                windowSerDesr.Show();
                Hide();
            }
        }
    }
}
