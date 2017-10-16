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
    public partial class frmAddWorker : Form
    {
        public Worker Worker { get; }

        public frmAddWorker()
        {
            InitializeComponent();
        }

        public frmAddWorker(Worker worker)
        {
            InitializeComponent();
            Worker = worker;
        }

        private void frmAddWorker_Load(object sender, EventArgs e)
        {
            txtName.Focus();
            txtName.Text = Worker.WorkerName;
            nmrPersonalNumber.Value = Worker.PersonalNumber;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Worker.WorkerName = txtName.Text;
            Worker.PersonalNumber = (int)nmrPersonalNumber.Value;
            DialogResult = DialogResult.OK;
            Close(); 
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void nmrPersonalNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                btnOk_Click(sender, e);
            }
        }

        private void nmrPersonalNumber_Enter(object sender, EventArgs e)
        {
            nmrPersonalNumber.Select(0, nmrPersonalNumber.Text.Length);
        }
    }
}
