using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Windows.Forms;
using DocumentFormat.OpenXml.Wordprocessing;
using ToolsPrjWinForm.Entities;

namespace ToolsPrjWinForm.Entities
{
    public enum Condition
    {
        Free,
        Given,
        Lost,
        Defected
    }

    public class Item : _BaseEntity
    {

        public Group Group { get; set; }
        public string Name { get; set; }
        public string IdNum { get; set; }   //Идентификационный номер (И3 и тд)
        public string Code { get; set; }    // Шифр (22М-....)
        public DateTime CheckDate { get; set; } // Дата проверки
        public DateTime? GiveDate { get; set; } // Дата выдачи
        public Condition Condition { get; set; } // Выдано или нет
        public Worker Worker { get; set; }

        public Item()
        {
            Condition = Condition.Free;
        }

        //Это для сравнения в методах редактирования записи
        //Там создается новый объект, идентичный исходному, и над ним осуществляются манипуляции
        public Item (Item item)
        {
            Condition = item.Condition;
            Group = item.Group;
            Name = item.Name;
            IdNum = item.IdNum;
            Code = item.Code;
            CheckDate = item.CheckDate;
            GiveDate = item.GiveDate;
        }

        [NotMapped]
        public string FullName
        {
            get
            {
                var s = string.Format(CheckDate == new DateTimePicker().MinDate
                    ? "рез"
                    : CheckDate.Month + "-" + CheckDate.Year + "г.");
                return string.Format($"{Name}  {IdNum}  {Code} ({s})");
            }
        }

        [NotMapped]
        public string GroupName
        {
            get { return Group.Name; }
        }

        public override string ToString()
        {
            return string.Format($"{Name} | ID: {IdNum} | Шифр: {Code}");
        }

    }
}
