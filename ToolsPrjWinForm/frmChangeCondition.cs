using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ToolsPrjWinForm.Entities;

namespace ToolsPrjWinForm
{
    public partial class frmChangeCondition : Form
    {
        public Condition Condition { get; set; }

        public frmChangeCondition()
        {
            InitializeComponent();
        }

        private void frmChangeCondition_Load(object sender, EventArgs e)
        {

        }

        private void btnFree_Click(object sender, EventArgs e)
        {
            Condition = Condition.Free;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnLost_Click(object sender, EventArgs e)
        {
            Condition = Condition.Lost;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnDefected_Click(object sender, EventArgs e)
        {
            Condition = Condition.Defected;
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
