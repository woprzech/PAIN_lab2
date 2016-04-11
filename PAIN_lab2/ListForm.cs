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
    public partial class ListForm : BaseForm
    {
        private ListView listView;

        public ListForm(List<Point> points)
        {
            InitializeComponent();

            createListView(points);
        }

        public ListForm(AppModel appModel)
            : base(appModel)
        {
            InitializeComponent();


            createListView(appModel.Points);
        }

        private void createListView(IReadOnlyCollection<Point> points)
        {
            listView = new ListView();
            listView.View = View.Details;
            listView.Size = new System.Drawing.Size(200, 200);

            listView.Columns.Add("#", 50);
            listView.Columns.Add("x", 50);
            listView.Columns.Add("y", 50);
            listView.Columns.Add("z", 50);

            int i = 0;
            foreach (Point p in points)
            {
                ListViewItem item = new ListViewItem(new String[] { i++ + "", p.getX() + "", p.getY() + "", p.getZ() + "" });
                listView.Items.Add(item);
            }

            listView.Show();
            this.Controls.Add(listView);
        }

        protected override void PointAdded(object sender, EventArgs args)
        {
            Point p = (Point)sender;
            ListViewItem item = new ListViewItem(new String[] { AppModel.Points.Count + "", p.getX() + "", p.getY() + "", p.getZ() + "" });
            listView.Items.Add(item);
            //base.PointAdded
        }
    }
}
