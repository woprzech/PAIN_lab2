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
    public partial class BaseForm : Form
    {

        protected AppModel AppModel { get; private set; }
        public BaseForm()
        {
            InitializeComponent();
        }

        public BaseForm(AppModel appModel)
        {
            InitializeComponent();

            AppModel = appModel;
            appModel.PointAdded += PointAdded;
            appModel.PointRemoved += PointRemoved;
            appModel.PointEdited += PointEdited;

        }

        protected virtual void PointAdded(object sender, EventArgs args)
        {
        }

        protected virtual void PointRemoved(object sender, EventArgs args)
        {
        }

        protected virtual void PointEdited(object sender, EventArgs args)
        {
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            MDIParent1 parent = (MDIParent1)Parent.Parent;
            var reason = (FormClosingEventArgs)e;
            if (parent.childFormNumber <= 1 && reason.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
            }
            else
            {
                base.OnClosing(e);
                parent.childFormNumber--;
            }
        }
    }
}
