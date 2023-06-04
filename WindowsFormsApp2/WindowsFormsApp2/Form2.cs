using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp2
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=SEMIHBAŞER\\SQLEXPRESS;Initial Catalog=YemekTarifleri;Integrated Security=True");

        int Move;
        int Mouse_X;
        int Mouse_Y;


        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("INSERT INTO tarif(TarifAdi,Malzemeler,HazirlanmaSuresi,KisiSayisi,TarifHazirlanis,TarifResim) VALUES (@TarifAdi,@Malzemeler,@HazirlanmaSuresi,@KisiSayisi,@TarifHazirlanis,@TarifResim)", baglanti);
            komut.Parameters.AddWithValue("@TarifAdi", textBox1.Text);
            komut.Parameters.AddWithValue("@Malzemeler", textBox2.Text);
            komut.Parameters.AddWithValue("@HazirlanmaSuresi", Convert.ToInt32(textBox6.Text));
            komut.Parameters.AddWithValue("@KisiSayisi", comboBox1.Text);
            komut.Parameters.AddWithValue("@TarifHazirlanis", textBox3.Text+"\n\n"+textBox4.Text+"\n\n"+textBox5.Text);
            komut.Parameters.AddWithValue("@TarifResim", textBox8.Text);
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();

            MessageBox.Show("İşlem Başarılı!");
            this.Hide();
            Form3 frm3 = new Form3();
            frm3.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            pictureBox1.ImageLocation = openFileDialog1.FileName;
            textBox8.Text = openFileDialog1.FileName;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 frm3 = new Form3();
            frm3.Show();
        }

        private void panel3_MouseUp(object sender, MouseEventArgs e)
        {
            Move = 0;
        }

        private void panel3_MouseMove(object sender, MouseEventArgs e)
        {
            if (Move == 1)
            {
                this.SetDesktopLocation(MousePosition.X - Mouse_X, MousePosition.Y - Mouse_Y);
            }
        }

        private void panel3_MouseDown(object sender, MouseEventArgs e)
        {
            Move = 1;
            Mouse_X = e.X;
            Mouse_Y = e.Y;
        }
    }
}
