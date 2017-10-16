using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToolsPrjWinForm
{
    public partial class frmGetDate : Form
    {
        private readonly bool _getDateOnly;

        public DateTime Date { get; private set; }
        
        public frmGetDate()
        {
            InitializeComponent();
            dtpDate.Format = DateTimePickerFormat.Custom;
            Date = dtpDate.Value;
            dtpDate.CustomFormat = "MMMM yyyy года";
        }

        public frmGetDate(bool getDateOnly) : this()
        {
            _getDateOnly = getDateOnly;
        }

        private void frmGetDate_Load(object sender, EventArgs e)
        {

        }

        private void dtpDate_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnOk.PerformClick();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (!_getDateOnly)
            {
                var frm = new frmCheckList(dtpDate.Value);
                frm.ShowDialog();
            }
            else
            {
                Date = dtpDate.Value;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dtpDate_ValueChanged(object sender, EventArgs e)
        {
            Date = dtpDate.Value;
        }
    }
}
