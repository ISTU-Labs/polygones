using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Lab2New
{
    public partial class Lab3 : Form
    {
        SqlConnection sqlConnection;
        public Lab3()
        {
            InitializeComponent();
        }

        private async void Lab3_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "figuresDataSet3.Polygons". При необходимости она может быть перемещена или удалена.
            this.polygonsTableAdapter.Fill(this.figuresDataSet3.Polygons);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "figuresDataSet2.Rectangles". При необходимости она может быть перемещена или удалена.
            this.rectanglesTableAdapter.Fill(this.figuresDataSet2.Rectangles);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "figuresDataSet.Circles". При необходимости она может быть перемещена или удалена.
            this.circlesTableAdapter.Fill(this.figuresDataSet.Circles);


            string connectionString = @"Data Source=LUCKY\SQLEXPRESS;Initial Catalog=Figures;Integrated Security=True";

            sqlConnection = new SqlConnection(connectionString);
            await sqlConnection.OpenAsync();

            SqlDataReader sqlReader = null;

            SqlCommand command = new SqlCommand("SELECT * FROM [Circles]", sqlConnection);
            try
            {
                sqlReader = await command.ExecuteReaderAsync();

                while (await sqlReader.ReadAsync())
                {
                    listBox1.Items.Add(Convert.ToString(sqlReader["Y"]) + "  " + Convert.ToString(sqlReader["X"]) + "  " + Convert.ToString(sqlReader["Degree"]));
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
            this.reportViewer1.RefreshReport();
            this.reportViewer1.RefreshReport();
        }

        private void Lab3_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (sqlConnection != null && sqlConnection.State != ConnectionState.Broken)
                sqlConnection.Close();
        }

        private async void обновитьToolStripMenuItem_Click(object sender, EventArgs e)
        {

            dataGridView1.Refresh();
            dataGridView2.Refresh();
            dataGridView3.Refresh();
            listBox1.Items.Clear();
            SqlDataReader sqlReader = null;
            SqlCommand command = new SqlCommand("SELECT * FROM [Circles]", sqlConnection);

            this.circlesTableAdapter.Fill(this.figuresDataSet.Circles);

            try
            {
                sqlReader = await command.ExecuteReaderAsync();


                while (await sqlReader.ReadAsync())
                {
                    listBox1.Items.Add(Convert.ToString(sqlReader["Y"]) + "  " + Convert.ToString(sqlReader["X"]) + "  " + Convert.ToString(sqlReader["Degree"]));
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
        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sqlConnection != null && sqlConnection.State != ConnectionState.Broken)
                sqlConnection.Close();
        }



        private async void button3_Click(object sender, EventArgs e)
        {
            if (label7.Visible)
                label7.Visible = false;

            if (!string.IsNullOrEmpty(textBox16.Text) && !string.IsNullOrWhiteSpace(textBox16.Text))
            {
                SqlCommand command = new SqlCommand("DELETE FROM [Polygons] WHERE [IdPol]=@IdPol", sqlConnection);

                command.Parameters.AddWithValue("IdPol", textBox16.Text);



                await command.ExecuteNonQueryAsync();
            }
            else
            {
                label18.Visible = true;
                label18.Text = "НЕ заполнен ID";
            }
        }

        private async void button1_Click_1(object sender, EventArgs e)
        {
            if (label14.Visible)
                label14.Visible = false;

            if (!string.IsNullOrEmpty(textBox6.Text) && !string.IsNullOrWhiteSpace(textBox6.Text) &&
                !string.IsNullOrEmpty(textBox5.Text) && !string.IsNullOrWhiteSpace(textBox5.Text))
            {
                SqlCommand command = new SqlCommand("INSERT INTO [Circles] (Y, X, Degree, Size)VALUES(@Y, @X, @Degree, @Size)", sqlConnection);



                command.Parameters.AddWithValue("Y", textBox6.Text);
                command.Parameters.AddWithValue("X", textBox5.Text);
                command.Parameters.AddWithValue("Degree", textBox4.Text);
                command.Parameters.AddWithValue("Size", textBox3.Text);

                await command.ExecuteNonQueryAsync();
            }
            else
            {
                label14.Visible = true;
                label14.Text = "Не заполнены все поля!";
            }
        }

        private async void button2_Click_1(object sender, EventArgs e)
        {
            {
                if (label7.Visible)
                    label7.Visible = false;

                if (!string.IsNullOrEmpty(textBox14.Text) && !string.IsNullOrWhiteSpace(textBox14.Text))
                {
                    SqlCommand command = new SqlCommand("DELETE FROM [Circles] WHERE [Id]=@Id", sqlConnection);

                    command.Parameters.AddWithValue("Id", textBox14.Text);

                    await command.ExecuteNonQueryAsync();
                }
                else
                {
                    label14.Visible = true;
                    label14.Text = "НЕ заполнен ID";
                }
            }
        }


        private async void button4_Click_1(object sender, EventArgs e)
        {
            if (label18.Visible)
                label18.Visible = false;

            if (!string.IsNullOrEmpty(textBox15.Text) && !string.IsNullOrWhiteSpace(textBox15.Text) &&
                !string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrWhiteSpace(textBox1.Text))
            {
                SqlCommand command = new SqlCommand("INSERT INTO [Polygons] (Count, Y, X, Degree, Size)VALUES(@Count, @Y, @X, @Degree, @Size)", sqlConnection);

                command.Parameters.AddWithValue("Count", textBox15.Text);
                command.Parameters.AddWithValue("Y", textBox1.Text);
                command.Parameters.AddWithValue("X", textBox2.Text);
                command.Parameters.AddWithValue("Degree", textBox7.Text);
                command.Parameters.AddWithValue("Size", textBox8.Text);

                await command.ExecuteNonQueryAsync();
            }
            else
            {
                label18.Visible = true;
                label18.Text = "Нужно заполнить все поля!";
            }
        }

        private async void button3_Click_1(object sender, EventArgs e)
        {
            if (label7.Visible)
                label7.Visible = false;

            if (!string.IsNullOrEmpty(textBox16.Text) && !string.IsNullOrWhiteSpace(textBox16.Text))
            {
                SqlCommand command = new SqlCommand("DELETE FROM [Polygons] WHERE [IdPol]=@IdPol", sqlConnection);

                command.Parameters.AddWithValue("IdPol", textBox16.Text);

                await command.ExecuteNonQueryAsync();
            }
            else
            {
                label18.Visible = true;
                label18.Text = "НЕ заполнен ID";
            }
        }

        private async void button6_Click_1(object sender, EventArgs e)
        {
            if (label17.Visible)
                label17.Visible = false;

            if (!string.IsNullOrEmpty(textBox9.Text) && !string.IsNullOrWhiteSpace(textBox9.Text) &&
                !string.IsNullOrEmpty(textBox10.Text) && !string.IsNullOrWhiteSpace(textBox10.Text))
            {
                SqlCommand command = new SqlCommand("INSERT INTO [Rectangles] (Coef, Y, X, Degree, Size)VALUES(@Coef, @Y, @X, @Degree, @Size)", sqlConnection);



                command.Parameters.AddWithValue("Coef", textBox9.Text);
                command.Parameters.AddWithValue("Y", textBox10.Text);
                command.Parameters.AddWithValue("X", textBox11.Text);
                command.Parameters.AddWithValue("Degree", textBox12.Text);
                command.Parameters.AddWithValue("Size", textBox13.Text);

                await command.ExecuteNonQueryAsync();
            }
            else
            {
                label17.Visible = true;
                label17.Text = "Нужно заполнить все поля!";
            }
        }

        private async void button5_Click_1(object sender, EventArgs e)
        {
            if (label7.Visible)
                label7.Visible = false;

            if (!string.IsNullOrEmpty(textBox14.Text) && !string.IsNullOrWhiteSpace(textBox14.Text))
            {
                SqlCommand command = new SqlCommand("DELETE FROM [Rectangles] WHERE [IdRec]=@IdRec", sqlConnection);

                command.Parameters.AddWithValue("Id", textBox17.Text);



                await command.ExecuteNonQueryAsync();
            }
            else
            {
                label17.Visible = true;
                label17.Text = "НЕ заполнен ID";
            }
        }

        private async void обновитьToolStripMenuItem_Click_2(object sender, EventArgs e)
        {
            dataGridView1.Refresh();
            dataGridView2.Refresh();
            dataGridView3.Refresh();
            listBox1.Items.Clear();
            SqlDataReader sqlReader = null;
            MessageBox.Show("Данные обновлены");
            SqlCommand command = new SqlCommand("SELECT * FROM [Circles]", sqlConnection);
            SqlCommand command1 = new SqlCommand("SELECT * FROM [Polygons]", sqlConnection);
            SqlCommand command50 = new SqlCommand("SELECT * FROM [Rectangles]", sqlConnection);

            this.circlesTableAdapter.Fill(this.figuresDataSet.Circles);
            this.polygonsTableAdapter.Fill(this.figuresDataSet3.Polygons);
            this.rectanglesTableAdapter.Fill(this.figuresDataSet2.Rectangles);

            try
            {
                sqlReader = await command.ExecuteReaderAsync();


                while (await sqlReader.ReadAsync())
                {
                    listBox1.Items.Add(Convert.ToString(sqlReader["Y"]) + "  " + Convert.ToString(sqlReader["X"]) + "  " + Convert.ToString(sqlReader["Degree"]));
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
    }
}
        

