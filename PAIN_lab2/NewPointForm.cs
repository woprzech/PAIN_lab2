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
        private Point point;

        public NewPointForm(Point point)
        {
            InitializeComponent();

            this.point = point;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            double x = Convert.ToDouble(this.textBoxX.Text);
            double y = Convert.ToDouble(this.textBoxY.Text);

            point.changeX(x);
            point.changeY(y);
            DialogResult = DialogResult.OK;
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
