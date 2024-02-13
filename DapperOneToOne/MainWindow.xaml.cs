using Dapper;
using DapperOneToOne.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DapperOneToOne
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var conn = ConfigurationManager.ConnectionStrings["MyConn"].ConnectionString;
            using (var connection = new SqlConnection(conn))
            {
                var sql = @"   SELECT CAP.CapitalId,CAP.Name,CAP.CountryId,
                                C.CountryId,C.Name
                                FROM Capitals AS CAP
                                INNER JOIN Countries AS C
                                ON CAP.CountryId=C.CountryId
";

                var capitals = connection.Query<Capital, Country, Capital>(sql,
                    (capital, country) =>
                    {
                        capital.Country = country;
                        return capital;
                    }, splitOn: "CountryId");

                myDataGrid.ItemsSource = capitals;
            }
        }
    }
}
