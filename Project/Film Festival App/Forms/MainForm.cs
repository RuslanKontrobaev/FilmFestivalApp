using System;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Film_Festival_App
{
    public partial class MainForm : Form
    {
        public static string connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=FFDB.mdb";
        public OleDbConnection myConnection;
        public OleDbCommand cmd;
        public OleDbDataReader dbReader;
        public MainForm()
        {
            InitializeComponent();
            myConnection = new OleDbConnection(connectionString);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            myConnection.Open();
            cmd = new OleDbCommand("SELECT * FROM Кинофестиваль", myConnection);
            dbReader = cmd.ExecuteReader();
            if (dbReader.HasRows == false) MessageBox.Show("Данные не найдены!", "Ошибка!");
            else
                while (dbReader.Read())
                    dataGridView_cinema_fest.Rows.Add(dbReader["Название кинофестиваля"], dbReader["Место проведения"]);
            dbReader.Close();

            cmd = new OleDbCommand("SELECT * FROM Гость", myConnection);
            dbReader = cmd.ExecuteReader();
            if (dbReader.HasRows == false) MessageBox.Show("Данные не найдены!", "Ошибка!");
            else
                while (dbReader.Read())
                    dataGridView_guest.Rows.Add(dbReader["Полное имя гостя"], dbReader["Дата рождения"]);
            dbReader.Close();

            cmd = new OleDbCommand("SELECT * FROM Фильм", myConnection);
            dbReader = cmd.ExecuteReader();
            if (dbReader.HasRows == false) MessageBox.Show("Данные не найдены!", "Ошибка!");
            else
                while (dbReader.Read())
                    dataGridView_participant_film.Rows.Add(dbReader["Id участника"], dbReader["Название фильма"], dbReader["Бюджет"], dbReader["Жанр"], dbReader["Страна"], dbReader["Дата выхода"], dbReader["Режиссёр"], dbReader["Оценка"]);
            dbReader.Close();

            cmd = new OleDbCommand("SELECT * FROM Человек", myConnection);
            dbReader = cmd.ExecuteReader();
            if (dbReader.HasRows == false) MessageBox.Show("Данные не найдены!", "Ошибка!");
            else
                while (dbReader.Read())
                    dataGridView_participant_human.Rows.Add(dbReader["Id участника"], dbReader["Полное имя человека"], dbReader["Дата рождения"], dbReader["Пол"]);
            dbReader.Close();
            myConnection.Close();
        }
        private void button_addCinemaFest_Click(object sender, EventArgs e)
        {
            AddCinemaFestForm newform = new AddCinemaFestForm();
            newform.Owner = this;
            newform.Show();
        }
        private void button_delCinemaFest_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите удалить кинофестиваль?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                myConnection.Open();
                cmd = new OleDbCommand($"DELETE FROM [Кинофестиваль] WHERE [Название кинофестиваля] = [@Название_кинофестиваля]", myConnection);
                cmd.Parameters.AddWithValue("@Название_кинофестиваля", this.dataGridView_cinema_fest.Rows[this.dataGridView_cinema_fest.CurrentRow.Index].Cells["name"].Value.ToString());
                cmd.ExecuteNonQuery();
                myConnection.Close();
            }
        }
        private void button_refreshCinemaFest_Click(object sender, EventArgs e)
        {
            this.dataGridView_cinema_fest.Rows.Clear();
            this.dataGridView_cinema_fest.Columns.Clear();
            this.dataGridView_cinema_fest.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { this.name, this.location });
            myConnection.Open();
            cmd = new OleDbCommand("SELECT * FROM Кинофестиваль", myConnection);
            dbReader = cmd.ExecuteReader();
            if (dbReader.HasRows == false) MessageBox.Show("Данные не найдены!", "Ошибка!");
            else
                while (dbReader.Read())
                    dataGridView_cinema_fest.Rows.Add(dbReader["Название кинофестиваля"], dbReader["Место проведения"]);
            dbReader.Close();
            myConnection.Close();
        }
        private void button_exitCinemaFest_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Вы действительно хотите выйти из приложения?", "Выход", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (dr == DialogResult.OK) Application.Exit();
        }

        private void button_add_guest_Click(object sender, EventArgs e)
        {
            AddGuestForm newform = new AddGuestForm();
            newform.Owner = this;
            newform.Show();
        }
        private void button_select_guest_Click(object sender, EventArgs e)
        {
            myConnection.Open();
            cmd = new OleDbCommand($"SELECT [Название кинофестиваля], [Дата], [Ряд], [Место] FROM [Посещал] WHERE [Полное имя гостя] = [@name]", myConnection);
            cmd.Parameters.AddWithValue("@name", this.dataGridView_guest.Rows[this.dataGridView_guest.CurrentRow.Index].Cells["name_g"].Value.ToString());
            dbReader = cmd.ExecuteReader();
            if (dbReader.HasRows == false) MessageBox.Show("Данные о посещении не найдены!", "Ошибка!");
            else
                while (dbReader.Read())
                    dataGridView_guest_visit.Rows.Add(dbReader["Название кинофестиваля"], dbReader["Дата"], dbReader["Ряд"], dbReader["Место"]);
            dbReader.Close();

            cmd = new OleDbCommand($"SELECT [Название кинофестиваля], [Дата], [Id участника] FROM [Голосовал] WHERE [Полное имя гостя] = [@name]", myConnection);
            cmd.Parameters.AddWithValue("@name", this.dataGridView_guest.Rows[this.dataGridView_guest.CurrentRow.Index].Cells["name_g"].Value.ToString());
            dbReader = cmd.ExecuteReader();
            if (dbReader.HasRows == false) MessageBox.Show("Данные о голосовании не найдены!", "Ошибка!");
            else
                while (dbReader.Read())
                    dataGridView_guest_vote.Rows.Add(dbReader["Название кинофестиваля"], dbReader["Дата"], dbReader["Id участника"]);
            dbReader.Close();
            myConnection.Close();
        }
        private void button_del_guest_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите удалить гостя?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                myConnection.Open();
                cmd = new OleDbCommand($"DELETE FROM [Гость] WHERE [Полное имя гостя] = [@Полное_имя_гостя]", myConnection);
                cmd.Parameters.AddWithValue("@Полное_имя_гостя", this.dataGridView_guest.Rows[this.dataGridView_guest.CurrentRow.Index].Cells["name_g"].Value.ToString());
                cmd.ExecuteNonQuery();
                myConnection.Close();
            }
        }
        private void button_refresh_guest_Click(object sender, EventArgs e)
        {
            this.dataGridView_guest.Rows.Clear();
            this.dataGridView_guest.Columns.Clear();
            this.dataGridView_guest.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { this.name_g, this.dateBD });
            this.dataGridView_guest_vote.Rows.Clear();
            this.dataGridView_guest_vote.Columns.Clear();
            this.dataGridView_guest_vote.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { this.Column5, this.Column6, this.Column7 });
            this.dataGridView_guest_visit.Rows.Clear();
            this.dataGridView_guest_visit.Columns.Clear();
            this.dataGridView_guest_visit.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { this.Column1, this.Column2, this.Column3, this.Column4 });
            myConnection.Open();
            cmd = new OleDbCommand("SELECT * FROM Гость", myConnection);
            dbReader = cmd.ExecuteReader();
            if (dbReader.HasRows == false) MessageBox.Show("Данные не найдены!", "Ошибка!");
            else
                while (dbReader.Read())
                    dataGridView_guest.Rows.Add(dbReader["Полное имя гостя"], dbReader["Дата рождения"]);
            dbReader.Close();
            myConnection.Close();
        }
        private void button_exit_guest_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Вы действительно хотите выйти из приложения?", "Выход", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (dr == DialogResult.OK) Application.Exit();
        }
        private void dataGridView_guest_CellDoubleClick(object sender, DataGridViewCellEventArgs e) => button_select_guest_Click(sender, e);


        private void button_add_participant_film_Click(object sender, EventArgs e)
        {
            AddPartFilmForm newform = new AddPartFilmForm();
            newform.Owner = this;
            newform.Show();
        }
        private void button_select_participant_film_Click(object sender, EventArgs e)
        {
            myConnection.Open();
            cmd = new OleDbCommand($"SELECT [Название кинофестиваля], [Дата] FROM [Участвовал] WHERE [Id участника] = [@Id]", myConnection);
            cmd.Parameters.AddWithValue("@Id", this.dataGridView_participant_film.Rows[this.dataGridView_participant_film.CurrentRow.Index].Cells["id"].Value.ToString());
            dbReader = cmd.ExecuteReader();
            if (dbReader.HasRows == false) MessageBox.Show("Данные об участии не найдены!", "Ошибка!");
            else
                while (dbReader.Read())
                    dataGridView_participant_film_take_part.Rows.Add(dbReader["Название кинофестиваля"], dbReader["Дата"]);
            dbReader.Close();

            cmd = new OleDbCommand($"SELECT [Название кинофестиваля], [Дата], [Наименование номинации], [Категория], [Результат] FROM [Номинирован/награждён] WHERE [Id участника] = [@Id]", myConnection);
            cmd.Parameters.AddWithValue("@id", this.dataGridView_participant_film.Rows[this.dataGridView_participant_film.CurrentRow.Index].Cells["id"].Value.ToString());
            dbReader = cmd.ExecuteReader();
            if (dbReader.HasRows == false) MessageBox.Show("Данные о номинациях/награждениях не найдены!", "Ошибка!");
            else
                while (dbReader.Read())
                    dataGridView_participant_film_nominated_awarded.Rows.Add(dbReader["Название кинофестиваля"], dbReader["Дата"], dbReader["Наименование номинации"], dbReader["Категория"], dbReader["Результат"]);
            dbReader.Close();
            myConnection.Close();
        }
        private void button_del_participant_film_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите удалить участника-фильм?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                myConnection.Open();
                cmd = new OleDbCommand($"DELETE FROM [Фильм] WHERE [Id участника] = [@Id]", myConnection);
                cmd.Parameters.AddWithValue("@Id", this.dataGridView_participant_film.Rows[this.dataGridView_participant_film.CurrentRow.Index].Cells["id"].Value.ToString());
                cmd.ExecuteNonQuery();
                cmd = new OleDbCommand($"DELETE FROM [Участник] WHERE [Id участника] = [@Id]", myConnection);
                cmd.Parameters.AddWithValue("@Id", this.dataGridView_participant_film.Rows[this.dataGridView_participant_film.CurrentRow.Index].Cells["id"].Value.ToString());
                cmd.ExecuteNonQuery();
                myConnection.Close();
            }
        }
        private void button_refresh_participant_film_Click(object sender, EventArgs e)
        {
            this.dataGridView_participant_film.Rows.Clear();
            this.dataGridView_participant_film.Columns.Clear();
            this.dataGridView_participant_film.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { this.id, this.name_film, this.Budget, this.Genre, this.Country, this.Date, this.Producer, this.Mark });
            this.dataGridView_participant_film_take_part.Rows.Clear();
            this.dataGridView_participant_film_take_part.Columns.Clear();
            this.dataGridView_participant_film_take_part.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { this.Column8, this.Column9 });
            this.dataGridView_participant_film_nominated_awarded.Rows.Clear();
            this.dataGridView_participant_film_nominated_awarded.Columns.Clear();
            this.dataGridView_participant_film_nominated_awarded.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { this.Column10, this.Column11, this.Column12, this.Column13, this.Column14 });
            myConnection.Open();
            cmd = new OleDbCommand("SELECT * FROM Фильм", myConnection);
            dbReader = cmd.ExecuteReader();
            if (dbReader.HasRows == false) MessageBox.Show("Данные не найдены!", "Ошибка!");
            else
                while (dbReader.Read())
                    dataGridView_participant_film.Rows.Add(dbReader["Id участника"], dbReader["Название фильма"], dbReader["Бюджет"], dbReader["Жанр"], dbReader["Страна"], dbReader["Дата выхода"], dbReader["Режиссёр"], dbReader["Оценка"]);
            dbReader.Close();
            myConnection.Close();
        }
        private void button_exit_participant_film_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Вы действительно хотите выйти из приложения?", "Выход", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (dr == DialogResult.OK) Application.Exit();
        }
        private void dataGridView_participant_film_CellDoubleClick(object sender, DataGridViewCellEventArgs e) => button_select_participant_film_Click(sender, e);

        private void button_add_participant_human_Click(object sender, EventArgs e)
        {
            AddPartHumanForm newform = new AddPartHumanForm();
            newform.Owner = this;
            newform.Show();
        }
        private void button_select_participant_human_Click(object sender, EventArgs e)
        {
            myConnection.Open();
            cmd = new OleDbCommand($"SELECT [Название кинофестиваля], [Дата] FROM [Участвовал] WHERE [Id участника] = [@Id]", myConnection);
            cmd.Parameters.AddWithValue("@Id", this.dataGridView_participant_human.Rows[this.dataGridView_participant_human.CurrentRow.Index].Cells["Column18"].Value.ToString());
            dbReader = cmd.ExecuteReader();
            if (dbReader.HasRows == false) MessageBox.Show("Данные об участии не найдены!", "Ошибка!");
            else
                while (dbReader.Read())
                    this.dataGridViewparticipant_human_take_part.Rows.Add(dbReader["Название кинофестиваля"], dbReader["Дата"]);
            dbReader.Close();

            cmd = new OleDbCommand($"SELECT [Название кинофестиваля], [Дата], [Наименование номинации], [Категория], [Результат] FROM [Номинирован/награждён] WHERE [Id участника] = [@Id]", myConnection);
            cmd.Parameters.AddWithValue("@id", this.dataGridView_participant_human.Rows[this.dataGridView_participant_human.CurrentRow.Index].Cells["Column18"].Value.ToString());
            dbReader = cmd.ExecuteReader();
            if (dbReader.HasRows == false) MessageBox.Show("Данные о номинациях/награждениях не найдены!", "Ошибка!");
            else
                while (dbReader.Read())
                    this.dataGridView_participant_human_nominated_awarded.Rows.Add(dbReader["Название кинофестиваля"], dbReader["Дата"], dbReader["Наименование номинации"], dbReader["Категория"], dbReader["Результат"]);
            dbReader.Close();

            cmd = new OleDbCommand($"SELECT [Название фильма], [В качестве кого] FROM [Принимал участие] WHERE [Полное имя человека] = [@Id]", myConnection);
            cmd.Parameters.AddWithValue("@Id", this.dataGridView_participant_human.Rows[this.dataGridView_participant_human.CurrentRow.Index].Cells["Column18"].Value.ToString());
            dbReader = cmd.ExecuteReader();
            if (dbReader.HasRows == false) MessageBox.Show("Данные об участии в фильмах не найдены!", "Ошибка!");
            else
                while (dbReader.Read())
                    this.dataGridView_part_in_film.Rows.Add(dbReader["Название фильма"], dbReader["В качестве кого"]);
            dbReader.Close();
            myConnection.Close();
        }
        private void button_del_participant_human_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите удалить участника-человека?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                myConnection.Open();
                cmd = new OleDbCommand($"DELETE FROM [Человек] WHERE [Id участника] = [@Id]", myConnection);
                cmd.Parameters.AddWithValue("@Id", this.dataGridView_participant_human.Rows[this.dataGridView_participant_human.CurrentRow.Index].Cells["Column18"].Value.ToString());
                cmd.ExecuteNonQuery();
                cmd = new OleDbCommand($"DELETE FROM [Участник] WHERE [Id участника] = [@Id]", myConnection);
                cmd.Parameters.AddWithValue("@Id", this.dataGridView_participant_human.Rows[this.dataGridView_participant_human.CurrentRow.Index].Cells["Column18"].Value.ToString());
                cmd.ExecuteNonQuery();
                myConnection.Close();
            }
        }
        private void button_refresh_participant_human_Click(object sender, EventArgs e)
        {
            this.dataGridView_participant_human.Rows.Clear();
            this.dataGridView_participant_human.Columns.Clear();
            this.dataGridView_participant_human.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { this.Column18, this.name_part_human, this.Column16, this.Column17 });
            this.dataGridViewparticipant_human_take_part.Rows.Clear();
            this.dataGridViewparticipant_human_take_part.Columns.Clear();
            this.dataGridViewparticipant_human_take_part.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { this.Column20, this.Column19 });
            this.dataGridView_participant_human_nominated_awarded.Rows.Clear();
            this.dataGridView_participant_human_nominated_awarded.Columns.Clear();
            this.dataGridView_participant_human_nominated_awarded.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { this.Column21, this.Column22, this.Column23, this.Column24, this.Column25 });
            this.dataGridView_part_in_film.Rows.Clear();
            this.dataGridView_part_in_film.Columns.Clear();
            this.dataGridView_part_in_film.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { this.id_film, this.Column27 });

            myConnection.Open();
            cmd = new OleDbCommand("SELECT * FROM [Человек]", myConnection);
            dbReader = cmd.ExecuteReader();
            if (dbReader.HasRows == false) MessageBox.Show("Данные не найдены!", "Ошибка!");
            else
                while (dbReader.Read())
                    dataGridView_participant_human.Rows.Add(dbReader["Id участника"], dbReader["Полное имя человека"], dbReader["Дата рождения"], dbReader["Пол"]);
            dbReader.Close();
            myConnection.Close();
        }
        private void button_exit_participant_human_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Вы действительно хотите выйти из приложения?", "Выход", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (dr == DialogResult.OK) Application.Exit();
        }
        private void dataGridView_participant_human_CellDoubleClick(object sender, DataGridViewCellEventArgs e) => button_select_participant_human_Click(sender, e);
    }
}