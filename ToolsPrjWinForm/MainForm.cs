using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClosedXML.Excel;
using DocumentFormat.OpenXml.Spreadsheet;
using ToolsPrjWinForm;
using ToolsPrjWinForm.Contexts;
using ToolsPrjWinForm.Entities;
using ToolsPrjWinForm.Form_Add_Item;

namespace ToolsPrjWinForm
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void списокИнструментаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new frmItemList();
            frm.ShowDialog();
        }

        private void списокРабочихToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new frmWorkerList();
            frm.ShowDialog();
        }

        private void btnGiveTool_Click(object sender, EventArgs e)
        {
            var frm = new frmGetWorker();
            frm.ShowDialog();
        }

        private void btnItemInfo_Click(object sender, EventArgs e)
        {
            var frm = new frmGetItem(true);
            frm.ShowDialog();
        }

        private void очиститьИсториюПеремещенияИнструментаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Данное действие очистит историю перемещения инструмента, доступного к выдаче."
                + "История утерянного, выданного и дефектного инструмента удалена не будет.Это может занять некоторое время. Данное действие НЕОБРАТИМО.\n\nПродолжить?",
                "Удаление", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                using (var context = new Context())
                {
                    var list = context.Histories.Include("Item").Where(x => x.Item.Condition == Condition.Free);
                    bool result;
                    try
                    {
                        context.Histories.RemoveRange(list);
                        context.SaveChanges();
                        result = true;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message + Environment.NewLine + ex.InnerException + Environment.NewLine +
                                        ex.StackTrace);
                        result = false;
                    }
                    if (result)
                        MessageBox.Show("Удаление произведено успешно!", "Информация", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    else
                        MessageBox.Show("Ошибка при удалении!", "Ошибка", MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                }
            }
        }

        private void выборкаНаПроверкуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new frmGetDate();
            frm.ShowDialog();
        }

        private void помощьToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void отчетыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            XLWorkbook wb = new XLWorkbook();
            var ws = wb.Worksheets.Add("Выборка инструмента на проверку");

            ws.Cell(1, 1).Value = "Наименование";
            ws.Cell(1, 2).Value = "Идентификатор";
            ws.Cell(1, 3).Value = "Шифр";
            ws.Cell(1, 4).Value = "Дата проверки";
            ws.Cell(1, 4).Value = "Рабочий";
        }
    }
}
