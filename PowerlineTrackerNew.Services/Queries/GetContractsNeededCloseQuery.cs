using PowerlineTrackerNew.Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrackerDB;

namespace PowerlineTrackerNew.Services.Queries
{
    public class GetContractsNeededCloseQuery
    {
        public List<ContractsEnd> Execute(ContextDB DB, DateTime date)
        {
            List<ContractsEnd> ContractsPIR =  DB.ContractPIRs.Where(_=>_.DateOfComplete < date && _.Status!=TrackerDB.Models.ENUMS.Status.Closed)
                .Select(_=>new ContractsEnd {
                    Number=_.Number,
                    DateOfSigned=_.DateOfSigned,
                    Type="PIR",
                    DateOfComplete=_.DateOfComplete }).ToList();

            List<ContractsEnd> ContractsSMRFirstStage = DB.ContractSMRs.Where(_ => _.DateOfCompleteFirstStage < date && _.Status == TrackerDB.Models.ENUMS.Status.Open)
                .Select(_ => new ContractsEnd
                {
                    Number = _.Number,
                    DateOfSigned = _.DateOfSigned,
                    Type = "FirstStageSMR",
                    DateOfComplete = _.DateOfCompleteFirstStage.Value
                }).ToList();

            List<ContractsEnd> ContractsSMRSecondStage = DB.ContractSMRs.Where(_ => _.DateOfCompleteSecondtStage.HasValue && _.DateOfCompleteSecondtStage < date && _.Status != TrackerDB.Models.ENUMS.Status.ClosedSecondStage)
                .Select(_ => new ContractsEnd
                {
                    Number = _.Number,
                    DateOfSigned = _.DateOfSigned,
                    Type = "SecondStageSMR",
                    DateOfComplete = _.DateOfCompleteSecondtStage.Value
                }).ToList();

            ContractsPIR.AddRange(ContractsSMRFirstStage);

            ContractsPIR.AddRange(ContractsSMRSecondStage);

            return ContractsPIR;
        }
    }
}
