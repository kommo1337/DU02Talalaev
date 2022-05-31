using DU02Talalaev.Class_Folder;
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

namespace DU02Talalaev.Window_Folder.UserFolder
{
    /// <summary>
    /// Логика взаимодействия для AddCustomerWindow.xaml
    /// </summary>
    public partial class AddCustomerWindow : Window
    {
        
        SqlConnection sqlConnection = new SqlConnection(@"Data Source=K306PC10\SQLEXPRESS;
                                                        Initial Catalog=UP02Talalaev;
                                                        Integrated Security=True");
        SqlCommand SqlCommand;
        public AddCustomerWindow()
        {
            InitializeComponent();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {

            if (string.IsNullOrWhiteSpace(LastNameTb.Text))
            {
                MBClass.ErrorMb("Не введена фамилия");
                LastNameTb.Focus();
            }
            else if (string.IsNullOrWhiteSpace(FirstNameTb.Text))
            {
                MBClass.ErrorMb("Не введено имя");
                FirstNameTb.Focus();
            }
            else if (string.IsNullOrWhiteSpace(NumberPhoneTb.Text))
            {
                MBClass.ErrorMb("Номер телефона не введен");
                NumberPhoneTb.Focus();
            }
            else if (string.IsNullOrWhiteSpace(BirthTb.Text))
            {
                MBClass.ErrorMb("Дата рождения не введена");
                BirthTb.Focus();
            }
            else
            {
                try
                {
                    sqlConnection.Open();
                    SqlCommand = new SqlCommand("Insert Into dbo.[Customer] " +
                        "(LastNameCustomer, FirstNameCustomer, MiddleNameCustomer, NumberPhoneCustomer, EmailCustomer, DateOfBirthCustomer) " +
                        $"Values ('{FirstNameTb.Text}'," +
                        $"'{LastNameTb.Text}'," +
                        $"'{LastNameTb.Text}'," +
                        $"'{NumberPhoneTb.Text}'," +
                        $"'{EmailTb.Text}'," +
                        $"'{BirthTb.Text}')",
                        sqlConnection);
                    SqlCommand.ExecuteNonQuery();
                    MBClass.InfoMb($"Заказчик {FirstNameTb.Text} " +
                        $"{LastNameTb.Text} успешно добавлен");
                }
                catch (Exception ex)
                {
                    MBClass.ErrorMb(ex);
                }
                finally
                {
                    sqlConnection.Close();
                }
            }
        }


        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            MBClass.ExitMB();
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            new MenuUserWindow().Show();
            Close();
        }
    }
}
