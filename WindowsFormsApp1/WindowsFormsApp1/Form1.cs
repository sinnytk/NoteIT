using NoteIT;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Window : Form
    {
        private bool mouseDown;
        private Point lastLocation;
        public Window()
        {
            
            InitializeComponent();
        }

        private void Window_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }
        private void Window_MouseMove(object sender, MouseEventArgs e)
        {
            if(mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X -lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);
                this.Update();
            }
        }
        private void Window_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void close_button_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void Window_Load(object sender, EventArgs e)
        {
            Subform form2 = new Subform();
        }
    }
}
