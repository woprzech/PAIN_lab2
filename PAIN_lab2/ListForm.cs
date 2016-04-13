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

            ////listView.Columns.Add("#", 50);
            ////listView.Columns.Add("x", 50);
            ////listView.Columns.Add("y", 50);
            ////listView.Columns.Add("z", 50);

            int i = 0;
            listView.BeginUpdate();
            foreach (Point p in points)
            {
                listView.Items.Add(prepareListItemFromPoint(p));
            }
            listView.EndUpdate();
        }


        private ListViewItem prepareListItemFromPoint(Point p)
        {
            ListViewItem item = new ListViewItem("#" + AppModel.COUNTER++);
            item.SubItems.Add(p.getX().ToString());
            item.SubItems.Add(p.getY().ToString());
            item.SubItems.Add("color");
            item.Tag = p;
            return item;
        }

        protected override void PointAdded(object sender, EventArgs args)
        {
            Point p = (Point)sender;
            listView.Items.Add(prepareListItemFromPoint(p));
            //base.PointAdded
        }

        protected override void RemovePoint(object sender, EventArgs args)
        {
            Point p = (Point)sender;
            foreach (ListViewItem item in listView.Items)
            {
                if (item.Tag.Equals(p))
                {
                    listView.Items.Remove(item);
                }
            }
        }

        private void editButton_Click(object sender, EventArgs e)
        {

        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listView.SelectedItems)
            {
                AppModel.RemovePoint((Point)item.Tag);
            }
        }

    }
}
