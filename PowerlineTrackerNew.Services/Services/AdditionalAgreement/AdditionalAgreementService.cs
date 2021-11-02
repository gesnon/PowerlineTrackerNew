using PowerlineTrackerNew.Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrackerDB;
using TrackerDB.Models;

namespace PowerlineTrackerNew.Services
{
    public class AdditionalAgreementService : IAdditionalAgreementService
    {
        private readonly ContextDB context;

        public AdditionalAgreementService(ContextDB context)
        {
            this.context = context;
        }

        public List<AdditionalAgreementPIR> GetAdditionalAgreementsPIR(int ContractID)
        {
            return this.context.ContractPIRs.FirstOrDefault(c => c.ID == ContractID).AdditionalAgreements.ToList();
        }

        public List<AdditionalAgreementSMR> GetAdditionalAgreementsSMR(int ContractID)
        {
            return this.context.ContractSMRs.FirstOrDefault(c => c.ID == ContractID).AdditionalAgreements.ToList();
        }

        public void CreateAdditionalAgreementPIR(AdditionalAgreementPIRDTO newAdditionalAgreementPIR)
        {
            AdditionalAgreementPIR additionalAgreement = new AdditionalAgreementPIR();

            if (newAdditionalAgreementPIR.NewSumm != 0)
            {
                additionalAgreement.NewSumm = newAdditionalAgreementPIR.NewSumm;
            }
            if (newAdditionalAgreementPIR.NewCloseDate != null)
            {
                additionalAgreement.NewCloseDate = newAdditionalAgreementPIR.NewCloseDate;
            }
            additionalAgreement.DateOfSigned = newAdditionalAgreementPIR.DateOfSigned;
            additionalAgreement.ContractID = newAdditionalAgreementPIR.ContractID;
            additionalAgreement.ID = newAdditionalAgreementPIR.ID;
            additionalAgreement.Number = newAdditionalAgreementPIR.Number;
            this.context.AdditionalAgreementPIRs.Add(additionalAgreement);
        }

        public void CreateAdditionalAgreementSMR(AdditionalAgreementSMRDTO newAdditionalAgreementSMR)
        {
            AdditionalAgreementSMR additionalAgreement = new AdditionalAgreementSMR();

            if (newAdditionalAgreementSMR.NewSumm != 0)
            {
                additionalAgreement.NewSumm = newAdditionalAgreementSMR.NewSumm;
            }
            if (newAdditionalAgreementSMR.NewCloseFirstStage != null)
            {
                additionalAgreement.NewCloseFirstStage = newAdditionalAgreementSMR.NewCloseFirstStage;
            }
            if (newAdditionalAgreementSMR.NewCloseSecondtStage != null)
            {
                additionalAgreement.NewCloseSecondtStage = newAdditionalAgreementSMR.NewCloseSecondtStage;
            }
            additionalAgreement.DateOfSigned = newAdditionalAgreementSMR.DateOfSigned;
            additionalAgreement.ContractID = newAdditionalAgreementSMR.ContractID;
            additionalAgreement.ID = newAdditionalAgreementSMR.ID;
            additionalAgreement.Number = newAdditionalAgreementSMR.Number;
            this.context.AdditionalAgreementSMRs.Add(additionalAgreement);
        }

        public void UpdateAdditionalAgreementPIR(AdditionalAgreementPIRDTO newAdditionalAgreementPIR, int ID)
        {
            AdditionalAgreementPIR OldadditionalAgreement = this.context.AdditionalAgreementPIRs.FirstOrDefault(a => a.ID == ID);

            if (newAdditionalAgreementPIR.Number != 0)
            {
                OldadditionalAgreement.Number = newAdditionalAgreementPIR.Number;
            }
            if (newAdditionalAgreementPIR.DateOfSigned != null)
            {
                OldadditionalAgreement.DateOfSigned = newAdditionalAgreementPIR.DateOfSigned;
            }
            if (newAdditionalAgreementPIR.ContractID != 0)
            {
                OldadditionalAgreement.ContractID = newAdditionalAgreementPIR.ContractID;
            }
            if (newAdditionalAgreementPIR.NewCloseDate != null)
            {
                OldadditionalAgreement.NewCloseDate = newAdditionalAgreementPIR.NewCloseDate;
            }
            if (newAdditionalAgreementPIR.NewSumm != 0)
            {
                OldadditionalAgreement.NewSumm = newAdditionalAgreementPIR.NewSumm;
            }
        }

        public void UpdateAdditionalAgreementSMR(AdditionalAgreementSMRDTO newAdditionalAgreementSMR, int ID)
        {
            AdditionalAgreementSMR OldadditionalAgreement = this.context.AdditionalAgreementSMRs.FirstOrDefault(a => a.ID == ID);

            if (newAdditionalAgreementSMR.Number != 0)
            {
                OldadditionalAgreement.Number = newAdditionalAgreementSMR.Number;
            }
            if (newAdditionalAgreementSMR.DateOfSigned != null)
            {
                OldadditionalAgreement.DateOfSigned = newAdditionalAgreementSMR.DateOfSigned;
            }
            if (newAdditionalAgreementSMR.ContractID != 0)
            {
                OldadditionalAgreement.ContractID = newAdditionalAgreementSMR.ContractID;
            }
            if (newAdditionalAgreementSMR.NewCloseFirstStage != null)
            {
                OldadditionalAgreement.NewCloseFirstStage = newAdditionalAgreementSMR.NewCloseFirstStage;
            }
            if (newAdditionalAgreementSMR.NewCloseSecondtStage != null)
            {
                OldadditionalAgreement.NewCloseSecondtStage = newAdditionalAgreementSMR.NewCloseSecondtStage;
            }
            if (newAdditionalAgreementSMR.NewSumm != 0)
            {
                OldadditionalAgreement.NewSumm = newAdditionalAgreementSMR.NewSumm;
            }
            if (newAdditionalAgreementSMR.NewSumm != 0)
            {
                OldadditionalAgreement.NewSumm = newAdditionalAgreementSMR.NewSumm;
            }
        }
    }
}
