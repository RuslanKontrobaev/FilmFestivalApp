using System;
using System.Data.OleDb;
using System.Windows.Forms;

namespace Film_Festival_App
{
    public partial class AddPartHumanForm : Form
    {
        public static string connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=FFDB.mdb";
        public OleDbConnection myConnection;
        public OleDbCommand cmd;
        private static long Id;
        public static string type;
        public AddPartHumanForm()
        {
            InitializeComponent();
            myConnection = new OleDbConnection(connectionString);
            type = "Человек";
        }
        private void button_close_Click(object sender, EventArgs e) => this.Close();
        private void button_add_participant_human_Click(object sender, EventArgs e)
        {
            myConnection.Open();
            cmd = new OleDbCommand($"SELECT MAX([Id участника]) FROM [Участник]", myConnection);
            Id = long.Parse(cmd.ExecuteScalar().ToString());

            cmd = new OleDbCommand($"INSERT INTO [Участник] ([Id участника], [Тип], [Количество голосов]) VALUES ({++Id}, [@Тип], [@Количество_голосов])", myConnection);
            cmd.Parameters.AddWithValue("@Тип", type);
            cmd.Parameters.AddWithValue("@Количество_голосов", this.textBox2.Text);
            cmd.ExecuteNonQuery();
            cmd = new OleDbCommand($"INSERT INTO [Человек] ([Id участника], [Полное имя человека], [Дата рождения], [Пол]) VALUES ({Id}, [@Полное_имя_человека], [@Дата рождения], [@Пол])", myConnection);
            cmd.Parameters.AddWithValue("@Полное_имя_человека", this.textBox1.Text);
            cmd.Parameters.AddWithValue("@Дата_рождения", this.dateTimePicker1.Text);
            cmd.Parameters.AddWithValue("@Пол", this.comboBox1.Text);
            cmd.ExecuteNonQuery();
            myConnection.Close();
            Close();
        }
    }
}