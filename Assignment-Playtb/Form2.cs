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
    public partial class Form2 : Form
    {
        APD66_64011212155Entities3 context = new APD66_64011212155Entities3();
        string id;
        string url;
        public Form2(string id)
        {
            this.id = id;
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            label1.Text = id;
            var result = context.YTRooms
                .Where(d => d.room_id == id).First();
            label2.Text = result.url;
            this.url = result.url;
            string link = url.Replace("https://www.youtube.com/watch?v=","");

            string html = "<html><head>";
            html = html + "<meta content='IE=Edge' http-equiv='X-UA-Compatible'/>";
            html = html + "<iframe id='video' src= 'https://www.youtube.com/embed/{0}?autoplay=1' width='600' height='300' frameborder='0' allowfullscreen  /iframe >";
            html = html + "</head> </html>";
            this.webBrowser1.DocumentText = string.Format(html, link);
            timer1.Start();
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            context = new APD66_64011212155Entities3 ();
            var result = context.YTRooms
                .Where(d => d.room_id == id).First();
            if (url != result.url)
            {
                this.url = result.url;
                string link = url.Replace("https://www.youtube.com/watch?v=", "");

                string html = "<html><head>";
                html = html + "<meta content='IE=Edge' http-equiv='X-UA-Compatible'/>";
                html = html + "<iframe id='video' src= 'https://www.youtube.com/embed/{0}?autoplay=1' width='600' height='300' frameborder='0' allowfullscreen  /iframe >";
                html = html + "</head> </html>";
                this.webBrowser1.DocumentText = string.Format(html, link);
            }

        }
    }
}
