using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DocumentFormat.OpenXml.Drawing;
using ToolsPrjWinForm.Contexts;
using ToolsPrjWinForm.Entities;

namespace ToolsPrjWinForm
{
    public partial class frmItemInfo : Form
    {
        private readonly Item _item;

        public frmItemInfo()
        {
            InitializeComponent();
        }

        public frmItemInfo(Item item)
        {
            _item = item;
            InitializeComponent();
        }

        private void frmItemInfo_Load(object sender, EventArgs e)
        {
            using (var context = new Context())
            {
                string[] m =
                {
                    "январь", "февраль", "март",
                    "апрель", "май", "июнь",
                    "июль", "август", "сентябрь",
                    "октябрь", "ноябрь", "декабрь"
                };
                
                var item = context.Items.Include("Group").Include("Worker").First(x => x.Id == _item.Id);
                txtCreateDate.Text = item.CreateDate.ToLongDateString();
                txtGroup.Text = item.GroupName;
                txtName.Text = item.Name;
                txtIdNum.Text = item.IdNum;
                txtCode.Text = item.Code;

                btnEditCondition.Enabled = false;

                DateTimePicker p = new DateTimePicker();

                txtCheckDate.Text = item.CheckDate == p.MinDate ?  "Резерв" : string.Format(m[item.CheckDate.Month - 1] + " " + item.CheckDate.Year + " г.");

                switch (item.Condition)
                {
                    case Condition.Free:
                        txtCondition.Text = "Инструмент на складе";
                        break;
                    case Condition.Given:
                        txtCondition.Text = "Инструмент выдан";
                        break;
                    case Condition.Lost:
                        txtCondition.Text = "Инструмент утерян";
                        break;
                    case Condition.Defected:
                        txtCondition.Text = "Инструмент забракован";
                        break;
                }

                txtWorker.Text = item.Worker == null ? string.Empty : item.Worker.FullName;

                if (item.Condition != Condition.Given)
                {
                    btnEditCondition.Enabled = true;
                }
                btnReturnItem.Enabled = item.Worker == null ? false : true;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnHistory_Click(object sender, EventArgs e)
        {
            var frm = new frmItemHistory(_item);
            frm.ShowDialog();
        }

        private void btnReturnItem_Click(object sender, EventArgs e)
        {
            using (var context = new Context())
            {
                Item item = context.Items.Include("Worker").Include("Group").First(x => x.Id == _item.Id);

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
                    MessageBox.Show(ex.Message + Environment.NewLine + ex.InnerException + Environment.NewLine + ex.StackTrace);
                }
                txtCondition.Text = "Инструмент на складе";
                btnEditCondition.Enabled = true;
                txtWorker.Text = string.Empty;
                btnReturnItem.Enabled = false;
            }
        }

        private void btnEditCondition_Click(object sender, EventArgs e)
        {
            using (var context = new Context())
            {
                var editItem = context.Items.Include("Group").Include("Worker").First(x => x.Id == _item.Id);
                var frm = new frmChangeCondition();
                if (MessageBox.Show("Изменение состояния объекта в следующем окне не фиксируется в истории. \n\nПродолжить?", "Предупреждение"
                    , MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) != DialogResult.OK)
                    return;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    switch (frm.Condition)
                    {
                        case Condition.Free:
                            editItem.Condition = Condition.Free;
                            txtCondition.Text = "Инструмент на складе";
                            break;
                        case Condition.Given:
                            editItem.Condition = Condition.Given;
                            txtCondition.Text = "Инструмент выдан";
                            break;
                        case Condition.Lost:
                            editItem.Condition = Condition.Lost;
                            txtCondition.Text = "Инструмент утерян";
                            break;
                        case Condition.Defected:
                            editItem.Condition = Condition.Defected;
                            txtCondition.Text = "Инструмент забракован";
                            break;
                    }
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
            }
        }

    }
}
