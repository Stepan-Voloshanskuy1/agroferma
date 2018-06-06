using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ferma
{
    public partial class Form4 : Form
    {
        int id;
        public Form4()
        {
            InitializeComponent();
            display_data();
            if (z == "admin")
            {
                panel1.Visible = true;
            }
            else
            {
                panel1.Visible = false; 
            }
        }
        SqlConnection connect = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\student\Documents\Visual Studio 2010\Projects\ferma\ferma\ferma.db.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");

        public void display_data()
        {
            connect.Open();

            SqlCommand cmd = connect.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM cattle_breeding";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            connect.Close();
        }

        public void diaplay_insert()
        {
            connect.Open();

            SqlCommand cmd = connect.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into cattle_breeding (name, count) values ('" + textBox1.Text + "','" + textBox2.Text + "')";
            cmd.ExecuteNonQuery();
            connect.Close();

            display_data();
            MessageBox.Show("Успішно добавлено!");
            textBox1.Text = "";
            textBox2.Text = "";
        }

        public void delete()
        {
            connect.Open();

            SqlCommand cmd = connect.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "delete from cattle_breeding where id='" + label11.Text + "'";
            cmd.ExecuteNonQuery();
            connect.Close();

            display_data();
            label11.Text = "";
            textBox3.Text = "";
            MessageBox.Show("Запит успішно видалений!");
        }

        public void update()
        {
            connect.Open();

            SqlCommand cmd = connect.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "update cattle_breeding set name = '" + textBox5.Text + "', count = '" + textBox6.Text + "' where id = '" + textBox4.Text+ "'";
            cmd.ExecuteNonQuery();
            connect.Close();

            display_data();
            textBox5.Text = "";
            textBox6.Text = "";
            textBox4.Text = "";
            MessageBox.Show("Запит успішно оновлений!");
        }

        public static String z;

        private void Form4_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form4_Load(object sender, EventArgs e)
        {
            label1.Text = "Ви зайшли як " + z;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            diaplay_insert();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            id = 0;

            id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            textBox4.Text = id.ToString();
            label11.Text = id.ToString();

            string test = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            string test2 = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();

            textBox3.Text = test;
            textBox5.Text = test;
            textBox6.Text = test2;
        }

        

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            delete();
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            update();
        }
    }
}
