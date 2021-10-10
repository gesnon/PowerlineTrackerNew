using PowerlineTrackerNew.Services.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using TrackerDB;
using TrackerDB.Models;

namespace PowerlineTrackerNew.Services.Command.AdditionalAgreement
{
    public class CreateAdditionalAgreementsSMR
    {
        public void Create(AdditionalAgreementSMRDTO newAdditionalAgreementSMR, ContextDB DB)
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
            DB.AdditionalAgreementSMRs.Add(additionalAgreement);
        }
    }
}