using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PAIN_lab2
{
    public partial class NewPointForm : Form
    {
        private List<Point> points;

        public NewPointForm(List<Point> points)
        {
            InitializeComponent();

            this.points = points;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            double x = Convert.ToDouble(this.textBoxX.Text);
            double y = Convert.ToDouble(this.textBoxY.Text);
            double z = Convert.ToDouble(this.textBoxZ.Text);

            Point newPoint = new Point(x, y, z);
            points.Add(newPoint);

            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
