using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DU02Talalaev.Class_Folder;
using System.Windows.Controls;


namespace DU02Talalaev.Class_Folder
{
    class CBClass
    {
        SqlConnection SqlConnection = new SqlConnection(@"Data Source=K306PC10\SQLEXPRESS;
                                                        Initial Catalog=UP02Talalaev;
                                                        Integrated Security=True");
        SqlDataAdapter sqlData;
        DataSet dataSet;
        public void RoleCBLoad(ComboBox comboBox)
        {
            try
            {
                SqlConnection.Open();
                sqlData = new SqlDataAdapter("Select RoleID, RoleName " +
                    "From dbo.[Role] Order by RoleID ASC",
                    SqlConnection);
                dataSet = new DataSet();
                sqlData.Fill(dataSet, "[Role]");
                comboBox.ItemsSource = dataSet.Tables["[Role]"].DefaultView;
                comboBox.DisplayMemberPath = dataSet.
                    Tables["[Role]"].Columns["RoleName"].ToString();
                comboBox.SelectedValuePath = dataSet.
                   Tables["[Role]"].Columns["RoleID"].ToString();
            }
            catch (Exception ex)
            {
                MBClass.ErrorMb(ex);
            }
            finally
            {
                SqlConnection.Close();
            }
        }

    }
}

