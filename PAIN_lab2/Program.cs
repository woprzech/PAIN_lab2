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
            fillPoints();
            Application.Run(new MDIParent1(points));
        }

        static private void fillPoints()
        {
            points.Add(new Point(1, 2, 3));
            points.Add(new Point(3, 2, 1));
            points.Add(new Point(3, 3, 3));
        }
    }
}
