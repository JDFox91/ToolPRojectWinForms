using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ToolsPrjWinForm.Entities;
using ToolsPrjWinForm.Contexts;

namespace ToolsPrjWinForm.Entities
{
    class History : _BaseEntity
    {
        public DateTime? ActDate { get; set; }
        public Item Item { get; set; }
        public string Worker { get; set; }
        public string Description { get; set; }

        public enum Action
        {
            Give,
            Return,
            Lost,
            Defected,
            Checked
        }

        public History() { }

        public History(Action act)
        {
            ActDate = DateTime.Now;
            switch (act)
            {
                case Action.Give:
                    Description = "Выдан";
                    break;
                case Action.Return:
                    Description = "Возвращен";
                    break;
                case Action.Lost:
                    Description = "Утерян";
                    break;
                case Action.Defected:
                    Description = "Забракован";
                    break;
                case Action.Checked:
                    Description = "Проверен";
                    break;
            }

        }
        
    }
}
