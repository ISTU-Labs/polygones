using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WorkingWithDB1
{
    public partial class Lab3 : Form
    {
        SqlConnection sqlConnection;

        public Lab3()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private async void button3_Click(object sender, EventArgs e)
        {
            if (label7.Visible)
                label7.Visible = false;

            if (!string.IsNullOrEmpty(textBox6.Text) && !string.IsNullOrWhiteSpace(textBox6.Text))
            {
                SqlCommand command = new SqlCommand("DELETE FROM [Libraries] WHERE [Id]=@Id", sqlConnection);

                command.Parameters.AddWithValue("Id", textBox6.Text);

                await command.ExecuteNonQueryAsync();
            }
            else
            {
                label14.Visible = true;
                label14.Text = "ID должен быть заполнен!";
            }

        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "newLibraryDataSet2.On_hahd". При необходимости она может быть перемещена или удалена.
            this.on_hahdTableAdapter1.Fill(this.newLibraryDataSet2.On_hahd);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "newLibraryDataSet1.On_hahd". При необходимости она может быть перемещена или удалена.
            this.on_hahdTableAdapter.Fill(this.newLibraryDataSet1.On_hahd);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "newLibraryDataSet.On_lib". При необходимости она может быть перемещена или удалена.
            this.on_libTableAdapter.Fill(this.newLibraryDataSet.On_lib);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "booksDataSet1.Libraries". При необходимости она может быть перемещена или удалена.

            // TODO: данная строка кода позволяет загрузить данные в таблицу "booksDataSet.Owners". При необходимости она может быть перемещена или удалена.

            string connectionString = @"Data Source=LUCKY\sqlexpress;Initial Catalog=NewLibrary;Integrated Security=True";

            sqlConnection = new SqlConnection(connectionString);

            await sqlConnection.OpenAsync();

            SqlDataReader sqlReader = null;

            SqlCommand command = new SqlCommand("SELECT * FROM [On_lib]", sqlConnection);

            try
            {
                sqlReader = await command.ExecuteReaderAsync();

                while (await sqlReader.ReadAsync())
                {
                    listBox1.Items.Add(Convert.ToString(sqlReader["AUTHOR"]) + "  " + Convert.ToString(sqlReader["Name"]) + "  " + Convert.ToString(sqlReader["COUNT"]));

                }

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (sqlReader != null)
                    sqlReader.Close();
            }
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sqlConnection != null && sqlConnection.State != ConnectionState.Broken)
                sqlConnection.Close();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (sqlConnection != null && sqlConnection.State != ConnectionState.Broken)
                sqlConnection.Close();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (label7.Visible)
                label7.Visible = false;

            if (!string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrWhiteSpace(textBox1.Text) &&
                !string.IsNullOrEmpty(textBox2.Text) && !string.IsNullOrWhiteSpace(textBox2.Text))
            {
                SqlCommand command = new SqlCommand("INSERT INTO [On_lib] (Инвентарный номер, Автор, Название, Издательство, Год)VALUES(@Inv int, @Aut, @Name, @Izd, @Year)", sqlConnection);

                command.Parameters.AddWithValue("Инвентарный номер", textBox1.Text);
                command.Parameters.AddWithValue("Автор", textBox2.Text);
                command.Parameters.AddWithValue("Название", textBox7.Text);
                command.Parameters.AddWithValue("Издательство", textBox8.Text);
                command.Parameters.AddWithValue("Год", textBox9.Text);

                await command.ExecuteNonQueryAsync();
            }
            else
            {
                label7.Visible = true;
                label7.Text = "поля 'имя' и 'адрес' должны быть заполнены!";
            }
        }

        private async void обновитьToolStripMenuItem_Click(object sender, EventArgs e)
        {

            dataGridView1.Refresh();
            dataGridView2.Refresh();
            listBox1.Items.Clear();
            SqlDataReader sqlReader = null;
            SqlCommand command = new SqlCommand("SELECT * FROM [On_lib]", sqlConnection);

            this.on_hahdTableAdapter.Fill(this.newLibraryDataSet1.On_hahd);

            try
            {
                sqlReader = await command.ExecuteReaderAsync();


                while (await sqlReader.ReadAsync())
                {
                    listBox1.Items.Add(Convert.ToString(sqlReader["AUTHOR"]) + "  " + Convert.ToString(sqlReader["Name"]) + "  " + Convert.ToString(sqlReader["COUNT"]));
                }

            }
            catch (Exception)
            {

            }
            finally
            {
                if (sqlReader != null)
                    sqlReader.Close();
            }
        }

        private async void button4_Click(object sender, EventArgs e)
        {
            if (label7.Visible)
                label7.Visible = false;

            if (!string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrWhiteSpace(textBox1.Text) &&
                !string.IsNullOrEmpty(textBox2.Text) && !string.IsNullOrWhiteSpace(textBox2.Text))
            {
                SqlCommand command = new SqlCommand("INSERT INTO [On_hahd] (Id, Читатель, Адрес, Год, Название, Инвентарный_номер)VALUES(@Id int, @Owner, @Adr, @Year, @Name, @Inv int)", sqlConnection);

                command.Parameters.AddWithValue("Id", textBox10.Text);
                command.Parameters.AddWithValue("Читатель", textBox11.Text);
                command.Parameters.AddWithValue("Адрес", textBox8.Text);
                command.Parameters.AddWithValue("Год", textBox1.Text);
                command.Parameters.AddWithValue("Название", textBox2.Text);
                command.Parameters.AddWithValue("Инвентарный_номер", textBox12.Text);

                await command.ExecuteNonQueryAsync();
            }
            else
            {
                label7.Visible = true;
                label7.Text = "поля 'имя' и 'адрес' должны быть заполнены!";
            }

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private async void button2_Click(object sender, EventArgs e)
        {
            if (label15.Visible)
                label15.Visible = false;

            if (!string.IsNullOrEmpty(textBox3.Text) && !string.IsNullOrWhiteSpace(textBox3.Text) &&
                !string.IsNullOrEmpty(textBox4.Text) && !string.IsNullOrWhiteSpace(textBox4.Text) &&
                !string.IsNullOrEmpty(textBox5.Text) && !string.IsNullOrWhiteSpace(textBox5.Text))
            {
                SqlCommand command = new SqlCommand("UPDATE [Libraries] SET [Year]=@year, [Count]=@count WHERE [Id]=@id", sqlConnection);
                command.Parameters.AddWithValue("Id", textBox5.Text);
                command.Parameters.AddWithValue("Year", textBox4.Text);
                command.Parameters.AddWithValue("Count", textBox3.Text);

                await command.ExecuteNonQueryAsync();
            }
            else if (!string.IsNullOrEmpty(textBox4.Text) && !string.IsNullOrWhiteSpace(textBox4.Text))
            {
                label15.Visible = true;
                label15.Text = "ID должен быть заполнен!";
            }
            else
            {
                label15.Visible = true;
                label15.Text = "поля 'год', 'Id'  и 'колличество' должны быть заполнены!";
            }
        }

        private async void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (label7.Visible)
                label7.Visible = false;

            if (!string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrWhiteSpace(textBox1.Text) &&
                !string.IsNullOrEmpty(textBox2.Text) && !string.IsNullOrWhiteSpace(textBox2.Text))
            {
                SqlCommand command = new SqlCommand("INSERT INTO [On_lib] (Инвентарный номер, Автор, Название, Издательство, Год)VALUES(@Inv int, @Aut, @Name, @Izd, @Year)", sqlConnection);

                command.Parameters.AddWithValue("Инвентарный номер", textBox1.Text);
                command.Parameters.AddWithValue("Автор", textBox2.Text);
                command.Parameters.AddWithValue("Название", textBox7.Text);
                command.Parameters.AddWithValue("Издательство", textBox8.Text);
                command.Parameters.AddWithValue("Год", textBox9.Text);

                await command.ExecuteNonQueryAsync();
            }
            else
            {
                label7.Visible = true;
                label7.Text = "поля 'имя' и 'адрес' должны быть заполнены!";
            }

        }
    }
}
