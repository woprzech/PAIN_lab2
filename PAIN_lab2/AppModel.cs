using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAIN_lab2
{
    public class AppModel
    {

        public static Dictionary<ColorDef, Color> colDef = new Dictionary<ColorDef, Color>
        {
            {ColorDef.Blue, System.Drawing.Color.FromKnownColor(KnownColor.Blue) },
            {ColorDef.Black, System.Drawing.Color.FromKnownColor(KnownColor.Black) },
            {ColorDef.Green, System.Drawing.Color.FromKnownColor(KnownColor.Green) },
            {ColorDef.Red, System.Drawing.Color.FromKnownColor(KnownColor.Red) },
            {ColorDef.Yellow, System.Drawing.Color.FromKnownColor(KnownColor.Yellow) }
        };
        public enum FILTER
        {
            LESS, GREATER, ALL
        }
        private List<Point> points = new List<Point>();
        public event EventHandler PointAdded;
        public event EventHandler PointRemoved;
        public event EventHandler PointEdited;
        public static int COUNTER = 0;

        public IReadOnlyCollection<Point> Points
        {
            get { return points; }
        }

        public void AddPoint(Point point)
        {
            points.Add(point);
            if (PointAdded != null)
            {
                PointAdded.Invoke(point, null);
            }
        }

        public void EditPoint(Point point)
        {
            if (PointEdited != null)
            {
                PointEdited.Invoke(point, null);
            }
        }

        public void RemovePoint(Point point)
        {
            int counter = 0;
            foreach (Point p in points)
            {
                if (p.Equals(point))
                {
                    PointRemoved.Invoke(point, null);
                    points.RemoveAt(counter);
                    return;
                }
                counter++;
            }
        }
    }
}
