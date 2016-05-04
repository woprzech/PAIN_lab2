using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.Design;

namespace PAIN_lab2
{
    internal class ColorEditor : UITypeEditor
    {
        private Dictionary<ColorDef, Color> colDefToColor = AppModel.colDef;


        public override void PaintValue(PaintValueEventArgs e)
        {
            ColorDef colorDef = (ColorDef)e.Value;
            var color = colDefToColor[colorDef];
            SolidBrush brush = new SolidBrush(color);
            Pen pen = new Pen(color, 0);
            Rectangle rect = new Rectangle(e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height);
            e.Graphics.DrawRectangle(pen, rect);
            e.Graphics.FillRectangle(brush, rect);
        }

        public override bool GetPaintValueSupported(ITypeDescriptorContext context)
        {
            return true;
        }

        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.DropDown;
        }

        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            var editorService = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));
            if (editorService != null)
            {
                var colorControl = new ColorControl();
                colorControl.ColorDef = (ColorDef)value;
                editorService.DropDownControl(colorControl);
                return colorControl.ColorDef;
            }
            return value;
        }
    }
}