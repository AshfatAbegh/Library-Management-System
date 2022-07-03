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

namespace Library_Management_System
{
    public partial class Form1 : Form
    {
        string std_id;
        SqlConnection sql = new SqlConnection(@"Data Source=PC-TL2020;Initial Catalog=library;Integrated Security=True");
        public Form1()
        {
            InitializeComponent();
            show_book();
            student();
            show_lend();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            sql.Close();
            sql.Open();
            SqlCommand cmd = new SqlCommand("insert into book_list(book_name,writer_name,quantity,dept)values('"+richTextBox1.Text+"','"+ richTextBox2.Text + "','"+ richTextBox3.Text + "','"+comboBox1.Text+"')", sql);
            int a = cmd.ExecuteNonQuery();
            if (a > 0)
            {
                MessageBox.Show("Upload Successful");
            }
            sql.Close();
        }

        void show_book()
        {
            sql.Close();
            sql.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select * from book_list",sql);
            dataGridView1.Rows.Clear();
            DataTable dt = new DataTable();
            sda.Fill(dt);
            foreach (DataRow item in dt.Rows)
            {
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = item[0].ToString();
                dataGridView1.Rows[n].Cells[1].Value = item[1].ToString();
                dataGridView1.Rows[n].Cells[2].Value = item[2].ToString();
                dataGridView1.Rows[n].Cells[3].Value = item[3].ToString();
                dataGridView1.Rows[n].Cells[4].Value = item[4].ToString();
            }

            sql.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            sql.Close();
            sql.Open();
            SqlCommand cmd = new SqlCommand("insert into registration(id,name,date,dept)values('"+richTextBox6.Text+"','"+ richTextBox5.Text + "','"+dateTimePicker1.Text+"','"+comboBox2.Text+"');", sql);
            int a = cmd.ExecuteNonQuery();
            if (a > 0)
            {
                MessageBox.Show("Registration Successful");
            }
            sql.Close();
        }
        void student()
        {
            sql.Close();
            sql.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select * from registration", sql);
            dataGridView2.Rows.Clear();
            DataTable dt = new DataTable();
            sda.Fill(dt);
            foreach (DataRow item in dt.Rows)
            {
                int n = dataGridView2.Rows.Add();
                dataGridView2.Rows[n].Cells[0].Value = item[0].ToString();
                dataGridView2.Rows[n].Cells[1].Value = item[1].ToString();
                dataGridView2.Rows[n].Cells[2].Value = item[3].ToString();
            }
            sql.Close();
        }

        private void dataGridView2_Click(object sender, EventArgs e)
        {
            std_id = dataGridView2.SelectedRows[0].Cells[0].Value.ToString();
            string name = dataGridView2.SelectedRows[0].Cells[1].Value.ToString();
            string dept = dataGridView2.SelectedRows[0].Cells[2].Value.ToString();

            richTextBox7.Text = std_id;
            richTextBox4.Text = name;
            comboBox3.Text = dept;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            sql.Close();
            sql.Open();
            SqlCommand cmd = new SqlCommand("update registration set id='" + richTextBox7.Text + "',name='" + richTextBox4.Text + "',dept='" + comboBox3.Text + "'",sql);
            cmd.ExecuteNonQuery();
            sql.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            sql.Close();
            sql.Open();
            SqlCommand cmd = new SqlCommand("insert into lend(book_id,student_id,book_name,writer_name,date)values('"+ richTextBox10.Text+ "','"+ richTextBox8.Text+ "','"+ richTextBox9.Text+ "','"+ richTextBox11.Text+ "','"+dateTimePicker2.Text+"')",sql);
            int a = cmd.ExecuteNonQuery();
            if (a > 0)
            {
                MessageBox.Show("Lended Successfully");
            }
            sql.Close();
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            string book_id = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            string book_name = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            string writer = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            richTextBox10.Text = book_id;
            richTextBox8.Text = book_name;
            richTextBox9.Text = writer;
        }

        void show_lend()
        {
            sql.Close();
            sql.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select * from lend", sql);
            dataGridView3.Rows.Clear();
            DataTable dt = new DataTable();
            sda.Fill(dt);
            foreach (DataRow item in dt.Rows)
            {
                int n = dataGridView3.Rows.Add();
                dataGridView3.Rows[n].Cells[0].Value = item[0].ToString();
                dataGridView3.Rows[n].Cells[1].Value = item[1].ToString();
                dataGridView3.Rows[n].Cells[2].Value = item[2].ToString();
                dataGridView3.Rows[n].Cells[3].Value = item[3].ToString();
                dataGridView3.Rows[n].Cells[4].Value = item[4].ToString();
            }
            sql.Close();
        }

        private void dataGridView3_Click(object sender, EventArgs e)
        {
           string std_id = dataGridView3.SelectedRows[0].Cells[3].Value.ToString();
           string book_id = dataGridView3.SelectedRows[0].Cells[0].Value.ToString();
            label18.Text = book_id;
            label19.Text = std_id;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            sql.Close();
            sql.Open();
            SqlCommand cmd = new SqlCommand("delete from lend where std_id='"+label19.Text+"' and book_id='"+label18.Text+"'", sql);
            cmd.ExecuteNonQuery();
            sql.Close();
            show_lend();
            
        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }
    }
}
