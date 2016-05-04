using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PAIN_lab2
{
    static class Program
    {

        static List<Point> points = new List<Point>();
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            AppModel model = new AppModel();
            Point point = new Point("Pierwszy", 2, 3);
            point.changeColor(ColorDef.Black);
            model.AddPoint(point);
            Application.Run(new MDIParent1(model));
        }

        static private void fillPoints()
        {
        }
    }
}
