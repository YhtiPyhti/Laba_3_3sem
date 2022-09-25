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

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для UserSerDeser.xaml
    /// </summary>
    public partial class UserSerDeser : Window
    {
        User person;
        public UserSerDeser(User person_from_main)
        {
            InitializeComponent();
            person = person_from_main;
        }

        private void Button_Ser_Click(object sender, RoutedEventArgs e)
        {
            Serialization_xaml windowSer = new Serialization_xaml(person);
            windowSer.Show();
            Hide();
        }

        private void Button_BackMain_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Hide();
        }

        private void Button_Des_Click(object sender, RoutedEventArgs e)
        {
            Deserialization windowSer = new Deserialization();
            windowSer.Show();
            Hide();
        }
    }
}
