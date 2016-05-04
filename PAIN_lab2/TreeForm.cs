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
    public partial class TreeForm : BaseForm
    {
        private TreeNode rootNode;

        public TreeForm(AppModel model)
            : base(model)
        {
            InitializeComponent();

            createTreeView(model.Points);
        }

        private void createTreeView(IReadOnlyCollection<Point> points)
        {
            //treeView.View = View.Details;
            rootNode = new TreeNode("points");
            foreach (Point p in points)
            {
                TreeNode pointNode = preparePointElement(p);
                rootNode.Nodes.Add(pointNode);
            }
            treeView.Nodes.Add(rootNode);

        }

        private TreeNode preparePointElement(Point p)
        {
            TreeNode xValue = new TreeNode(p.getX() + "");
            TreeNode xName = new TreeNode("x");
            xName.Name = "x";
            xName.Nodes.Add(xValue);
            TreeNode yValue = new TreeNode(p.getY() + "");
            TreeNode yName = new TreeNode("y");
            yName.Name = "y";
            yName.Nodes.Add(yValue);
            TreeNode colorValue = new TreeNode(p.getColor().ToString());
            TreeNode colorName = new TreeNode("color");
            colorName.Name = "color";
            colorName.Nodes.Add(colorValue);
            TreeNode pointNode = new TreeNode(p.getLabel());
            pointNode.Nodes.Add(xName);
            pointNode.Nodes.Add(yName);
            pointNode.Nodes.Add(colorName);
            pointNode.Tag = p;
            return pointNode;
        }

        protected override void PointAdded(object sender, EventArgs args)
        {
            Point p = (Point)sender;
            if (isPointShouldBeVisible(p))
            {
                TreeNode pointNode = preparePointElement(p);
                rootNode.Nodes.Add(pointNode);
                base.PointAdded(sender, args);
            }
        }

        private bool isPointShouldBeVisible(Point p)
        {
            bool isXGreater = p.getX() > 0;
            return (isXGreater && !AppModel.FILTER.LESS.ToString().Equals(filterSelect.GetItemText(filterSelect.SelectedItem))
                || (!isXGreater && !AppModel.FILTER.GREATER.ToString().Equals(filterSelect.GetItemText(filterSelect.SelectedItem))));
        }

        protected override void PointEdited(object sender, EventArgs args)
        {
            Point p = (Point)sender;
            bool isPointFound = false;
            foreach (TreeNode node in rootNode.Nodes)
            {
                if (node.Tag.Equals(p))
                {
                    isPointFound = true;
                    if (!isPointShouldBeVisible(p))
                    {
                        node.Remove();
                        return;
                    }
                    foreach (TreeNode subNode in node.Nodes)
                    {
                        if ("x".Equals(subNode.Name))
                        {
                            subNode.Nodes[0].Text = p.getX().ToString();
                        }
                        else if ("y".Equals(subNode.Name))
                        {
                            subNode.Nodes[0].Text = p.getY().ToString();
                        }
                        else if ("color".Equals(subNode.Name))
                        {
                            subNode.Nodes[0].Text = p.getColor().ToString();
                        }
                    }
                    node.Text = p.getLabel();
                }
            }
            if (!isPointFound && isPointShouldBeVisible(p))
            {
                TreeNode pointNode = preparePointElement(p);
                rootNode.Nodes.Add(pointNode);
            }
        }

        protected override void PointRemoved(object sender, EventArgs args)
        {
            Point p = (Point)sender;
            foreach (TreeNode node in rootNode.Nodes)
            {
                if (node.Tag.Equals(p))
                {
                    node.Remove();
                }
            }
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            TreeNode item = treeView.SelectedNode;
            if (item.Tag != null)
            {
                AppModel.RemovePoint((Point)item.Tag);
            }
        }

        private void filterSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            string filterName = comboBox.GetItemText(comboBox.SelectedItem);
            if (AppModel.FILTER.GREATER.ToString().Equals(filterName))
            {
                rootNode.Nodes.Clear();
                foreach (Point p in AppModel.Points)
                {
                    if (p.getX() > 0)
                        rootNode.Nodes.Add(preparePointElement(p));
                }
            }
            else if (AppModel.FILTER.LESS.ToString().Equals(filterName))
            {
                rootNode.Nodes.Clear();
                treeView.BeginUpdate();
                foreach (Point p in AppModel.Points)
                {
                    if (p.getX() < 0)
                        rootNode.Nodes.Add(preparePointElement(p));
                }
                treeView.EndUpdate();
            }
            else
            {
                rootNode.Nodes.Clear();
                treeView.BeginUpdate();
                foreach (Point p in AppModel.Points)
                {
                    rootNode.Nodes.Add(preparePointElement(p));
                }
                treeView.EndUpdate();
            }
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            TreeNode item = treeView.SelectedNode;
            if (item.Tag != null)
            {
                Point point = (Point)item.Tag;
                PointForm pointForm = new PointForm(point);
                if (pointForm.ShowDialog() == DialogResult.OK)
                {
                    AppModel.EditPoint(point);
                }
            }
        }

    }
}
