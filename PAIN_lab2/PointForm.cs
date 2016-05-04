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
    public partial class PointForm : Form
    {
        private Point point;

        public PointForm(Point point)
        {
            InitializeComponent();

            this.point = point;
            this.textBoxLabel.Text = point.getLabel();
            this.textBoxX.Text = point.getX().ToString();
            this.textBoxY.Text = point.getY().ToString();
            colorControl.ColorDef = point.getColor();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void ColorChanged(object sender, EventArgs args)
        {
            colorLabel.Text = colorControl.ColorDef.ToString();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            double x = Convert.ToDouble(this.textBoxX.Text);
            double y = Convert.ToDouble(this.textBoxY.Text);

            point.changeX(x);
            point.changeY(y);
            point.changeLabel(textBoxLabel.Text);
            point.changeColor(colorControl.ColorDef);
            DialogResult = DialogResult.OK;
            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void PointForm_Load(object sender, EventArgs e)
        {

        }

        private void textTB_Validate(object sender, CancelEventArgs args)
        {
            string content = ((TextBox)sender).Text;
            if (content.Length == 0)
            {
                args.Cancel = true;
                errorProvider1.SetError((TextBox)sender, "Field must not be empty!");
            }
        }

        private void numberTB_Validate(object sender, CancelEventArgs args)
        {
            int parsedContent;
 
            if (!int.TryParse(((TextBox)sender).Text, out parsedContent))
            {
                args.Cancel = true;
                errorProvider1.SetError((TextBox)sender, "It's not a number!");
            }
        }

        private void textBoxX_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError((TextBox)sender, "");
        }

    }
}
