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
        private string currentFilter = AppModel.FILTER.ALL.ToString();
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

            listView.BeginUpdate();
            foreach (Point p in points)
            {
                listView.Items.Add(prepareListItemFromPoint(p));
            }
            listView.EndUpdate();
        }


        private ListViewItem prepareListItemFromPoint(Point p)
        {
            ListViewItem item = new ListViewItem(p.getLabel());
            item.SubItems.Add(p.getX().ToString());
            item.SubItems.Add(p.getY().ToString());
            item.SubItems.Add(p.getColor().ToString());
            item.Tag = p;
            return item;
        }

        protected override void PointAdded(object sender, EventArgs args)
        {
            Point p = (Point)sender;
            if (isPointShouldBeVisible(p))
                listView.Items.Add(prepareListItemFromPoint(p));
            //base.PointAdded
        }

        private bool isPointShouldBeVisible(Point p)
        {
            bool isXGreater = p.getX() > 0;
            return (isXGreater && !AppModel.FILTER.LESS.ToString().Equals(filterSelect.GetItemText(filterSelect.SelectedItem))) ||
                (!isXGreater && !AppModel.FILTER.GREATER.ToString().Equals(filterSelect.GetItemText(filterSelect.SelectedItem)));
        }

        protected override void PointRemoved(object sender, EventArgs args)
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

        protected override void PointEdited(object sender, EventArgs args)
        {
            Point p = (Point)sender;
            bool pointIsFound = false;
            foreach (ListViewItem item in listView.Items)
            {
                if (item.Tag.Equals(p))
                {
                    if (!isPointShouldBeVisible(p))
                    {
                        listView.Items.Remove(item);
                    }
                    else
                    {
                        pointIsFound = true;
                        item.SubItems.Clear();
                        item.SubItems.Add(p.getX().ToString());
                        item.SubItems.Add(p.getY().ToString());
                        item.SubItems.Add(p.getColor().ToString());
                        item.Text = p.getLabel();
                        item.Tag = p;
                    }
                }
            }
            if (!pointIsFound && isPointShouldBeVisible(p))
            {
                listView.Items.Add(prepareListItemFromPoint(p));
            }
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listView.SelectedItems)
            {
                Point point = (Point)item.Tag;
                PointForm pointForm = new PointForm(point);
                if (pointForm.ShowDialog() == DialogResult.OK)
                {
                    AppModel.EditPoint(point);
                }
            }
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listView.SelectedItems)
            {
                AppModel.RemovePoint((Point)item.Tag);
            }
        }

        private void ListForm_Load(object sender, EventArgs e)
        {

        }

        private void filterSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            string filterName = comboBox.GetItemText(comboBox.SelectedItem);
            if (AppModel.FILTER.GREATER.ToString().Equals(filterName))
            {
                listView.Items.Clear();
                foreach (Point p in AppModel.Points)
                {
                    if (p.getX() > 0)
                        listView.Items.Add(prepareListItemFromPoint(p));
                }
            }
            else if (AppModel.FILTER.LESS.ToString().Equals(filterName))
            {
                listView.Items.Clear();
                listView.BeginUpdate();
                foreach (Point p in AppModel.Points)
                {
                    if (p.getX() < 0)
                        listView.Items.Add(prepareListItemFromPoint(p));
                }
                listView.EndUpdate();
            }
            else
            {
                listView.Items.Clear();
                listView.BeginUpdate();
                foreach (Point p in AppModel.Points)
                {
                    listView.Items.Add(prepareListItemFromPoint(p));
                }
                listView.EndUpdate();
            }
        }


    }
}
