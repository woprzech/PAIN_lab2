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
    public partial class ListForm : Form
    {
        private ListView listView;
        private List<Point> points;

        public ListForm(List<Point> points)
        {
            InitializeComponent();

            this.points = points;

            createListView();
        }

        private void createListView() {
            listView = new ListView();
            listView.View = View.Details;
            listView.Size = new System.Drawing.Size(200, 200);

            listView.Columns.Add("#", 50);
            listView.Columns.Add("x", 50);
            listView.Columns.Add("y", 50);
            listView.Columns.Add("z", 50);

            fillListView();

            listView.Show();
            this.Controls.Add(listView);
        }

        private void fillListView() {
            int i = 0;
            foreach (Point p in points) {
                ListViewItem item = new ListViewItem(new String[] { i++ + "", p.getX() + "", p.getY() + "", p.getZ() + ""});
                listView.Items.Add(item);
            }
        }
    }
}
