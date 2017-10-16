using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolsPrjWinForm.Entities;

namespace ToolsPrjWinForm.Entities
{
    public class Group : _BaseEntity
    {
        public string Name { get; set; }
        public IList<Item> Items { get; set; }

        [NotMapped]
        public string GroupName => ToString();

        public override string ToString()
        {
            return Name;
        }
    }
}
