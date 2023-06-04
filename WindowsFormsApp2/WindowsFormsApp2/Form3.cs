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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        int Move;
        int Mouse_X;
        int Mouse_Y;

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 frm2 = new Form2();
            frm2.Show();
            this.Hide();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=SEMIHBAŞER\\SQLEXPRESS;Initial Catalog=YemekTarifleri;Integrated Security=True");

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 frm2 = new Form2();
            SqlCommand cmd = new SqlCommand("insert into dbo.tarif(TarifAdi,Malzemeler,HazirlanmaSuresi,KisiSayisi) values('" + (frm2.textBox1.Text) + "','" + (frm2.textBox2.Text) + "','" + (frm2.textBox6.Text) + "','" + (frm2.comboBox1.Text) + "','", baglanti);
            cmd.CommandText = "SELECT * FROM tarif";
            cmd.Connection = baglanti;
            SqlDataAdapter adap = new SqlDataAdapter(cmd);
            DataTable tablo = new DataTable();
            adap.Fill(tablo);

            dataGridView1.DataSource = tablo;

            
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            
            /*** BUTON EKLEME ***/
            DataGridViewButtonColumn dgvBtn = new DataGridViewButtonColumn();
            //Kolon Başlığı
            dgvBtn.HeaderText = "Detay";
            // Butonun Text
            dgvBtn.Text = "Aç";
            // Butonda Text Kullanılmasını aktifleştirme
            dgvBtn.UseColumnTextForButtonValue = true;
            // Buton çerçeve rengi
            dgvBtn.DefaultCellStyle.BackColor = Color.Blue;
            // Buton seçiliykenki çerçeve rengi
            dgvBtn.DefaultCellStyle.SelectionBackColor = Color.Red;
            // Butonun genişiliği
            dgvBtn.Width = 70;
            // DataGridView e ekleme
            dataGridView1.Columns.Add(dgvBtn);



        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            if (e.ColumnIndex == 0)
            {
                Form4 frm4 = new Form4();
                Form2 frm2 = new Form2();
                frm4.a = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                frm4.b = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                frm4.c = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                frm4.d = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                frm4.k = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                frm4.pictureBox1.ImageLocation = dataGridView1.CurrentRow.Cells[6].Value.ToString();

                frm2.pictureBox1.ImageLocation = dataGridView1.Rows[0].Cells[6].Value.ToString();



                this.Hide();
                frm4.Show();


            }
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
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
