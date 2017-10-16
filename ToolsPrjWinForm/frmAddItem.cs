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
    public partial class frmAddItem : Form
    {

        internal Item Item { get; set; }
   
        public frmAddItem()
        {
            InitializeComponent();
            dtpCheckDate.Format = DateTimePickerFormat.Custom;
            dtpCheckDate.CustomFormat = "MM / yyyy";
        }

        public frmAddItem(Item item) : this()
        {
            Item = item;
        }

        private void frmItemList_Load(object sender, EventArgs e)
        {
            txtGroup.Text = Item.Group.ToString();
            txtName.Text = Item.Name;
            txtCode.Text = Item.Code;
            txtIdNum.Text = Item.IdNum;
            dtpCheckDate.Value = Item.CheckDate;
            chk.Checked = dtpCheckDate.Value == dtpCheckDate.MinDate ? true : false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Item.Name = txtName.Text;
            Item.IdNum = txtIdNum.Text;
            Item.Code = txtCode.Text;
            Item.CheckDate = chk.Checked ? dtpCheckDate.MinDate : dtpCheckDate.Value;

            DialogResult = DialogResult.OK;
            Close();
        }

        private void chk_CheckedChanged(object sender, EventArgs e)
        {
            if (chk.Checked)
            {
                dtpCheckDate.Enabled = false;
                dtpCheckDate.Value = dtpCheckDate.MinDate;
            }
            else
            {
                dtpCheckDate.Enabled = true;
                dtpCheckDate.Value = DateTime.Now;
            }
        }
    }
}
