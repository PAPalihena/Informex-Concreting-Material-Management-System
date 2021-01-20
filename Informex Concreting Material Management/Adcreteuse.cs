﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Informex_Concreting_Material_Management
{
    public partial class Adcreteuse : Form
    {
        public string strConnString = "Data Source=DESKTOP-DLPKCGD;Initial Catalog=InformexConcreting;Integrated Security=True";

        public Adcreteuse()
        {
            InitializeComponent();
        }

        private void Adcreteuse_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(strConnString);
            con.Open();

            if (con.State == System.Data.ConnectionState.Open)
            {
                try
                {
                    SqlCommand cmd1 = new SqlCommand("getAdcreteSuppliers", con);
                    cmd1.CommandType = CommandType.StoredProcedure;
                    DataTable dt = new DataTable();
                    dt.Load(cmd1.ExecuteReader());
                    dataGridView1.DataSource = dt;

                    SqlDataAdapter sql1 = new SqlDataAdapter("SELECT Project_id,name FROM Project WHERE status ='incomplete'", con);
                    DataTable dtb2 = new DataTable();
                    sql1.Fill(dtb2);

                    dataGridView2.DataSource = dtb2;

                    SqlDataAdapter sql2 = new SqlDataAdapter("SELECT concrete_id, project_id,grade FROM Concrete WHERE date= '" + this.dateTimePicker1.Text + "'", con);
                    DataTable dtb3 = new DataTable();
                    sql2.Fill(dtb3);

                    dataGridView3.DataSource = dtb3;

                    String selectquery = "SELECT adcrete_in,adcrete_out FROM material_usage WHERE date = '" + this.dateTimePicker1.Text + "'";
                    SqlCommand cmd = new SqlCommand(selectquery, con);
                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();
                    chart1.Series["Stock in"].Points.AddXY("", dr.GetValue(0));
                    chart1.Series["Stock out"].Points.AddXY("", dr.GetValue(1));
                }
                catch
                {

                    
                }

            }
        }

        private void btncementin_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(strConnString);
            con.Open();

            if (con.State == System.Data.ConnectionState.Open)
            {
                try
                {
                    SqlDataAdapter cmd = new SqlDataAdapter("INSERT INTO adcrete_stockin (date,quantity,Supplier_id) VALUES ('" + this.dateTimePicker1.Text + "','" + txtcquan.Text + "','" + txtcementsup.Text + "')", con);
                    cmd.SelectCommand.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Data inserted succesfully!");
                }
                catch
                {

                    MessageBox.Show("Unsuccessful !");
                }

            }
            else
            {
                MessageBox.Show("Connection cannot be established!");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new Metaluse().Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new CSanduse().Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new USanduse().Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            new Cementuse().Show();
            this.Hide();
        }

        private void Close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            new Hypercreteuse().Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(strConnString);
            con.Open();

            if (con.State == System.Data.ConnectionState.Open)
            {
                try
                {
                    SqlDataAdapter cmd2 = new SqlDataAdapter("INSERT INTO adcrete_out (date,quantity,concrete_id) VALUES ('" + this.dateTimePicker3.Text + "','" + textBox1.Text + "','" + textBox2.Text + "')", con);
                    cmd2.SelectCommand.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Data inserted succesfully!");
                }
                catch
                {

                    MessageBox.Show("Unsuccessful !");
                }

            }
            else
            {
                MessageBox.Show("Connection cannot be established!");
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            new Report().Show();
            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
        }
    }
}
