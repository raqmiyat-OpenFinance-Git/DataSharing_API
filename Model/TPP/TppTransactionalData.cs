namespace DataSharing_API.Model.TPP
{
    public class TppTransactionalData
    {

        public long RequestId { get; set; }
        public Guid? CorrelationId { get; set; }
        public string? Authorization { get; set; }
        public string? AuthDate { get; set; }
        public string? ipAddress { get; set; }
        public string? InteractionId { get; set; }
        public string? CustomerUseragent { get; set; }
        public string? AccountId { get; set; }
        public string? ConsentId { get; set; }
        public string? LFIName { get; set; }
        public string? LFIId { get; set; }
        public string? FromBookingDateTime { get; set; }
        public string? ToBookingDateTime { get; set; }

        public string? Status { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }

        public string? RequestPayload { get; set; }
        public string? CurrentStatus { get; set; }

        public long ResponseId { get; set; }


        public string? ResponseAccountId { get; set; }
        public string? TransactionCode { get; set; }
        public string? TransactionDateTime { get; set; }
        public string? LocalTimeZone { get; set; }
        public string? TransactionReference { get; set; }
        public string? TransactionType { get; set; }
        public string? SubTransactionType { get; set; }
        public string? TerminalId { get; set; }
        public string? PaymentModes { get; set; }
        public string? CreditDebitIndicator { get; set; }
        public string? TransactionalStatus { get; set; }
        public string? TransactionMutability { get; set; }
        public string? BookingDateTime { get; set; }
        public string? ValueDateTime { get; set; }
        public string? TransactionInformation { get; set; }
        public string? PaymentPurposeCode { get; set; }
        public bool? IsPrimaryInstrument { get; set; }

        public decimal? Amount { get; set; }
        public string? Currency { get; set; }

        public string? Charge_Amount { get; set; }
        public string? Charge_Currency { get; set; }
        public bool? Charge_Included { get; set; }

        public string? ChargeAmountVat_Amount { get; set; }
        public string? ChargeAmountVat_Currency { get; set; }

        public string? CurrencyExchange_SourceCurrency { get; set; }
        public string? CurrencyExchange_TargetCurrency { get; set; }
        public string? CurrencyExchange_UnitCurrency { get; set; }
        public string? CurrencyExchange_ExchangeRate { get; set; }
        public string? CurrencyExchange_ContractIdentification { get; set; }
        public string? CurrencyExchange_QuotationDate { get; set; }
        public string? CurrencyExchange_InstructedAmount { get; set; }
        public string? CurrencyExchange_InstructedCurrency { get; set; }

        public string? BankTransactionCode_Domain { get; set; }
        public string? BankTransactionCode_DomainCode { get; set; }
        public string? BankTransactionCode_Family { get; set; }
        public string? BankTransactionCode_FamilyCode { get; set; }
        public string? BankTransactionCode_SubFamily { get; set; }
        public string? BankTransactionCode_SubFamilyCode { get; set; }

        public string? ProprietaryBankTransactionCode_Code { get; set; }
        public string? ProprietaryBankTransactionCode_Issuer { get; set; }

        public string? TransactionBalance_CreditDebitIndicator { get; set; }
        public string? TransactionBalance_BalanceType { get; set; }
        public string? TransactionBalance_Amount { get; set; }
        public string? TransactionBalance_Currency { get; set; }

        public string? MerchantDetails_MerchantId { get; set; }
        public string? MerchantDetails_MerchantName { get; set; }
        public string? MerchantDetails_MerchantCategoryCode { get; set; }

        public string? CreditorAgent_AgentType { get; set; }
        public string? CreditorAgent_SchemeName { get; set; }
        public string? CreditorAgent_Identification { get; set; }
        public string? CreditorAgent_Name { get; set; }

        public string? CreditorAgent_PostalAddress_AddressType { get; set; }
        public string? CreditorAgent_PostalAddress_AddressLine { get; set; }
        public string? CreditorAgent_PostalAddress_BuildingNumber { get; set; }
        public string? CreditorAgent_PostalAddress_BuildingName { get; set; }
        public string? CreditorAgent_PostalAddress_Floor { get; set; }
        public string? CreditorAgent_PostalAddress_StreetName { get; set; }
        public string? CreditorAgent_PostalAddress_DistrictName { get; set; }
        public string? CreditorAgent_PostalAddress_PostBox { get; set; }
        public string? CreditorAgent_PostalAddress_TownName { get; set; }
        public string? CreditorAgent_PostalAddress_CountrySubDivision { get; set; }
        public string? CreditorAgent_PostalAddress_Country { get; set; }

        public string? CreditorAccount_SchemeName { get; set; }
        public string? CreditorAccount_Identification { get; set; }
        public string? CreditorAccount_Name { get; set; }

        public string? DebtorAgent_AgentType { get; set; }
        public string? DebtorAgent_SchemeName { get; set; }
        public string? DebtorAgent_Identification { get; set; }
        public string? DebtorAgent_Name { get; set; }

        public string? DebtorAgent_PostalAddress_AddressType { get; set; }
        public string? DebtorAgent_PostalAddress_AddressLine { get; set; }
        public string? DebtorAgent_PostalAddress_BuildingNumber { get; set; }
        public string? DebtorAgent_PostalAddress_BuildingName { get; set; }
        public string? DebtorAgent_PostalAddress_Floor { get; set; }
        public string? DebtorAgent_PostalAddress_StreetName { get; set; }
        public string? DebtorAgent_PostalAddress_DistrictName { get; set; }
        public string? DebtorAgent_PostalAddress_PostBox { get; set; }
        public string? DebtorAgent_PostalAddress_TownName { get; set; }
        public string? DebtorAgent_PostalAddress_CountrySubDivision { get; set; }
        public string? DebtorAgent_PostalAddress_Country { get; set; }

        public string? DebtorAccount_SchemeName { get; set; }
        public string? DebtorAccount_Identification { get; set; }
        public string? DebtorAccount_Name { get; set; }

        public string? CardInstrument_CardSchemeName { get; set; }
        public string? CardInstrument_InstrumentType { get; set; }
        public string? CardInstrument_Name { get; set; }
        public string? CardInstrument_Identification { get; set; }

        public string? GeoLocation_Latitude { get; set; }
        public string? GeoLocation_Longitude { get; set; }

        public string? BillDetails_BillerID { get; set; }
        public string? BillDetails_BillNumber { get; set; }
        public string? BillDetails_BillPaymentType { get; set; }

        public string? StatementReference { get; set; }
        public string? Flags { get; set; }

        public bool? TransactionMeta_Paginated { get; set; }
        public int? TransactionMeta_TotalPages { get; set; }
        public int? TransactionMeta_TotalRecords { get; set; }

        public string? ResponseStatus { get; set; }
        public string? ResponseCreatedBy { get; set; }
        public DateTime? ResponseCreatedOn { get; set; }
        public string? ResponseModifiedBy { get; set; }
        public DateTime? ResponseModifiedOn { get; set; }

        public string? LinksSelf { get; set; }
        public string? LinksFirst { get; set; }
        public string? LinksPrev { get; set; }
        public string? LinksNext { get; set; }
        public string? LinksLast { get; set; }
        public string? ResponsePayload { get; set; }
        public string? TransactionalResponseStatus { get; set; }




    }
}
