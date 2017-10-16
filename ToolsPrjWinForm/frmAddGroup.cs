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
    public partial class frmAddGroup : Form
    {
        internal string Value { get; set; }

        public frmAddGroup()
        {
            InitializeComponent();
        }

        private void frmAddGroup_Load(object sender, EventArgs e)
        {
            if (Value != null) txtName.Text = Value.ToString();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if(txtName.Text  == "")
            {
                MessageBox.Show("Поле\"Название\" не должно быть пустым!", "Ошибка!", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
            else
            {
                Value = txtName.Text;
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void txtName_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                btnOk.PerformClick();
            }
        }


    }
}
