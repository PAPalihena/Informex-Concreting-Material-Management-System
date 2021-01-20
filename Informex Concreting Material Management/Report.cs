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

namespace Informex_Concreting_Material_Management
{
    public partial class Report : Form
    {
        public string strConnString = "Data Source=DESKTOP-DLPKCGD;Initial Catalog=InformexConcreting;Integrated Security=True";

        public Report()
        {
            InitializeComponent();
        }

        private void Close_Click(object sender, EventArgs e)
        {
            Application.Exit();
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

        private void button3_Click(object sender, EventArgs e)
        {
            new Metaluse().Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            new Adcreteuse().Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            new Hypercreteuse().Show();
            this.Hide();
        }

        private void Report_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(strConnString);
            con.Open();
            if (con.State == System.Data.ConnectionState.Open)
            {

                String selectquery = "SELECT cement_in,cement_out,csand_in,csand_out,usand_in,usand_out,metal_in,metal_out,adcrete_in,adcrete_out,hypercrete_in,hypercrete_out FROM material_usage WHERE date = '" + this.dateTimePicker3.Text + "'";
                SqlCommand cmd = new SqlCommand(selectquery, con);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    chart1.Series["Stock in"].Points.AddXY("Cement", dr.GetValue(0));
                    txtcementin.Text = dr.GetValue(0).ToString();                                                    
                    chart1.Series["Stock out"].Points.AddXY("", dr.GetValue(1));
                    txtcementout.Text = dr.GetValue(1).ToString();

                    chart1.Series["Stock in"].Points.AddXY("Crushed sand", dr.GetValue(2));
                    txtcsandin.Text = dr.GetValue(2).ToString();
                    chart1.Series["Stock out"].Points.AddXY("", dr.GetValue(3));
                    txtcsandout.Text = dr.GetValue(3).ToString();

                    chart1.Series["Stock in"].Points.AddXY("Uncrushed sand", dr.GetValue(4));
                    txtusandin.Text = dr.GetValue(4).ToString();
                    chart1.Series["Stock out"].Points.AddXY("", dr.GetValue(5));
                    txtusandout.Text = dr.GetValue(5).ToString();

                    chart1.Series["Stock in"].Points.AddXY("Metal", dr.GetValue(6));
                    txtmetalin.Text = dr.GetValue(6).ToString();
                    chart1.Series["Stock out"].Points.AddXY("", dr.GetValue(7));
                    txtmetalout.Text = dr.GetValue(7).ToString();


                    chart1.Series["Stock in"].Points.AddXY("Adcrete", dr.GetValue(8));
                    txtadcretein.Text = dr.GetValue(8).ToString();
                    chart1.Series["Stock out"].Points.AddXY("", dr.GetValue(9));
                    txtadcreteout.Text = dr.GetValue(9).ToString();


                    chart1.Series["Stock in"].Points.AddXY("Hypercrete", dr.GetValue(10));
                    txthypercretein.Text = dr.GetValue(10).ToString();
                    chart1.Series["Stock out"].Points.AddXY("", dr.GetValue(11));
                    txthypercreteout.Text = dr.GetValue(11).ToString();
                }
                                
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            new Cementuse().Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(strConnString);
            con.Open();
            SqlCommand c1;
            if (con.State == System.Data.ConnectionState.Open)
            {

                String q1 = "getSandAvailable";
                c1 = new SqlCommand(q1, con);
                c1.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader dr1 = c1.ExecuteReader();
                dr1.Read();
                txtusand.Text = dr1["availableUsand"].ToString();
                txtcement.Text = dr1["availableCement"].ToString();
                txtadcrete.Text = dr1["availableAdcrete"].ToString();
                txthypercrete.Text = dr1["availableHypercrete"].ToString();
                txtcsand.Text = dr1["availableCSand"].ToString();
                txtmetal.Text = dr1["availableMetal"].ToString();
            }
        }

        private void txtusandin_Click(object sender, EventArgs e)
        {

        }
    }
}
