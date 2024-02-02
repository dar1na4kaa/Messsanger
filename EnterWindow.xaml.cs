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
        static SqlConnection conn;
        public EnterWindow()
        {
            InitializeComponent();
        }

        private void enterButton_Click(object sender, RoutedEventArgs e)
        {
            conn = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB; Initial Catalog=Messanger; Integrated Security=SSPI;");
            errorTextBlock.Text = "";
            string enteredLogin = loginBox.Text;
            string enteredPassword = passwordBox.Password;
            string query = $"SELECT COUNT(*) FROM [User] WHERE Email='{enteredLogin}' AND Password='{enteredPassword}'";

            using (SqlCommand command = new SqlCommand(query, conn))
            {
                conn.Open();
                int count = (int)command.ExecuteScalar();
                conn.Close();

                if (count > 0)
                {
                    SmsWindow smsWindow = new SmsWindow();
                    smsWindow.Show();
                    this.Close();
                }
                else
                {
                    errorTextBlock.Text = "Неправильный логин или пароль!";
                }
            }
        }
    }
}