using System.Data.OleDb;
using System.Windows.Forms;

namespace Film_Festival_App
{
    public partial class AddPartFilmForm : Form
    {
        public static string connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=FFDB.mdb";
        public OleDbConnection myConnection;
        public OleDbCommand cmd;
        public static long Id;
        public static string type;
        public AddPartFilmForm()
        {
            InitializeComponent();
            myConnection = new OleDbConnection(connectionString);
            type = "Фильм";
        }
        private void button_close_Click(object sender, System.EventArgs e) => this.Close();
        private void button_add_participant_film_Click(object sender, System.EventArgs e)
        {
            myConnection.Open();
            cmd = new OleDbCommand($"SELECT MAX([Id участника]) FROM [Участник]", myConnection);
            Id = long.Parse(cmd.ExecuteScalar().ToString());

            cmd = new OleDbCommand($"INSERT INTO[Участник]([Id участника], [Тип], [Количество голосов]) VALUES({++Id}, [@Тип], [@Количество_голосов])", myConnection);
            cmd.Parameters.AddWithValue("@Тип", type);
            cmd.Parameters.AddWithValue("@Количество_голосов", this.textBox5.Text);
            cmd.ExecuteNonQuery();
            cmd = new OleDbCommand($"INSERT INTO [Фильм]([Id участника], [Название фильма], [Бюджет], [Жанр], [Страна], [Дата выхода], [Режиссёр], [Оценка]) VALUES({Id}, [@Название_фильма], [@Бюджет], [@Жанр], [@Страна], [@Дата_выхода], [@Режиссёр], [@Оценка])", myConnection); ;
            cmd.Parameters.AddWithValue("@Название_фильма", this.textBox1.Text);
            cmd.Parameters.AddWithValue("@Бюджет", int.Parse(this.textBox2.Text));
            cmd.Parameters.AddWithValue("@Жанр", this.comboBox1.Text);
            cmd.Parameters.AddWithValue("@Страна", this.comboBox2.Text);
            cmd.Parameters.AddWithValue("@Дата_выхода", this.dateTimePicker1);
            cmd.Parameters.AddWithValue("@Режиссёр", this.textBox3.Text);
            cmd.Parameters.AddWithValue("@Оценка", float.Parse(this.textBox4.Text));
            cmd.ExecuteNonQuery();
            myConnection.Close();
            Close();
        }
    }
}