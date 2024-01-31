using System;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

namespace Messsanger
{
    /// <summary>
    /// Логика взаимодействия для EnterWindow.xaml
    /// </summary>
    public partial class EnterWindow : Window
    {
        static SqlConnection conn = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB; Initial Catalog=Messanger; Integrated Security=SSPI;");
        public EnterWindow()
        {
            InitializeComponent();
        }

        private void enterButton_Click(object sender, RoutedEventArgs e)
        {
            conn.Open();
            errorTextBlock.Text = "";
            string email = "";
            string password = "";
            string query = @"select Email, Password from [User]";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = query;

            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                email = reader[0].ToString();
                password = reader[1].ToString();
                if (email == loginBox.Text.Trim() && password == passwordBox.Password)
                {
                    SmsWindow smsWindow = new SmsWindow();
                    smsWindow.Show();
                    this.Close();
                }
            }
            conn.Close();
        }
    }
}