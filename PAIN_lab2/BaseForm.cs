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
            appModel.PointRemoved += RemovePoint;
            //appModel.PointChanged += PointChanged;
            //appModel.PointRemoved += PointRemoved;

        }

        protected virtual void PointAdded(object sender, EventArgs args)
        {
        }

        protected virtual void RemovePoint(object sender, EventArgs args)
        {

        }
    }
}
