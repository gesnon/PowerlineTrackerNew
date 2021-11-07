using Microsoft.EntityFrameworkCore;
using PowerlineTrackerNew.Services.DTO;
using PowerlineTrackerNew.Services.Queries.Powerline.ENUMS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrackerDB;
using TrackerDB.Models.ENUMS;

namespace PowerlineTrackerNew.Services.Queries.Powerline
{
    public class GetFiltredContracts
    {
        public ContractsDTO GetContractsDTO(ContextDB DB, Status status, ContractType contractType, DateTime? startDate=null, DateTime? endDate=null)
        {
            ContractsDTO newContracts = new ContractsDTO();

            List<ContractPIRDTO> contractPIRDTOs = new List<ContractPIRDTO>();

            var queryPIR = DB.ContractPIRs.AsQueryable();

            var querySMR = DB.ContractSMRs.AsQueryable();

            if (contractType == ContractType.PIR)
            {
                if (status == Status.Closed)
                {
                    queryPIR = queryPIR.Where(_ => _.Status == Status.Closed);
                }
                if (status == Status.Open)
                {
                    queryPIR = queryPIR.Where(_ => _.Status == Status.Open);
                }
                if (startDate != null)
                {
                    queryPIR = queryPIR.Where(_ => _.DateOfComplete >= startDate );
                }
                if (endDate != null)
                {
                    queryPIR = queryPIR.Where(_ => _.DateOfComplete <= endDate);
                }
            }

            if (contractType == ContractType.SMR)
            {               
                if (status == Status.Closed)
                {
                    querySMR = querySMR.Where(_ => _.Status == Status.ClosedSecondStage);
                }
                if (status == Status.Open)
                {
                    querySMR = querySMR.Where(_ => _.Status == Status.Open);
                }


                newContracts.ContractsSMRDTO = querySMR.Select(_ => new ContractSMRDTO
                {
                    Number = _.Number,
                    ContractSum = _.ContractSum,
                    Status = _.Status,
                    DateOfSigned = _.DateOfSigned.ToString(),
                    DateOfCompleteFirstStage = _.DateOfCompleteFirstStage.ToString(),
                    DateOfCompleteSecondtStage = _.DateOfCompleteSecondtStage.ToString()

                }
                    ).ToList();
            }

            return newContracts;

        }
    }
}
