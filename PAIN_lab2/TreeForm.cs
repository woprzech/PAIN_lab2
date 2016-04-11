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
            xName.Nodes.Add(xValue);
            TreeNode yValue = new TreeNode(p.getY() + "");
            TreeNode yName = new TreeNode("y");
            yName.Nodes.Add(yValue);
            TreeNode colorValue = new TreeNode("color");
            TreeNode colorName = new TreeNode("color");
            colorName.Nodes.Add(colorValue);
            TreeNode pointNode = new TreeNode("point");
            pointNode.Nodes.Add(xName);
            pointNode.Nodes.Add(yName);
            pointNode.Nodes.Add(colorName);
            return pointNode;
        }

        protected override void PointAdded(object sender, EventArgs args)
        {
            Point p = (Point)sender;
            TreeNode pointNode = preparePointElement(p);
            rootNode.Nodes.Add(pointNode);
            base.PointAdded(sender, args);
        }

    }
}
