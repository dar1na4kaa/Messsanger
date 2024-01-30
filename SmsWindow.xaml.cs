using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
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
    /// Логика взаимодействия для SmsWindow.xaml
    /// </summary>
    public partial class SmsWindow : Window
    {
        SqlConnection conn = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB; Initial Catalog=Messanger; Integrated Security=SSPI;");
        int idUser = 1;

        public SmsWindow()
        {
            InitializeComponent();
           string text = "";
           string insertCommand = @"SELECT Message.Id_User,[User].Name,Message.Sms FROM [User],Message where [User].Id = Message.Id_User;";
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(insertCommand, conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    if ((int)rdr[0] == idUser)
                    {
                        text += rdr[1] + "\n" + rdr[2] + "\n";
                    }
                    else
                    {
                        text += rdr[1] + "\n" + rdr[2] + "\n";
                    }
                }
                conn.Close();
            }
            catch
            {
                MessageBox.Show("Ошибка");
            }
            Scroll.ScrollToEnd();
                textBlock.Text = text;
        }

        private void ResetClick(object sender, RoutedEventArgs e)
        {
            string text = "";
            string insertCommand = @"SELECT Message.Id_User,[User].Name,Message.Sms FROM [User],Message where [User].Id = Message.Id_User;";
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(insertCommand, conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    if ((int)rdr[0] == idUser)
                    {
                        text += rdr[1] + "\n" + rdr[2] + "\n";
                    }
                    else
                    {
                        text += rdr[1] + "\n" + rdr[2] + "\n";
                    }
                }
                conn.Close();
            }
            catch
            {
                MessageBox.Show("Ошибка");
            }
            Scroll.ScrollToEnd();
            textBlock.Text = text;
        }

        private void SendClick(object sender, RoutedEventArgs e)
        {
            try
            {
                conn.Open();
                string insertCommand = @"INSERT INTO Message VALUES (" + idUser + ", '"+smsBox.Text+"');";
                SqlCommand cmd = new SqlCommand(insertCommand,conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                ResetClick(sender,e);
            }
            catch
            {
                MessageBox.Show("Ошибка");
            }
        }

        private void OutToMainClick(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
