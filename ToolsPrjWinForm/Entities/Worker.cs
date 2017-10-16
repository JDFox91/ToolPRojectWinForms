using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolsPrjWinForm.Entities;

namespace ToolsPrjWinForm.Entities
{
    public class Worker : _BaseEntity
    {
        public string WorkerName { get; set; }
        public int PersonalNumber { get; set; }

        public Worker() { }
        
        public Worker(Worker worker)
        {
            Id = worker.Id;
            CreateDate = worker.CreateDate;
            DeleteDate = worker.DeleteDate;
            ModifyDate = worker.ModifyDate;

            WorkerName = worker.WorkerName;
            PersonalNumber = worker.PersonalNumber;
        }


        
        [NotMapped]
        public string FullName
        {
            get
            {
                return string.Format($"{WorkerName} | Таб № {PersonalNumber}");
            }
        }

    }
}
