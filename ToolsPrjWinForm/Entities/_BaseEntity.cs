using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolsPrjWinForm.Entities
{
    public class _BaseEntity
    {
        public Guid Id { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifyDate { get; set; }
        public DateTime? DeleteDate { get; set; }

        internal _BaseEntity ()
        {
            Id = Guid.NewGuid();
            CreateDate = DateTime.Now;
            ModifyDate = CreateDate;
        }
    }
}
