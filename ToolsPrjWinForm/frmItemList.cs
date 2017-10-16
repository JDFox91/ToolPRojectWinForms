using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using ToolsPrjWinForm.Contexts;
using ToolsPrjWinForm.Entities;

namespace ToolsPrjWinForm
{
    public partial class frmItemList : Form
    {
        internal Item Item { get; private set; }

        public frmItemList()
        {
            InitializeComponent();
        }

        private void frmItemList_Load(object sender, EventArgs e)
        {
            RefreshGroupList();
            lstItems.MultiColumn = true;
            rdbNameSearch.Checked = true;
        }

        #region Group events

        private void RefreshGroupList()
        {
            lstGroups.DisplayMember = "Name";
            lstGroups.ValueMember = "Id";
            using (var context = new Context())
            {
                lstGroups.DataSource = context.Groups.OrderBy(x => x.Name).ToList();
            }
        }

        private void btnAddGroup_Click(object sender, EventArgs e)
        {
            var frm = new frmAddGroup();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                var indx = lstGroups.FindStringExact(frm.Value);
                if (indx == -1)
                {
                    var group = new Group();
                    group.Name = frm.Value;
                    using (var context = new Context())
                    {
                        try
                        {
                            context.Groups.Add(group);
                            context.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message + "\n" + ex.StackTrace);
                        }
                    }
                    RefreshGroupList();
                }
                else
                {
                    MessageBox.Show("Запись с таким именем уже существует", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lstGroups.SetSelected(indx, true);
                }
            }
        }

        private void btnEditGroup_Click(object sender, EventArgs e)
        {
            var frm = new frmAddGroup();
            Group group = lstGroups.SelectedItem as Group;
            if (group == null)
            {
                MessageBox.Show("Выберите запись для редактирования", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            frm.Value = group.Name;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                var indx = lstGroups.FindStringExact(frm.Value);
                if (indx == -1)
                {
                    using (var context = new Context())
                    {
                        var editGr = context.Groups.First(x => x.Id == group.Id);
                        editGr.Name = frm.Value;
                        context.SaveChanges();
                    }

                    RefreshGroupList();
                }
                else
                {
                    MessageBox.Show("Запись с таким именем уже существует", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lstGroups.SetSelected(indx, true);
                }
            }
            else return;
        }

        private void btnDeleteGroup_Click(object sender, EventArgs e)
        {
            using (var context = new Context())
            {
                var group = (Group) lstGroups.SelectedItem;

                if (group == null)
                {
                    MessageBox.Show("Выберите запись для удаления.", "Ошибка", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    return;
                }


                if (context.Items.Any(x => x.Group.Id == group.Id))
                {
                    MessageBox.Show("Для удаления группы необходимо удалить все элементы, содержащиеся в ней", "",
                        MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    return;
                }

                if (MessageBox.Show("Удалить запись?", "Предупреждение", MessageBoxButtons.OKCancel,
                        MessageBoxIcon.Question) == DialogResult.OK)
                {
                    context.Groups.Remove(context.Groups.First(x => x.Id == group.Id));
                    context.SaveChanges();
                    RefreshGroupList();
                }
            }
        }

        private void lstGroups_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshItemList();
        }

        #endregion

        #region Item events

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            var group = lstGroups.SelectedItem as Group;

            if (group == null)
            {
                MessageBox.Show("Выберите группу для добавления", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Item item = new Item()
            {
                Group = group,
                CheckDate = DateTime.Now
            };

            var frm = new frmAddItem(item);

            if (frm.ShowDialog() != DialogResult.OK)
                return;
            
            //Проверка на повторение в списке
            int i = lstItems.FindStringExact(item.FullName);
            if (i != -1)
            {
                MessageBox.Show("Такая запись уже существует", "Предупреждение", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                lstItems.SetSelected(i, true);
                return;
            }

            using (var context = new Context())
            {
                try
                {
                    item.Group = context.Groups.First(x => x.Id == group.Id);
                    context.Items.Add(item);
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + Environment.NewLine + ex.InnerException + Environment.NewLine +
                                    ex.StackTrace);
                }
            }

            RefreshItemList();
        }

        private void btnEditItem_Click(object sender, EventArgs e)
        {
            var tmp = lstItems.SelectedItem as Item;

            if (tmp == null)
            {
                MessageBox.Show("Выберите запись для редактирования", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Item item = new Item(tmp);

            var frm = new frmAddItem(item);

            if (frm.ShowDialog() != DialogResult.OK)
                return;

            int i = lstItems.FindStringExact(item.FullName);
                if (i != -1)
                {
                    MessageBox.Show("Такая запись уже существует", "Предупреждение", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    lstItems.SetSelected(i, true);
                    return;
                }

            using (var context = new Context())
            {
                var editItem = context.Items.Include("Group").First(x => x.Id == tmp.Id);
                editItem.CheckDate = item.CheckDate;
                editItem.Code = item.Code;
                editItem.IdNum = item.IdNum;
                editItem.Name = item.Name;

                try
                {
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + Environment.NewLine + ex.InnerException + Environment.NewLine +
                                    ex.StackTrace);
                }
            }

            RefreshItemList();
        }

        private void btnDeleteItem_Click(object sender, EventArgs e)
        {
                var tmp = lstItems.SelectedItem as Item;

                if (tmp == null)
                {
                    MessageBox.Show("Выберите запись для удаления", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

            using (var context = new Context())
            {
                Item deleteItem = context.Items.Include("Group").Include("Worker").First(x => x.Id == tmp.Id);

                bool histories = context.Histories.Any(x => x.Item.Id == deleteItem.Id);

                if (deleteItem.Worker != null)
                {
                    MessageBox.Show(
                        $"Этот инструмент числится за работником. \nПеред удалением спишите инструмент с работника. \n\nРаботник: {deleteItem.Worker.FullName}",
                        "Удаление", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                        return;
                }

                if (histories)
                {
                    if (MessageBox.Show(
                            "С этим элементом так же будет удалена вся история его перемещения.\nПродолжить?",
                            "Удаление", MessageBoxButtons.OKCancel,
                            MessageBoxIcon.Question) != DialogResult.OK)
                        return;
                }
                else
                {
                    if (MessageBox.Show(
                            "Удалить запись?",
                            "Удаление", MessageBoxButtons.OKCancel,
                            MessageBoxIcon.Question) != DialogResult.OK)
                        return;
                }

                if (histories)
                {
                    IEnumerable<History> list = context.Histories.Where(x => x.Item.Id == deleteItem.Id);
                    context.Histories.RemoveRange(list);
                }

                context.Items.Remove(deleteItem);
                context.SaveChanges();
            }
                RefreshItemList();
        }

        private void RefreshItemList()
        {
            var group = lstGroups.SelectedItem as Group;
            if (group == null)
                return;

            using (var context = new Context())
            {
                var items = context.Items.Include("Group").Where(x => x.Group.Id == group.Id);
                
                lstItems.DisplayMember = "FullName";
                lstItems.ValueMember = "Id";
                lstItems.DataSource = items.OrderBy(x => x.Name).ToList();
            }
        }

        private void lstItems_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var item = lstItems.SelectedItem as Item;
            var frm = new frmItemInfo(item);
            frm.Show();
        }

        #endregion

        private void btnOk_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void txtSearchBar_TextChanged(object sender, EventArgs e)
        {
            FilterItemList();
        }

        private void FilterItemList()
        {
            using (var context = new Context())
            {
                IList<Item> list;

                if (rdbNameSearch.Checked)
                {
                    list = context.Items.Include("Group").Where(x => x.Name.ToLower().StartsWith(txtSearchBar.Text.ToLower()))
                        .OrderBy(x => x.Name).ToList();
                    lstItems.DisplayMember = "FullName";
                    lstItems.ValueMember = "Id";
                    lstItems.DataSource = list;
                }
                if (rdbIdSearch.Checked)
                {
                    list = context.Items.Include("Group").Where(x => x.IdNum.ToLower().StartsWith(txtSearchBar.Text.ToLower()))
                        .OrderBy(x => x.Name).ToList();
                    lstItems.DisplayMember = "FullName";
                    lstItems.ValueMember = "Id";
                    lstItems.DataSource = list;
                }
                if (rdbCodeSearch.Checked)
                {
                    list = context.Items.Include("Group").Where(x => x.Code.ToLower().StartsWith(txtSearchBar.Text.ToLower()))
                        .OrderBy(x => x.Name).ToList();
                    lstItems.DisplayMember = "FullName";
                    lstItems.ValueMember = "Id";
                    lstItems.DataSource = list;
                }
            }

            if (txtSearchBar.Text == string.Empty)
            {
                txtSearchBar.Text = "";
                RefreshItemList();
            }
        }
    }
}
