using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ToolsPrjWinForm;
using ToolsPrjWinForm.Contexts;
using ToolsPrjWinForm.Entities;

namespace ToolsPrjWinForm
{
    public partial class frmGetItem : Form
    {
        public Guid Id { get; private set; }
        public bool ShowAll { get; set; } = false;

        public frmGetItem()
        {
            InitializeComponent();
        }

        public frmGetItem(bool b) : this()
        {
            ShowAll = b;
        }

        private void RefreshGroup()
        {
            lstGroup.DisplayMember = "Name";
            lstGroup.ValueMember = "Id";
            using (var context = new Context())
            {
                lstGroup.DataSource = context.Groups.OrderBy(x => x.Name).ToList();
            }
        }

        private void RefreshItem(Group group)
        {
            lstItem.DisplayMember = "FullName";
            lstItem.ValueMember = "Id";
            using (var context = new Context())
            {
                //показывает все элементы
                if (ShowAll)
                    lstItem.DataSource = context.Items.Where(x => x.Group.Id == group.Id).
                        OrderBy(x => x.Name).ThenByDescending(x => x.CheckDate).ToList();
                //показывает только доступные к выдаче элементы
                else
                    lstItem.DataSource = context.Items.Where(x => x.Group.Id == group.Id && x.Condition == Condition.Free).OrderBy(x => x.Name).
                        ThenByDescending(x => x.CheckDate).ToList();
            }
        }

        private void frmGetItem_Load(object sender, EventArgs e)
        {
            RefreshGroup();
            //изменение формы для использования в другом месте
            if (ShowAll)
            {
                btnCancel.Text = "Закрыть";
                btnOk.Visible = false;
            }
            rdbNameSearch.Checked = true;
        }

        private void lstGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            Group group = lstGroup.SelectedItem as Group;

            if(group == null)
            {
                MessageBox.Show("Выберите группу", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            RefreshItem(group);
        }

        private void добавитьВБазуНовыйИнструментToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new frmItemList();
            frm.ShowDialog();
            RefreshGroup();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (ShowAll)
            {
                Close();
                return;
            }

            var item = lstItem.SelectedItem as Item;
            if(item == null)
            {
                MessageBox.Show("Выберите элемент", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Id = item.Id;

            DialogResult = DialogResult.OK;
            Close();
        }

        private void lstItem_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if(ShowAll)
                btnInfo.PerformClick();
            else
                btnOk.PerformClick();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnInfo_Click(object sender, EventArgs e)
        {
            Item item = lstItem.SelectedItem as Item;

            if (item == null)
            {
                MessageBox.Show("Выберите элемент группы", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var frm = new frmItemInfo(item);
            frm.ShowDialog();
        }

        private void FilterItemList()
        {
            using (var context = new Context())
            {
                IList<Item> list;

                if (rdbNameSearch.Checked)
                {
                    list = context.Items.Where(x => x.Name.ToLower().StartsWith(txtSearchBar.Text.ToLower()))
                        .OrderBy(x => x.Name).ToList();
                    lstItem.DisplayMember = "FullName";
                    lstItem.ValueMember = "Id";
                    lstItem.DataSource = list;
                }
                if (rdbIdSearch.Checked)
                {
                    list = context.Items.Where(x => x.IdNum.ToLower().StartsWith(txtSearchBar.Text.ToLower()))
                        .OrderBy(x => x.Name).ToList();
                    lstItem.DisplayMember = "FullName";
                    lstItem.ValueMember = "Id";
                    lstItem.DataSource = list;
                }
                if (rdbCodeSearch.Checked)
                {
                    list = context.Items.Where(x => x.Code.ToLower().StartsWith(txtSearchBar.Text.ToLower()))
                        .OrderBy(x => x.Name).ToList();
                    lstItem.DisplayMember = "FullName";
                    lstItem.ValueMember = "Id";
                    lstItem.DataSource = list;
                }
                
            }

            if (txtSearchBar.Text == string.Empty)
            {
                txtSearchBar.Text = "";
                Group group = lstGroup.SelectedItem as Group;
                RefreshItem(group);
            }
        }

        private void txtSearchBar_TextChanged(object sender, EventArgs e)
        {
            FilterItemList();
        }
    }
}
