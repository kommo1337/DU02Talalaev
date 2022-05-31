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
using DU02Talalaev.Class_Folder;
using DU02Talalaev.Window_Folder.AdminFolder;

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
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dGClass.LoadDG("Select * From dbo.[Customer]");
        }

        private void SearchTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            dGClass.LoadDG("Select * From dbo.[Customer] " +
                $"Where LastName Like '%{SearchTb.Text}%' " +
                $"OR Email Like '%{SearchTb.Text}%'");
        }

        private void AddIm_Click(object sender, RoutedEventArgs e)
        {
            new AddUserWindow().ShowDialog();
            dGClass.LoadDG("Select * From dbo.[Customer]");
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
                    VariableClass.UserId = dGClass.SelectId();
                    new EditUserWindow().ShowDialog();
                    dGClass.LoadDG("Select * From dbo.[Customer]");
                }
                catch (Exception ex)
                {
                    MBClass.ErrorMb(ex);
                }
            }
        }
    }
}
