using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Design;

namespace PAIN_lab2
{
    public partial class ColorControl : UserControl
    {
        public event EventHandler ColorChanged;
        private ColorDef colorDef;

        private Dictionary<ColorDef, Color> colDefToColor = AppModel.colDef;

        public ColorControl()
        {
            InitializeComponent();
        }

        private Color Color
        {
            get
            {
                return colDefToColor[colorDef];
            }
        }

        [Editor(typeof(ColorEditor), typeof(UITypeEditor))]
        [Category("Point")]
        [Browsable(true)]
        public ColorDef ColorDef
        {
            get { return colorDef; }
            set
            {
                if (colorDef != value)
                {
                    colorDef = value;
                    Invalidate();
                    if (ColorChanged != null)
                    {
                        ColorChanged.Invoke(this, null);
                    }
                }
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            SolidBrush brush = new SolidBrush(Color);
            Pen pen = new Pen(Color, 0);
            base.OnPaint(e);

            int contWidth = Size.Width;
            int contHeight = Size.Height;
            Rectangle rect = new Rectangle(0, 0, contWidth, contHeight);
            e.Graphics.DrawRectangle(pen, rect);
            e.Graphics.FillRectangle(brush, rect);
        }

        private void Control_Click(object sender, EventArgs args)
        {
            ColorDef = (ColorDef)(((int)ColorDef + 1) % colDefToColor.Count);
        }

        private void ColorControl_Load(object sender, EventArgs e)
        {

        }
    }
}
