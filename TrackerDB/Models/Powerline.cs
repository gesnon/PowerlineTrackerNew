using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TrackerDB.Models
{
    public class Powerline
    {
        [Display(Name = "Наименование объекта")]
        public string Name { get; set; }

        [Display(Name = "Договор ПИР")]
        public ContractPIR ContractPIR { get; set; }

        [Display(Name = "Договор СМР")]
        public ContractSMR ConractSMR { get; set; }

        [Display(Name = "Служебные записки")]
        public List<InternalNote> InternalNotes { get; set; }

        [Display(Name = "Комментарии")]
        public string Comments { get; set; }

        public int ID { get; set; }
    }
}