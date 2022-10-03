using System.Windows;
using System.Text.Json;
using System.Xml.Serialization;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;
using Excel = Microsoft.Office.Interop.Excel;


namespace WpfApp1
{
    public partial class Serialization_xaml : System.Windows.Window
    {
        List<User> person;
        string PATH = "C:\\Users\\Sergei\\Desktop\\person";

        public Serialization_xaml(List<User> person_from_main)
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

            XmlSerializer writer = new XmlSerializer(typeof(List<User>));

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

            var excelApp = new Excel.Application();
            excelApp.Workbooks.Add();
            Excel.Worksheet worksheet = (Excel.Worksheet)excelApp.ActiveSheet;

            worksheet.Range["A1"].Value = "Login";
            worksheet.Range["B1"].Value = "Password";
            worksheet.Range["C1"].Value = "Email";

            for (int i = 0; i < person.Count; i++)
            {
                worksheet.Cells[i + 2, 1] = person[i].login;
                worksheet.Cells[i + 2, 2] = person[i].password;
                worksheet.Cells[i + 2, 3] = person[i].email;
            }
            excelApp.Visible = true;

        }

        private void Button_BackSer_Click(object sender, RoutedEventArgs e)
        {
            UserSerDeser windowSerDesr = new UserSerDeser(person);
            windowSerDesr.Show();
            Close();
        }
    }
}
