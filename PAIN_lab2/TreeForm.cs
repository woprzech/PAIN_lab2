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
    public partial class TreeForm : Form
    {
        private TreeView treeView;
        private List<Point> points;

        public TreeForm(List<Point> points)
        {
            InitializeComponent();

            this.points = points;

            createTreeView();
        }

        private void createTreeView()
        {
            treeView = new TreeView();
            //treeView.View = View.Details;
            treeView.Size = new System.Drawing.Size(200, 200);
            int counter = 0;
            TreeNode[] pointNodes = new TreeNode[3];

            foreach (Point p in points)
            {
                TreeNode xValue = new TreeNode(p.getX() + "");
                TreeNode[] children = new TreeNode[] { xValue };
                TreeNode xName = new TreeNode("x", children);
                TreeNode yValue = new TreeNode(p.getY() + "");
                children = new TreeNode[] { yValue };
                TreeNode yName = new TreeNode("y", children);
                TreeNode zValue = new TreeNode(p.getZ() + "");
                children = new TreeNode[] { zValue };
                TreeNode zName = new TreeNode("z", children);
                children = new TreeNode[] { xName, yName, zName };
                TreeNode pointNode = new TreeNode("point", children);
                pointNodes[counter++] = pointNode;
            }
            TreeNode rootNode = new TreeNode("points", pointNodes);

            TreeNode treeNode = new TreeNode("Windows");
            //
            // Another node following the first node.
            //
            treeNode = new TreeNode("Linux");
            //
            // Create two child nodes and put them in an array.
            // ... Add the third node, and specify these as its children.
            //
            TreeNode node2 = new TreeNode("C#");
            TreeNode node3 = new TreeNode("VB.NET");
            TreeNode[] array = new TreeNode[] { node2, node3 };
            //
            // Final node.
            //
            treeNode = new TreeNode("Dot Net Perls", array);
            treeView.Nodes.Add(rootNode);
            treeView.Show();
            this.Controls.Add(treeView);

        }

    }
}
