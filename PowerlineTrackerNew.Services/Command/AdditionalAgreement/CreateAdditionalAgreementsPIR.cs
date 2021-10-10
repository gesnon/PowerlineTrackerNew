using PowerlineTrackerNew.Services.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using TrackerDB;
using TrackerDB.Models;

namespace PowerlineTrackerNew.Services.Command.AdditionalAgreement
{
    public class CreateAdditionalAgreementsPIR
    {
        public void Create(AdditionalAgreementPIRDTO newAdditionalAgreementPIR, ContextDB DB)
        {
            AdditionalAgreementPIR additionalAgreement = new AdditionalAgreementPIR ();

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
            DB.AdditionalAgreementPIRs.Add(additionalAgreement);
        }
    }
}
