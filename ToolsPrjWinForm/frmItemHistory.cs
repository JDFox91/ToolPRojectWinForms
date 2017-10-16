using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ToolsPrjWinForm.Contexts;
using ToolsPrjWinForm.Entities;

namespace ToolsPrjWinForm
{
    public partial class frmItemHistory : Form
    {
        private readonly Item _item;

        public frmItemHistory()
        {
            InitializeComponent();
        }

        public frmItemHistory(Item item)
        {
            InitializeComponent();
            _item = item;
        }

        private void frmItemHistory_Load(object sender, EventArgs e)
        {
            Text = _item.FullName;
            using (var context = new Context())
            {
                grid.DataSource = context.Histories.Include("Item").Where(x => x.Item.Id == _item.Id).Select(x => 
                new
                {
                    x.ActDate,
                    x.Description,
                    x.Worker
                }).OrderByDescending(x => x.ActDate).ToList();
            }
        }
    }
}
