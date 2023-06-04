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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection ("Data Source=SEMIHBAŞER\\SQLEXPRESS;Initial Catalog=login;Integrated Security=True");

        int Move;
        int Mouse_X;
        int Mouse_Y;

        private void button1_Click(object sender, EventArgs e)
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from dbo.login where username=@username and pass=@pass",baglanti);
            da.SelectCommand.Parameters.Add("@username", SqlDbType.NVarChar, 11);
            da.SelectCommand.Parameters.Add("@pass", SqlDbType.NVarChar, 10);
            da.SelectCommand.Parameters["@username"].Value = textBox1.Text;
            da.SelectCommand.Parameters["@pass"].Value = textBox3.Text;

            DataTable dt = new DataTable();
            da.Fill(dt);
            if(dt.Rows.Count != 0)
            {
                MessageBox.Show("Giriş Başarılı!");
                Form3 frm3 = new Form3();
                frm3.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı Giriş!");
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand(@"insert into login(username,phone,email,pass) values (@username,@phone,@email,@pass)", baglanti);
            cmd.Parameters.AddWithValue("username",textBox4.Text);
            cmd.Parameters.AddWithValue("phone", textBox5.Text);
            cmd.Parameters.AddWithValue("email", textBox6.Text);
            cmd.Parameters.AddWithValue("pass", textBox2.Text);

            baglanti.Open();
            cmd.ExecuteNonQuery();
            baglanti.Close();

            MessageBox.Show("Kayıt Başarı İle Tamamlandı.");
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox2.Text = "";

        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox3.Text = "";
        }

        private void panel3_MouseUp(object sender, MouseEventArgs e)
        {
            Move = 0;
        }

        private void panel3_MouseDown(object sender, MouseEventArgs e)
        {
            Move = 1;
            Mouse_X = e.X;
            Mouse_Y = e.Y;
        }

        private void panel3_MouseMove(object sender, MouseEventArgs e)
        {
            if (Move == 1)
            {
                this.SetDesktopLocation(MousePosition.X - Mouse_X, MousePosition.Y - Mouse_Y);
            }
        }
    }
}
