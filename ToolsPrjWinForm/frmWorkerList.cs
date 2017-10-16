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

namespace ToolsPrjWinForm.Form_Add_Item
{
    public partial class frmWorkerList : Form
    {
        public frmWorkerList()
        {
            InitializeComponent();
        }

        private void frmWorkerList_Load(object sender, EventArgs e)
        {
            RefreshWorkerList();
        }

        private void RefreshWorkerList()
        {
            using (var context = new Context())
            {
                lstWorkers.DisplayMember = "FullName";
                lstWorkers.ValueMember = "Id";
                lstWorkers.DataSource = context.Workers.OrderBy(x => x.WorkerName).ToList();
            }
        }

        private void btnAddWorker_Click(object sender, EventArgs e)
        {
            Worker newWorker = new Worker();
            var frm = new frmAddWorker(newWorker);

            if (frm.ShowDialog() == DialogResult.OK)
            {
                //Проверка на совпадения в листе
                int i = lstWorkers.FindStringExact(newWorker.FullName);
                if (i != -1)
                {
                    MessageBox.Show("Такая запись уже существует", "Предупреждение", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    lstWorkers.SetSelected(i, true);
                    return;
                }

                using (var context = new Context())
                {
                    try
                    {
                        context.Workers.Add(newWorker);
                        context.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message + Environment.NewLine + ex.InnerException + Environment.NewLine +
                                        ex.StackTrace);
                    }
                    RefreshWorkerList();
                }
            }
        }

        private void btnEditWorker_Click(object sender, EventArgs e)
        {
            Worker tmp = lstWorkers.SelectedItem as Worker;

            if (tmp == null)
            {
                MessageBox.Show("Сначала выберите запись", "Предупреждение", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            Worker editWorker = new Worker(tmp);

            var frm = new frmAddWorker(editWorker);

            editWorker = frm.Worker;

            if(frm.ShowDialog() == DialogResult.OK)
            {
                int i = lstWorkers.FindStringExact(editWorker.FullName);
                if (i != -1)
                {
                    MessageBox.Show("Такая запись уже существует", "Предупреждение", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    lstWorkers.SetSelected(i, true);
                    return;
                }

                using (var context = new Context())
                {
                    var worker = context.Workers.First(x => x.Id == editWorker.Id);
                    worker.WorkerName = editWorker.WorkerName;
                    worker.PersonalNumber = editWorker.PersonalNumber;

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
                RefreshWorkerList();
            }

            
        }

        private void btnDeleteWorker_Click(object sender, EventArgs e)
        {
            using (var context = new Context())
            {
                var tmp = lstWorkers.SelectedItem as Worker;
                
                if (tmp == null)
                {
                    MessageBox.Show("Сначала выберите запись", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                var worker = context.Workers.FirstOrDefault(x => x.Id == tmp.Id);

                if (worker == null)
                {
                    MessageBox.Show("Запись не найдена", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (context.Items.Any(x => x.Worker.Id == worker.Id))
                {
                    MessageBox.Show("За выбранным работником числится инструмент, перед удалением из базы данных спишите с него весь инструмент", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    var frm = new frmAddRecord(worker);
                    frm.ShowDialog();
                }
                else
                {
                    if (MessageBox.Show("Удалить запись?", "Удаление", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        try
                        {
                            context.Workers.Remove(worker);
                            context.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message + Environment.NewLine + ex.StackTrace + Environment.NewLine + ex.InnerException);
                        }
                        
                        RefreshWorkerList();
                    }
                }
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
