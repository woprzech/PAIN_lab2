using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAIN_lab2
{
    public class AppModel
    {
        private List<Point> points = new List<Point>();
        public event EventHandler PointAdded;
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
    }
}
