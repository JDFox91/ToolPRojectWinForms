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
using ToolsPrjWinForm.Contexts;

namespace ToolsPrjWinForm
{
    public partial class frmGetWorker : Form
    {

        IList<Worker> _workerList;

        public frmGetWorker()
        {
            InitializeComponent();
        }

        private void RefreshWorkerList()
        {
            using (var context = new Context())
            {
                _workerList = context.Workers?.Where(x => x.Id != null).OrderBy(x => x.WorkerName).ToList();
            }
            lstWorkers.DisplayMember = "FullName";
            lstWorkers.ValueMember = "Id";
            lstWorkers.DataSource = _workerList;
        }

        private void frmGetWorker_Load(object sender, EventArgs e)
        {
            rdbPersonalNumberSearch.Checked = true;
            txtSearch.Focus();

            RefreshWorkerList();
        }

        private void Search()
        {
            #region PersonalNumber Search
            if (rdbPersonalNumberSearch.Checked)
            {
                using (var context = new Context())
                {
                    var list = context.Workers.Where(x => x.PersonalNumber.ToString().StartsWith(txtSearch.Text.ToLower()))
                        .OrderBy(x => x.WorkerName).ToList();
                    lstWorkers.DisplayMember = "FullName";
                    lstWorkers.ValueMember = "Id";
                    lstWorkers.DataSource = list;
                }
            }
            #endregion

            #region Name Search
            else if (rdbNameSearch.Checked)
            {
                using (var context = new Context())
                {
                    var list = context.Workers.Where(x => x.WorkerName.ToLower().StartsWith(txtSearch.Text.ToLower())).OrderBy(x => x.WorkerName).ToList();
                    lstWorkers.DisplayMember = "FullName";
                    lstWorkers.ValueMember = "Id";
                    lstWorkers.DataSource = list;
                }

            }
            #endregion

            if (txtSearch.Text == string.Empty)
            {
                txtSearch.Text = "";
                RefreshWorkerList();
            } 
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                Search();
            }
        }

        private void lstWorkers_DoubleClick(object sender, EventArgs e)
        {
            var worker = lstWorkers.SelectedItem as Worker;
            if (worker == null)
            {
                MessageBox.Show("Выберите запись", "Предупреждеие", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var frm = new frmAddRecord(worker);
            frm.Show();
        }

        private void btnAddWorker_Click(object sender, EventArgs e)
        {
            var worker = new Worker();
            var frm = new frmAddWorker(worker);
            if(frm.ShowDialog() == DialogResult.OK)
            {
                int indx = lstWorkers.FindStringExact(worker.FullName);
                if (indx == -1)
                {
                    using (var context = new Context())
                    {
                        try
                        {
                            context.Workers.Add(worker);
                            context.SaveChanges();
                        }
                        catch(Exception ex)
                        {
                            MessageBox.Show(ex.Message + "\n" + ex.StackTrace);
                        }
                    }

                    RefreshWorkerList();
                    int i = lstWorkers.FindStringExact(worker.FullName);
                    lstWorkers.SetSelected(i, true);
                }
                else
                {
                    MessageBox.Show("Запись с таким именем уже существует", "Предупреждеие", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lstWorkers.SetSelected(indx, true);
                }
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            lstWorkers_DoubleClick(sender, e);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            Search();
        }

        private void rdbPersonalNumberSearch_CheckedChanged(object sender, EventArgs e)
        {
            txtSearch.Focus();
        }
    }
}
