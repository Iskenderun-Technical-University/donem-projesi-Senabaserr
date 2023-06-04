using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        public string a, b, c, d, k,r;

        private void pictureBox4_Click(object sender, EventArgs e)
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

        int Move;
        int Mouse_X;
        int Mouse_Y;

        public void ResimDegis(Image resim)
        {
            pictureBox1.Image = resim;
        }
        private void Form4_Load(object sender, EventArgs e)
        {
            Form2 frm2 = new Form2();
            lbl_TarifAdi.Text = a.ToUpper();
            textBox1.Text = b;
            label4.Text = c;
            label1.Text = d;
            textBox2.Text=k;
            
            


        }
    }
}
