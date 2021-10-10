using PowerlineTrackerNew.Services.DTO;
using TrackerDB;
using System.Linq;
using TrackerDB.Models;

namespace PowerlineTrackerNew.Services.Command.AdditionalAgreement
{
    public class UpdateAdditionalAgreementsPIR
    {
        public void Update(AdditionalAgreementPIRDTO newAdditionalAgreementPIR, ContextDB DB, int ID)
        {
            AdditionalAgreementPIR OldadditionalAgreement = DB.AdditionalAgreementPIRs.FirstOrDefault(a => a.ID == ID);

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
    }
}
