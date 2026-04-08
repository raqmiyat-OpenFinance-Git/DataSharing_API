namespace DataSharing_API.Model.LFI
{
    public class StoredProcedureParams
    {
        public DataSharingSPParams? dataSharingSPParams { get; set; }
    }
    public class DataSharingSPParams
    {
        /* BalanceData */

        public string? RetrieveBalanceData { get; set; }
        public string? RetrieveBalanceDataByRefId { get; set; }
        public string? RetrieveBalanceDataSearchByRefId { get; set; }

        /* customerDate */
        public string? RetrieveCustomerData { get; set; }
        public string? RetrieveCustomerDataByRefId { get; set; }
        public string? RetrieveCustomerDataSearchByRefId { get; set; }

        //Account Data
        public string? RetrieveAccountData { get; set; }
        public string? RetrieveAccountDataByRefId { get; set; }
        public string? RetrieveAccountDataSearchByRefId { get; set; }


        //Beneficiaries Data

        public string? RetrieveBeneficiariesData { get; set; }
        public string? RetrieveBeneficiariesDataByRefId { get; set; }
        public string? RetrieveBeneficiariesDataSearchByRefId { get; set; }


        //DirectDebit Data

        public string? RetrieveDirectDebitData { get; set; }
        public string? RetrieveDirectDebitDataByRefId { get; set; }
        public string? RetrieveDirectDebitDataSearchByRefId { get; set; }

        //Product Data

        public string? RetrieveProductData { get; set; }
        public string? RetrieveProductDataByRefId { get; set; }
        public string? RetrieveProductDataSearchByRefId { get; set; }


        //LFI SchedPayment Data

        public string? RetrievePaymentData { get; set; }
        public string? RetrievePaymentDataByRefId { get; set; }
        public string? RetrievePaymentDataSearchByRefId { get; set; }

        //LFI StandingOrder Data

        public string? RetrieveStandingOrderData { get; set; }
        public string? RetrieveStandingOrderDataByRefId { get; set; }
        public string? RetrieveStandingOrderDataSearchByRefId { get; set; }


        //LFI Statement Data

        public string? RetrieveStatementData { get; set; }
        public string? RetrieveStatementDataByRefId { get; set; }
        public string? RetrieveStatementDataSearchByRefId { get; set; }


        //Create Balance Data
        public string? PostBalanceDataList { get; set; }
        public string? PostBalanceIndividualData { get; set; }
        public string? GetConsent_Status { get; set; }
        public string? InsertBalanceDataDetails { get; set; }

        //TppBalance Enquiry Screen
        public string? GetAllTppBalancesAsync { get; set; }
        public string? GetTppBalancesByDateAsync { get; set; }
        public string? GetTppBalancesByIdAsync { get; set; }

        //TppAccounts Enquiry Screen
        public string? GetAllTppAccountsAsync { get; set; }
        public string? GetTppAccountsByDateAsync { get; set; }
        public string? GetTppAccountsByIdAsync { get; set; }

        //TppCustomers Enquiry Screen
        public string? GetAllTppCustomerAsync { get; set; }
        public string? GetTppCustomerByDateAsync { get; set; }
        public string? GetTppCustomerByIdAsync { get; set; }

        /* CoPQuery Data */
        public string? RetrieveCoPQueryData { get; set; }
        public string? RetrieveCoPQueryDataByRefId { get; set; }
        public string? RetrieveCoPQueryDataSearchByRefId { get; set; }


        /* LFI Current Account */
        public string? RetrieveLfiCurrentAccountDetail { get; set; }
        public string? RetrieveLfiCurrentAccountDetailByRefId { get; set; }
        public string? RetrieveLfiCurrentAccountSearch { get; set; }

        /* LFI Savings Account */
        public string? RetrieveLfiSavingsAccountDetail { get; set; }
        public string? RetrieveLfiSavingsAccountDetailByRefId { get; set; }
        public string? RetrieveLfiSavingsAccountSearch { get; set; }

        /* LFI Credit Card */
        public string? RetrieveLfiCreditCardDetail { get; set; }
        public string? RetrieveLfiCreditCardDetailByRefId { get; set; }
        public string? RetrieveLfiCreditCardSearch { get; set; }

        /* LFI Personal Loan */
        public string? RetrieveLfiPersonalLoanDetail { get; set; }
        public string? RetrieveLfiPersonalLoanDetailByRefId { get; set; }
        public string? RetrieveLfiPersonalLoanSearch { get; set; }

        /* LFI Mortgage */
        public string? RetrieveLfiMortgageDetail { get; set; }
        public string? RetrieveLfiMortgageDetailByRefId { get; set; }
        public string? RetrieveLfiMortgageSearch { get; set; }

        public string? RetrieveLfiProductQuoteMaster { get; set; }

        /* TPP Current Account */
        public string? RetrieveTppCurrentAccountDetail { get; set; }
        public string? RetrieveTppCurrentAccountDetailByRefId { get; set; }
        public string? RetrieveTppCurrentAccountSearch { get; set; }

        /* TPP Savings Account */
        public string? RetrieveTppSavingsAccountDetail { get; set; }
        public string? RetrieveTppSavingsAccountDetailByRefId { get; set; }
        public string? RetrieveTppSavingsAccountSearch { get; set; }

        /* TPP Credit Card */
        public string? RetrieveTppCreditCardDetail { get; set; }
        public string? RetrieveTppCreditCardDetailByRefId { get; set; }
        public string? RetrieveTppCreditCardSearch { get; set; }

        /* TPP Personal Loan */
        public string? RetrieveTppPersonalLoanDetail { get; set; }
        public string? RetrieveTppPersonalLoanDetailByRefId { get; set; }
        public string? RetrieveTppPersonalLoanSearch { get; set; }

        /* TPP Mortgage */
        public string? RetrieveTppMortgageDetail { get; set; }
        public string? RetrieveTppMortgageDetailByRefId { get; set; }
        public string? RetrieveTppMortgageSearch { get; set; }

        public string? RetrieveTppProductQuoteMaster { get; set; }

        /*  CreateLead  */

        public string? RetrieveCreateLead { get; set; }
        public string? RetrieveCreateLeadByRefId { get; set; }
        public string? RetrieveCreateLeadSearchByRefId { get; set; }

        /*  Create TPP Lead  */

        public string? RetrieveTppCreateLead { get; set; }
        public string? RetrieveTppCreateLeadByRefId { get; set; }
        public string? RetrieveTppCreateLeadSearchByRefId { get; set; }

        //LFI Transcational Data
        public string? RetrieveLfiTransactionalData { get; set; }
        public string? RetrieveLfiTransactionalDataByRefId { get; set; }
        public string? RetrieveLfiTransactionalDataSearch { get; set; }

    }
}
