using System.Collections.Generic;
using System.Windows;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для UserSerDeser.xaml
    /// </summary>
    public partial class UserSerDeser : Window
    {
        List<User> userPeople = new List<User>();
        public UserSerDeser(List<User> userPeople_from_main)
        {
            InitializeComponent();
            userPeople = userPeople_from_main;
        }

        private void Button_Ser_Click(object sender, RoutedEventArgs e)
        {
            Serialization_xaml windowSer = new Serialization_xaml(userPeople);
            windowSer.Show();
            Close();
        }

        private void Button_BackMain_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }

        private void Button_Des_Click(object sender, RoutedEventArgs e)
        {
            Deserialization windowSer = new Deserialization();
            windowSer.Show();
            Close();
        }
    }
}
