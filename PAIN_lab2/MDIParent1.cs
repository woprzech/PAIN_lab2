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
    public partial class MDIParent1 : Form
    {
        public int childFormNumber = 0;
        public AppModel AppModel { get; set; }

        private Form treeForm;
        private Form listForm;

        public MDIParent1(AppModel model)
        {
            InitializeComponent();

            this.AppModel = model;

            listForm = new ListForm(model);
            listForm.MdiParent = this;
            listForm.Show();

            treeForm = new TreeForm(model);
            treeForm.MdiParent = this;
            treeForm.Show();
            RefreshStatusString();
            childFormNumber = 2;
            model.PointRemoved += RefreshStatus;
        }

        private void CreateNewPoint(object sender, EventArgs e)
        {
            Point p = new Point();
            PointForm pointForm = new PointForm(p);
            if (pointForm.ShowDialog() == DialogResult.OK)
            {
                AppModel.AddPoint(p);
                RefreshStatusString();
            }
        }

        private void RefreshStatus(object sender, EventArgs e)
        {
            toolStripStatusLabel.Text = "Wyświetlono " + (AppModel.Points.Count - 1) + " punktów.";
        }

        public void RefreshStatusString()
        {
            toolStripStatusLabel.Text = "Wyświetlono " + AppModel.Points.Count + " punktów.";
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void OpenNewListView(object sender, EventArgs e)
        {
            listForm = new ListForm(AppModel);
            listForm.MdiParent = this;
            listForm.Show();
            childFormNumber++;
        }

        private void OpenNewTreeView(object sender, EventArgs e)
        {
            treeForm = new TreeForm(AppModel);
            treeForm.MdiParent = this;
            treeForm.Show();
            childFormNumber++;
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

    }
}
