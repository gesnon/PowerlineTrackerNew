using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PowerlineTrackerNew.Services.Models
{
    public class ContractSMR
    {
        [Display(Name = "Номер договора СМР")]
        public int Number { get; set; }

        [Display(Name = "Дата заключения договора СМР")]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}")]
        public DateTime DateOfSigned { get; set; }
        
        [Display(Name = "Дата окончания 1 этапа СМР")]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}")]
        public DateTime? DateOfCompleteFirstStage { get; set; }

        [Display(Name = "Дата окончания 2 этапа СМР")]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}")]
        public DateTime? DateOfCompleteSecondtStage { get; set; }

        [Display(Name = "Сумма договора СМР")]
        public decimal ContractSum { get; set; }
        
        public int ID { get; set; }
               
    }
}