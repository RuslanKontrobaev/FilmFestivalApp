using System;
using System.Data.OleDb;
using System.Windows.Forms;

namespace Film_Festival_App
{
    public partial class AddCinemaFestForm : Form
    {
        public static string connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=FFDB.mdb";
        public OleDbConnection myConnection;
        public static string query;
        public AddCinemaFestForm()
        {
            InitializeComponent();
            myConnection = new OleDbConnection(connectionString);
        }
        private void button_close_Click(object sender, EventArgs e) => this.Close();
        private void button_addFest_Click(object sender, EventArgs e)
        {
            myConnection.Open();
            OleDbCommand cmd = new OleDbCommand($"INSERT INTO [Кинофестиваль]([Название кинофестиваля], [Место проведения]) VALUES([@Название_кинофестиваля], [@Место_проведения])", myConnection); ;
            cmd.Parameters.AddWithValue("@Название_кинофестиваля", this.textBox_nameFest.Text);
            cmd.Parameters.AddWithValue("@Место_проведения", this.textBox_location.Text);
            cmd.ExecuteNonQuery();
            myConnection.Close();
            Close();
        }
    }
}
