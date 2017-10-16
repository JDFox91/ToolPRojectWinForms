using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Configuration;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ToolsPrjWinForm.Contexts;
using ToolsPrjWinForm.Entities;

namespace ToolsPrjWinForm
{
    public partial class frmAddRecord : Form
    {
        private readonly Worker _worker;

        public frmAddRecord()
        {
            InitializeComponent();
        }

        public frmAddRecord(Worker worker) : this()
        {
            _worker = worker;
            Text = _worker.FullName;
        }

        private void frmGiveTool_Load(object sender, EventArgs e)
        {
            RefreshList();
        }

        private void RefreshList()
        {
            using (var context = new Context())
            {
                grid.DataSource = context.Items.Include("Group").Include("Worker").Where(x => x.Worker.Id == _worker.Id)
                    .Select(x =>
                        new
                        {
                            x.Id,
                            x.GiveDate,
                            x.Group,
                            x.Name,
                            x.IdNum,
                            x.Code
                        }).OrderByDescending(x => x.GiveDate).ToList();
            }
        }

        private void btnGetTool_Click(object sender, EventArgs e)
        {
            var frm = new frmGetItem();

            if (frm.ShowDialog() == DialogResult.OK)
            {
                Guid Id = frm.Id;

                using (var context = new Context())
                {
                    var worker = context.Workers.First(x => x.Id == _worker.Id);
                    try
                    {
                        var item = context.Items.First(x => x.Id == Id);

                        item.Condition = Condition.Given;
                        item.Worker = worker;
                        item.GiveDate = DateTime.Now;

                        var history = new History(History.Action.Give);
                        history.Item = context.Items.First(x => x.Id == item.Id);
                        history.Worker = item.Worker.FullName;

                        context.Histories.Add(history);

                        context.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message + "\n" + ex.InnerException + "\n" + ex.StackTrace);
                    }
                }
                RefreshList();
            }

        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (grid.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите запись!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Guid id = Guid.Parse(grid.SelectedRows[0].Cells["colId"].Value.ToString());

            using (var context = new Context())
            {
                Item item = context.Items.Include("Worker").Include("Group").First(x => x.Id == id);

                if (MessageBox.Show($"Списать следующий инструмент с работника?\n {item.Group.Name}, {item}",
                        "Предупреждение", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                    return;

                var history = new History(History.Action.Return);
                history.Item = context.Items.First(x => x.Id == item.Id);
                history.Worker = item.Worker.FullName;

                item.Worker = null;
                item.Condition = Condition.Free;
                item.GiveDate = null;

                context.Histories.Add(history);

                try
                {
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + Environment.NewLine + ex.StackTrace);
                }
                RefreshList();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnLost_Click(object sender, EventArgs e)
        {
            if (grid.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите запись!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Guid id = Guid.Parse(grid.SelectedRows[0].Cells["colId"].Value.ToString());

            using (var context = new Context())
            {
                Item item = context.Items.Include("Worker").Include("Group").First(x => x.Id == id);

                if (MessageBox.Show($"Списать инструмент с работника в связи с утерей?\n {item.Group.Name}, {item}",
                        "Предупреждение", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                    return;

                var history = new History(History.Action.Lost);
                history.Item = context.Items.First(x => x.Id == item.Id);
                history.Worker = item.Worker.FullName;

                item.Worker = null;
                item.Condition = Condition.Lost;
                item.GiveDate = null;

                context.Histories.Add(history);

                try
                {
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + Environment.NewLine + ex.StackTrace);
                }
                RefreshList();
            }
        }
    }
}
