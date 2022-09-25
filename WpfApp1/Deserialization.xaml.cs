using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
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

using System.Text.Json;
using System.Text.Json.Serialization;
using System.Xml.Serialization;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для Deserialization.xaml
    /// </summary>
    /// 

    public partial class Deserialization : Window
    {
        User person;
        string PATH = "C:\\Users\\Sergei\\Desktop\\person";
        public Deserialization()
        {
            InitializeComponent();
        }

        private void Button_Bin_Click(object sender, RoutedEventArgs e)
        {

            BinaryFormatter formatter = new BinaryFormatter();

            using (FileStream fs = new FileStream(PATH + ".dat", FileMode.OpenOrCreate))
            {
               person = (User)formatter.Deserialize(fs);

               inputRes.Text = ($"*Bin* User: {person.login} password: {person.password} email: {person.email}");
            }
        }

        private void Button_XML_Click(object sender, RoutedEventArgs e)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(User));

            // десериализуем объект
            using (FileStream fs = new FileStream(PATH + ".xml", FileMode.OpenOrCreate))
            {
                User person = xmlSerializer.Deserialize(fs) as User;
                inputRes.Text = ($"*XML* User: {person.login} password: {person.password} email: {person.email}");
            }
        }

        private void Button_JSON_Click(object sender, RoutedEventArgs e)
        {
            using (FileStream fs = new FileStream(PATH + ".json", FileMode.OpenOrCreate))
            {
                User person = JsonSerializer.Deserialize<User>(fs);
                inputRes.Text = ($"*JSON* User: {person.login} password: {person.password} email: {person.email}");
            }
        }

        private void Button_BackSerDes_Click(object sender, RoutedEventArgs e)
        {
            UserSerDeser windowSerDesr = new UserSerDeser(person);
            windowSerDesr.Show();
            Hide();
        }
    }
}
