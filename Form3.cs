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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((textBox1.Text != "") && (textBox2.Text != "") && (textBox3.Text != ""))
            {
                if (textBox2.Text == textBox3.Text)
                {
                    SqlConnection connect = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\student\Documents\Visual Studio 2010\Projects\ferma\ferma\ferma.db.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
                    SqlDataAdapter sda = new SqlDataAdapter("SELECT COUNT(*) FROM users WHERE login = '" + textBox1.Text + "' ", connect);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    if (dt.Rows[0][0].ToString() == "1")
                    {
                        MessageBox.Show("Такий користувач вже зареєстрований!");
                    }
                    else
                    {
                        connect.Open();
                        SqlCommand cmd = connect.CreateCommand();
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "insert into users values ('" + textBox1.Text + "','" + textBox2.Text + "' )";
                        cmd.ExecuteNonQuery();
                        connect.Close();

                        MessageBox.Show("Користувач добавлений!");
                        textBox1.Text = "";
                        textBox2.Text = "";
                        textBox3.Text = "";
                        this.Hide();
                        Form1 form1 = new Form1();
                        form1.Show();
                    }
                }
                else
                {
                    MessageBox.Show("Паролі не співпадають!");
                }

            }
            else
            {
                MessageBox.Show("Заповніть всі поля!");
            }
        }
    }
}
