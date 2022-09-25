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

using System.Text.Json;
using System.Text.Json.Serialization;
using System.Xml.Serialization;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для Serialization_xaml.xaml
    /// </summary>
    public partial class Serialization_xaml : Window
    {
        User person;
        string PATH = "C:\\Users\\Sergei\\Desktop\\person";

        public Serialization_xaml(User person_from_main)
        {
            InitializeComponent();
            person = person_from_main;
        }

        private void Button_Bin_Click(object sender, RoutedEventArgs e)
        {

            BinaryFormatter formatter = new BinaryFormatter();

            using (FileStream fs = new FileStream(PATH + ".dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, person);

            }
            inputRes.Text = "Binary serialization was successful";
        }

        private void Button_XML_Click(object sender, RoutedEventArgs e)
        {

            XmlSerializer writer = new XmlSerializer(typeof(User));

            using (FileStream fs = new FileStream(PATH + ".xml", FileMode.OpenOrCreate))
            {
                writer.Serialize(fs, person);
            }

            inputRes.Text = "XML serialization was successful";
        }

        private void Button_JSON_Click(object sender, RoutedEventArgs e)
        {
            string jsonString = JsonSerializer.Serialize(person);

            File.WriteAllText(PATH + ".JSON", jsonString);

            inputRes.Text += (jsonString);

            inputRes.Text = "JSON serialization was successful";
        }

        private void Button_BackSer_Click(object sender, RoutedEventArgs e)
        {
            UserSerDeser windowSerDesr = new UserSerDeser(person);
            windowSerDesr.Show();
            Hide();
        }
    }
}
