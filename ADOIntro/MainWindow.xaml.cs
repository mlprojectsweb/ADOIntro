using System;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Data.SqlClient;


namespace ADOIntro
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            const string conn = "Data Source=MSEDGEWIN10\\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=True;TrustServerCertificate=True";
            //SqlConnection sqlConn;
            //try
            //{
            //    sqlConn = new SqlConnection(conn);
            //}
            //catch (Exception e )
            //{

            //    throw e;
            //}
            //finally
            //{
            //     sqlConn.Close();
            //}


            using (SqlConnection sqlConn = new SqlConnection(conn))
            {
                sqlConn.Open();

                SqlCommand cmd = new SqlCommand();

                cmd.Connection = sqlConn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Select * from Users, Products";
                
                SqlDataAdapter adp =new SqlDataAdapter();
                adp.SelectCommand = cmd;
                DataSet dataSet = new DataSet();
                adp.Fill(dataSet);

                if(dataSet.Tables[0].Rows.Count > 0)
                {
                    var username = dataSet.Tables[0].Rows[0]["username"].ToString();
                    var password = dataSet.Tables[0].Rows[0]["password"].ToString();
                    var fullName = dataSet.Tables[0].Rows[0]["fullname"].ToString();

                }





                //SqlDataReader reader = cmd.ExecuteReader();

                //while (reader.Read())
                //{
                //    var field = reader.GetValue(0) + " " + reader.GetValue(1) + " " + reader.GetValue(2);
                //}


                sqlConn.Close();
            }
        }
    }
}
