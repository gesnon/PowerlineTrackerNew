using PowerlineTrackerNew.Services.DTO;
using TrackerDB;
using System.Linq;
using TrackerDB.Models;

namespace PowerlineTrackerNew.Services.Command.AdditionalAgreement
{
    public class UpdateAdditionalAgreementsSMR
    {
        public void Update(AdditionalAgreementSMRDTO newAdditionalAgreementSMR, ContextDB DB, int ID)
        {
            AdditionalAgreementSMR OldadditionalAgreement = DB.AdditionalAgreementSMRs.FirstOrDefault(a => a.ID == ID);

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
