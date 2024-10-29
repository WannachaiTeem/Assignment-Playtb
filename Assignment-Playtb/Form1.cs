using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Assignment_Playtb
{
   
    public partial class Form1 : Form
    {
        APD66_64011212155Entities3 context = new APD66_64011212155Entities3();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string html = "<html><head>";
            html = html + "<meta content='IE=Edge' http-equiv='X-UA-Compatible'/>";
            html = html + "<iframe id='video' src= 'https://www.youtube.com/embed/{0}?autoplay=1' width='600' height='300' frameborder='0' allowfullscreen  /iframe >";
            html = html + "</head> </html>";
            this.webBrowser1.DocumentText = string.Format(html, textBox1.Text.Split('=')[1]);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2(textBox2.Text);
            form.Visible = true;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            YTRoom room = new YTRoom();
            room.room_id = textBox2.Text;
            room.url = textBox1.Text;
            context.YTRooms.Add(room);
            int change = context.SaveChanges();
            MessageBox.Show("Change " + change + " records");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int id = int.Parse(textBox2.Text);
            var result = context.YTRooms
                .Where(p => p.room_id == textBox2.Text)
                .First();
            result.url = textBox1.Text;
            int change = context.SaveChanges();
            if (change > 0)
            {
                MessageBox.Show("Update Ok");
            }
        }
    }
}
