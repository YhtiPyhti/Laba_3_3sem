using System;
using System.Windows;
using System.Text.Json;
using System.Xml.Serialization;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;



namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для Deserialization.xaml
    /// </summary>
    /// 

    public partial class Deserialization : Window
    {
        List<User> person;
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
                person = (List<User>)formatter.Deserialize(fs);
                foreach (var person1 in person)
                {
                    inputRes.Text += ($"*Bin* User: {person1.login} password: {person1.password} email: {person1.email}");
                }
            }
        }

        private void Button_XML_Click(object sender, RoutedEventArgs e)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(User));

            // десериализуем объект
            using (FileStream fs = new FileStream(PATH + ".xml", FileMode.OpenOrCreate))
            {
                List<User> person = xmlSerializer.Deserialize(fs) as List<User>;
                foreach (var person1 in person)
                {
                    inputRes.Text += ($"*XML* User: {person1.login} password: {person1.password} email: {person1.email}");
                }
            }
        }

            private void Button_JSON_Click(object sender, RoutedEventArgs e)
            {

                using (FileStream fs = new FileStream(PATH + ".json", FileMode.OpenOrCreate))
                {
                    List<User> person = JsonSerializer.Deserialize<List<User>>(fs);
                    foreach (var person1 in person)
                    {
                        inputRes.Text += ($"*JSON* User: {person1.login} password: {person1.password} email: {person1.email}");
                    }
                }
            }

            private void Button_BackSerDes_Click(object sender, RoutedEventArgs e)
            {
                UserSerDeser windowSerDesr = new UserSerDeser(person);
                windowSerDesr.Show();
                Close();
            }
        
    } 
}
