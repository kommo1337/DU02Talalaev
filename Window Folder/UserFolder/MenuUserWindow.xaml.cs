using DU02Talalaev.Class_Folder;
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

namespace DU02Talalaev.Window_Folder.UserFolder
{
    /// <summary>
    /// Логика взаимодействия для MenuUserWindow.xaml
    /// </summary>
    public partial class MenuUserWindow : Window
    {
        DGClass dGClass;
        public MenuUserWindow()
        {
            InitializeComponent();
            dGClass = new DGClass(ListUserDG);
        }

        private void ListUserDG_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (ListUserDG.SelectedItem == null)
            {
                MBClass.ErrorMb("Вы не выбрали строку");
            }
            else
            {
                try
                {
                    VariableClass.CustomerId = dGClass.SelectId();
                    new EditCustomerWindow().ShowDialog();
                    dGClass.LoadDG("Select * From dbo.[Customer]");
                }
                catch (Exception ex)
                {
                    MBClass.ErrorMb(ex);
                }
            }
        }

        private void SearchTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            dGClass.LoadDG("Select * From dbo.[Customer] " +
                $"Where LastNameCustomer Like '%{SearchTb.Text}%' " +
                $"OR EmailCustomer Like '%{SearchTb.Text}%' " +
                $"OR NumberPhoneCustomer Like '%{SearchTb.Text}%'");
        }

        private void AddIm_Click(object sender, RoutedEventArgs e)
        {
            new AddCustomerWindow().ShowDialog();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dGClass.LoadDG("Select * From dbo.[Customer]");
        }
    }
}
