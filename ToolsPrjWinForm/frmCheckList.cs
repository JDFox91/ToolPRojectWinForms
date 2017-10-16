using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DocumentFormat.OpenXml.Spreadsheet;
using ToolsPrjWinForm.Contexts;
using ToolsPrjWinForm.Entities;
using Item = ToolsPrjWinForm.Entities.Item;
using ClosedXML.Excel;

namespace ToolsPrjWinForm
{
    public partial class frmCheckList : Form
    {
        private readonly DateTime _date;

        private readonly string[] m =
        {
            "январь", "февраль", "март",
            "апрель", "май", "июнь",
            "июль", "август", "сентябрь",
            "октябрь", "ноябрь", "декабрь"
        };


        private frmCheckList()
        {
            InitializeComponent();
        }

        public frmCheckList(DateTime date) : this()
        {
            _date = date;
        }

        private void frmCheckList_Load(object sender, EventArgs e)
        {
            RefreshGrid();
        }

        private void RefreshGrid()
        {
            string[] m =
            {
                "январь", "февраль", "март",
                "апрель", "май", "июнь",
                "июль", "август", "сентябрь",
                "октябрь", "ноябрь", "декабрь"
            };

            Text = $"Список инструмента для проверки на {m[_date.Month - 1]} {_date.Year} года";

            using (var context = new Context())
            {

                grid.DataSource = context.Items.Include("Group").Include("Worker").
                    Where(x =>
                        x.CheckDate.Month == _date.Month &&
                        x.CheckDate.Year <= _date.Year &&
                        x.Condition != Condition.Defected &&
                        x.Condition != Condition.Lost).
                    Select(x =>
                        new
                        {
                            x.Id,
                            x.Group,
                            x.Name,
                            x.IdNum,
                            x.Code,
                            x.Worker.WorkerName
                        }).OrderBy(x => x.Group.Name).ThenBy(x => x.Name).ToList();
            }
        }

        private void btnInfo_Click(object sender, EventArgs e)
        {
            if (grid.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите запись!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Guid id = Guid.Parse(grid.SelectedRows[0].Cells["colId"].Value.ToString());

            using (var context = new Context())
            {
                Item item = context.Items.Include("Group").Include("Worker").First(x => x.Id == id);
                var frm = new frmItemInfo(item);
                frm.ShowDialog();
                RefreshGrid();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            //string[] m =
            //{
            //    "январь", "февраль", "март",
            //    "апрель", "май", "июнь",
            //    "июль", "август", "сентябрь",
            //    "октябрь", "ноябрь", "декабрь"
            //};

            var workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add(string.Format(m[_date.Month - 1] + " " + _date.Year + "г."));

            IList<Item> list;

            using (var context = new Context())
            {
                list = context.Items.Include("Group").Include("Worker").Where(x =>
                    x.CheckDate.Month == _date.Month &&
                    x.CheckDate.Year <= _date.Year &&
                    x.Condition != Condition.Defected &&
                    x.Condition != Condition.Lost).OrderBy(x => x.Group.Name).ThenBy(x => x.Name).ToList();
            }

            worksheet.Cell(1, 1).Value = "Группа";
            worksheet.Cell(1, 2).Value = "Имя";
            worksheet.Cell(1, 3).Value = "ИД";
            worksheet.Cell(1, 4).Value = "Шифр";
            worksheet.Cell(1, 5).Value = "Рабочий";
            worksheet.Cell(1, 6).Value = "Дата проверки";
            worksheet.Cell(1, 7).Value = "Примечание";

            int i;

            for (i = 0 ; i < list.Count; i++)
            {
                var date = list[i].CheckDate;
                string s = string.Format(m[date.Month - 1] + " " + date.Year);
                worksheet.Cell(i + 2, 1).Value = list[i].Group.Name;
                worksheet.Cell(i + 2, 2).Value = list[i].Name;
                worksheet.Cell(i + 2, 3).Value = list[i].IdNum;
                worksheet.Cell(i + 2, 4).Value = list[i].Code;
                worksheet.Cell(i + 2, 5).Value = list[i].Worker?.FullName;
                worksheet.Cell(i + 2, 6).SetValue(s);
                worksheet.Cell(i + 2, 7).Value = string.Empty;
            }

            worksheet.Range(1, 1, 1, 7).Style.Font.Bold = true;
            worksheet.Range(1, 1, 1, 7).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            worksheet.Range(1, 1, i + 2, 5).DataType = XLCellValues.Text;
            worksheet.Range(1, 1, i + 1, 7).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
            worksheet.Range(1, 1, i + 1, 7).Style.Border.InsideBorder = XLBorderStyleValues.Thin;


            worksheet.Columns().AdjustToContents();

            var saveFileDialog = new SaveFileDialog
            {
                Filter = "Excel files|*.xlsx",
                Title = "Сохранить как...",
                FileName = string.Format(m[_date.Month - 1] + " " + _date.Year + "г.")
            };

            try
            {
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    if (!string.IsNullOrWhiteSpace(saveFileDialog.FileName))
                        workbook.SaveAs(saveFileDialog.FileName);
                    MessageBox.Show("Сохранение произведено успешно.", "Сообщение", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + Environment.NewLine + ex.InnerException + Environment.NewLine +
                                ex.StackTrace);
            }

        }

        private void btnChecked_Click(object sender, EventArgs e)
        {
            if (grid.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите запись!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Guid id = Guid.Parse(grid.SelectedRows[0].Cells["colId"].Value.ToString());

            using (var context = new Context())
            {
                var item = context.Items.First(x => x.Id == id);
                
                string s = string.Format(m[item.CheckDate.Month - 1] + " " + DateTime.Now.AddYears(1).Year + " г");

                string mes = string.Format(
                    $"Иструмент проверен, новая дата проверки {s}.\nЕсли вы нажмете \"Да\", эта дата будет применена к записи в БД." +
                    $"\nДля указания даты следующей проверки вручную нажмите \"Нет\"\n\nПрименить дату {s}?");

                DialogResult d = MessageBox.Show(mes, "Предупреждение", MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Question);
                switch (d)
                {
                    case DialogResult.Yes:
                        item.CheckDate = DateTime.Now.AddYears(1);
                        
                        try
                        {
                            var history = new History(History.Action.Checked);
                            context.Histories.Add(history);
                            history.Item = item;
                            context.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message + Environment.NewLine + ex.InnerException + Environment.NewLine +
                                            ex.StackTrace);
                        }
                        RefreshGrid();
                        break;

                    case DialogResult.No:
                        var frm = new frmGetDate(true);
                        frm.ShowDialog();
                        item.CheckDate = frm.Date;
                        try
                        {
                            var history = new History(History.Action.Checked);
                            history.Item = item;
                            context.Histories.Add(history);
                            context.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message + Environment.NewLine + ex.InnerException + Environment.NewLine +
                                            ex.StackTrace);
                        }
                        RefreshGrid();
                    break;
                }
            }
        }

        private void btnDefected_Click(object sender, EventArgs e)
        {
            if (grid.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите запись!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Guid id = Guid.Parse(grid.SelectedRows[0].Cells["colId"].Value.ToString());

            DialogResult d = MessageBox.Show("Инструмент забракован? Исключить инструмент из списка отображения?", 
                "Дефект", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (d == DialogResult.OK)
            {
                using (var context = new Context())
                {
                    var item = context.Items.First(x => x.Id == id);
                    item.Condition = Condition.Defected;
                    try
                    {
                        var history = new History(History.Action.Defected);
                        history.Item = item;
                        context.Histories.Add(history);
                        context.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message + Environment.NewLine + ex.InnerException + Environment.NewLine +
                                        ex.StackTrace);
                    }
                    RefreshGrid();
                }
            }
        }
    }
}
