using System;
using System.Data.OleDb;
using System.Windows.Forms;

namespace Film_Festival_App
{
    public partial class AddGuestForm : Form
    {
        public static string connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=FFDB.mdb";
        public OleDbConnection myConnection;
        public static string query;
        public OleDbCommand cmd;
        public AddGuestForm()
        {
            InitializeComponent();
            myConnection = new OleDbConnection(connectionString);
            dateTimePicker_bd.Format = DateTimePickerFormat.Short;
        }
        private void button_close_Click(object sender, EventArgs e) => this.Close();
        private void button_addGuest_Click(object sender, EventArgs e)
        {
            myConnection.Open();
            cmd = new OleDbCommand($"INSERT INTO [Гость]([Полное имя гостя], [Дата рождения]) VALUES([@Полное_имя_гостя], [@Дата_рождения])", myConnection); ;
            cmd.Parameters.AddWithValue("@Полное_имя_гостя", this.textBox_nameGuest.Text);
            cmd.Parameters.AddWithValue("@Дата_рождения", this.dateTimePicker_bd.Text);
            cmd.ExecuteNonQuery();
            myConnection.Close();
            Close();
        }
    }
}
