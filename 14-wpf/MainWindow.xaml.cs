using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
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

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string conStr = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=vetclinic;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        private SqlConnection con; 

        public MainWindow()
        {
            con = new SqlConnection(conStr);
            con.Open();
            InitializeComponent();
            LoadPetData();
            PopulateOwners();
        }

        public void LoadPetData()
        {
            string sql = "SELECT * FROM Pets";

            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable("Pets");
            adapter.Fill(table);

            PetGrid.ItemsSource = table.DefaultView;
        }

        public void PopulateOwners()
        {
            string sql = "SELECT * FROM Owners";

            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adapter.Fill(ds);

            Owners.ItemsSource = ds.Tables[0].DefaultView;
            Owners.DisplayMemberPath = "Name";
            Owners.SelectedValuePath = "Id";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string sql = "INSERT INTO Pets (Name, Species, OwnerID) VALUES (@name, @species, @id)";

            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@name", PetName.Text);
            cmd.Parameters.AddWithValue("@species", PetSpecies.Text);
            cmd.Parameters.AddWithValue("@id", Owners.SelectedIndex);

            int result = cmd.ExecuteNonQuery();
            if(result < 0)
            {
                Trace.WriteLine("Insert failed");
            }
            else
            {
                LoadPetData();
            }
        }
    }
}
