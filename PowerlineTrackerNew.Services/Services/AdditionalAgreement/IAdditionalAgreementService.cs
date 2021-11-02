using PowerlineTrackerNew.Services.DTO;
using System.Collections.Generic;
using TrackerDB.Models;

namespace PowerlineTrackerNew.Services
{
    public interface IAdditionalAgreementService
    {
        void CreateAdditionalAgreementPIR(AdditionalAgreementPIRDTO newAdditionalAgreementPIR);
        void CreateAdditionalAgreementSMR(AdditionalAgreementSMRDTO newAdditionalAgreementSMR);
        List<AdditionalAgreementPIR> GetAdditionalAgreementsPIR(int ContractID);
        List<AdditionalAgreementSMR> GetAdditionalAgreementsSMR(int ContractID);
        void UpdateAdditionalAgreementPIR(AdditionalAgreementPIRDTO newAdditionalAgreementPIR, int ID);
        void UpdateAdditionalAgreementSMR(AdditionalAgreementSMRDTO newAdditionalAgreementSMR, int ID);
    }
}