using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TrackerDB.Models
{
    public class ContractPIR
    {
        [Display(Name = "Номер договора ПИР")]
        public int Number { get; set; }

        [Display(Name = "Дата заключения договора ПИР")]
        [DisplayFormat(DataFormatString ="{0:dd.MM.yyyy}")]
        public DateTime DateOfSigned { get; set; }

        [Display(Name = "Дата окончания ПИР")]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}")]
        public DateTime DateOfComplete { get; set; }

        [Display(Name = "Сумма договора ПИР")]
        public decimal ContractSum { get; set; }

        public int ID { get; set; }
    }
}