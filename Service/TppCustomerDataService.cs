using Dapper;
using DataSharing_API.IService;
using DataSharing_API.Model;
using DataSharing_API.Models;
using DataSharing_API.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using OF.DataSharing.Model.CentralBank;
using OF.DataSharing.Model.EFModel;
using OF.ServiceInitiation.CoreBankConn.API.EFModel;
using OpenFinance.Models;
using System.Data;
using System.Data.Common;

namespace DataSharing_API.Service
{
    public class TppCustomerDataService : ITppCustomerDataService
    {
        private readonly NLogManagerService _logger;
        private IDbConnection _idbConnection;
        private readonly BalanceDbContext _context;
        private readonly IOptions<StoredProcedureParams> _storedProcedureParams;

        public TppCustomerDataService(NLogManagerService logger, BalanceDbContext postbalanceDbContext, IOptions<StoredProcedureParams> storedProcedureParams, IDbConnection idbConnection)
        {
            _logger = logger;
            _context = postbalanceDbContext;_storedProcedureParams = storedProcedureParams;
            _idbConnection = idbConnection;

        }
        public async Task<List<CustomerDataRequest>> GetTppCustomerList(string User)
        {
            var requestList = new List<CustomerDataRequest>();
            try
            {
                requestList = await GetTppCustomerMakerList(User);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex);
            }
            return requestList;
        }

        public async Task<string> PostCustomerData(CustomerDataRequest customerDataRequest)
        {
            string result = string.Empty;
            var dbContent = new CustomerRequest();
            try
            {
                dbContent = await ConvertRequesttoEfModel(customerDataRequest);
                await _context.CustomerRequest!.AddAsync(dbContent);
                await _context.SaveChangesAsync();
                result = "Success";
            }
            catch (Exception ex)
            {
                _logger.LogError(ex);
                result = "Failed";
            }
            return result;
        }

        public async Task<string> ApproveCustomerData(CentralBankCustomerIdResponse customerDataResponse, Guid CorrelationId)
        {
            string result = string.Empty;
            var dbContent = new CustomerResponse();
            try
            {
                var request = await _context.CustomerRequest!.FirstOrDefaultAsync(x => x.CorrelationId == CorrelationId);
                request!.Status = "Processed";
                _context.CustomerRequest!.Update(request);
                dbContent = MapToCustomerDataRequest(customerDataResponse, CorrelationId, request.AccountId);
                await _context.CustomerResponse!.AddAsync(dbContent);
                await _context.SaveChangesAsync();
                result = "Success";

            }
            catch (Exception ex)
            {
                _logger.LogError(ex);
                result = "Failed";
            }
            return result;
        }

        public async Task<List<CustomerResponse>> FetchCutomerDetailsResponse(Guid correlationId)
        {
            try
            {
                if (correlationId == Guid.Empty)
                {
                    // Fetch all data
                    return await _context.CustomerResponse!.ToListAsync();
                }
                else
                {
                    // Fetch matching record(s)
                    return await _context.CustomerResponse!
                                         .Where(x => x.CorrelationId == correlationId)
                                         .ToListAsync();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching customer details");
                return new List<CustomerResponse>();
            }
        }

        public async Task<CustomerResponse> FetchDetailsReponse(Guid CorrelationId)
        {
            var dbContent = new CustomerResponse();
            try
            {
                dbContent = await _context.CustomerResponse!.FirstOrDefaultAsync(x => x.CorrelationId == CorrelationId);
                

            }
            catch (Exception ex)
            {
                _logger.LogError(ex);
            }
            return dbContent;
        }
        public static CustomerResponse MapToCustomerDataRequest(CentralBankCustomerIdResponse apiResponse, Guid CorrelationId, string AccountId)
        {
            var entity = new CustomerResponse();

            foreach (var item in apiResponse.data)
            {
                entity = new CustomerResponse
                {
                    CorrelationId = CorrelationId,
                    AccountId = AccountId,
                    CustomerNumber = item.number,
                    CustomerCategory = item.customerCategory,
                    CustomerType = item.customerType,
                    AccountRole = item.accountRole,

                    TotalPages = apiResponse.meta?.totalPages,
                    TotalRecords = apiResponse.meta?.totalRecords,
                    Status="Processed",
                    CreatedBy = "DataSharingAPI",
                    CreatedOn = DateTime.UtcNow,

                    ResponsePayload = System.Text.Json.JsonSerializer.Serialize(item)
                };

                // ✅ VerifiedClaims
                var claim = item.verifiedClaims?.FirstOrDefault();
                if (claim != null)
                {
                    // Verification
                    if (claim.verification != null)
                    {
                        entity.VerifiedClaimTrustFramework = claim.verification.trustFramework;
                        entity.VerifiedClaimAssuranceLevel = claim.verification.assuranceLevel;
                        entity.VerifiedClaimVerificationProcess = claim.verification.verificationProcess;
                        entity.VerifiedClaimVerificationTime = claim.verification.time;

                        if (claim.verification.assuranceProcess != null)
                        {
                            entity.AssuranceProcessPolicy = claim.verification.assuranceProcess.policy;
                            entity.AssuranceProcessProcedure = claim.verification.assuranceProcess.procedure;

                            var assuranceDetail = claim.verification.assuranceProcess.assuranceDetails?.FirstOrDefault();
                            if (assuranceDetail != null)
                            {
                                entity.AssuranceType = assuranceDetail.assuranceType;
                                entity.AssuranceClassification = assuranceDetail.assuranceClassification;

                                var evidenceRef = assuranceDetail.evidenceRef?.FirstOrDefault();
                                if (evidenceRef != null)
                                {
                                    entity.EvidenceRefTxn = evidenceRef.txn;
                                    entity.EvidenceClassification = evidenceRef.evidenceMetadata?.evidenceClassification;
                                }
                            }
                        }

                        if (claim.verification.evidence != null)
                        {
                            entity.EvidenceType = claim.verification.evidence.type;
                            entity.EvidenceTime = claim.verification.evidence.time;

                            var check = claim.verification.evidence.checkDetails?.FirstOrDefault();
                            if (check != null)
                            {
                                entity.CheckDetailCheckMethod = check.checkMethod;
                                entity.CheckDetailOrganization = check.organization;
                                entity.CheckDetailTxn = check.txn;
                                entity.CheckDetailTime = check.time;
                            }

                            if (claim.verification.evidence.verifier != null)
                            {
                                entity.VerifierOrganization = claim.verification.evidence.verifier.organization;
                                entity.VerifierTxn = claim.verification.evidence.verifier.txn;
                            }

                            if (claim.verification.evidence.documentDetails != null)
                            {
                                entity.DocumentDetailType = claim.verification.evidence.documentDetails.type;
                                entity.DocumentDetailDocumentNumber = claim.verification.evidence.documentDetails.documentNumber;
                                entity.DocumentDetailPersonalNumber = claim.verification.evidence.documentDetails.personalNumber;
                                entity.DocumentDetailSerialNumber = claim.verification.evidence.documentDetails.serialNumber;
                                entity.DocumentDetailCalendarType = claim.verification.evidence.documentDetails.calendarType;
                                entity.DocumentDetailDateOfIssuance = claim.verification.evidence.documentDetails.dateOfIssuance;
                                entity.DocumentDetailDateOfExpiry = claim.verification.evidence.documentDetails.dateOfExpiry;

                                if (claim.verification.evidence.documentDetails.issuer != null)
                                {
                                    entity.IssuerName = claim.verification.evidence.documentDetails.issuer.name;
                                    entity.IssuerJurisdiction = claim.verification.evidence.documentDetails.issuer.jurisdiction;
                                    entity.IssuerCountryCode = claim.verification.evidence.documentDetails.issuer.countryCode?.Code;

                                    if (claim.verification.evidence.documentDetails.issuer.address != null)
                                    {
                                        var addr = claim.verification.evidence.documentDetails.issuer.address;
                                        entity.IssuerAddressType = addr.addressType;
                                        entity.IssuerAddressLine = string.Join(", ", addr.addressLine ?? new List<string>());
                                        entity.IssuerBuildingNumber = addr.buildingNumber;
                                        entity.IssuerBuildingName = addr.buildingName;
                                        entity.IssuerFloor = addr.floor;
                                        entity.IssuerStreetName = addr.streetName;
                                        entity.IssuerDistrictName = addr.districtName;
                                        entity.IssuerPostBox = addr.postBox;
                                        entity.IssuerTownName = addr.townName;
                                        entity.IssuerCountrySubDivision = addr.countrySubDivision;
                                        entity.IssuerCountry = addr.country;
                                    }
                                }
                            }

                            if (claim.verification.evidence.attachments != null)
                            {
                                var att = claim.verification.evidence.attachments.AEPartyIdentityEvidenceAttachments?.FirstOrDefault();
                                if (att != null)
                                {
                                    entity.AttachmentDescription = att.desc;
                                    entity.AttachmentContentType = att.contentType;
                                    entity.AttachmentContent = att.content;
                                    entity.AttachmentTxn = att.txn;
                                }
                            }
                        }
                    }

                    // Claims
                    if (claim.claims != null)
                    {
                        entity.ClaimIdentityType = claim.claims.identityType;
                        entity.ClaimFullName = claim.claims.fullName;
                        entity.ClaimGivenName = claim.claims.givenName;
                        entity.ClaimFamilyName = claim.claims.familyName;
                        entity.ClaimMiddleName = claim.claims.middleName;
                        entity.ClaimNickname = claim.claims.nickname;
                        entity.ClaimEmiratesId = claim.claims.emiratesId;
                        if (DateTime.TryParse(claim.claims.emiratesIdExpiryDate, out var eidExpiry))
                        {
                            entity.ClaimEmiratesIdExpiryDate = eidExpiry;
                        }
                        entity.ClaimBirthDate=claim.claims.birthDate;
                        entity.ClaimSourceOfIncome = claim.claims.sourceOfIncome;
                        entity.ClaimSalary = claim.claims.salary;
                        entity.ClaimNationality = claim.claims.nationality;
                        entity.ClaimMobileNumber = claim.claims.mobileNumber;
                        entity.ClaimEmail = claim.claims.email;
                        entity.ClaimMaritalStatus = claim.claims.maritalStatus;
                        entity.ClaimSalutation = claim.claims.salutation;
                        entity.ClaimLanguage = claim.claims.language;
                        entity.ClaimEmployerName = claim.claims.employerName;
                        entity.ClaimEmploymentSinceDate = claim.claims.employmentSinceDate;
                        entity.ClaimPowerOfAttorney = claim.claims.powerofAttorney;
                        entity.ClaimSalaryTransfer = claim.claims.salaryTransfer;
                        entity.ClaimProfession = claim.claims.profession;
                        entity.ClaimUpdatedAt = claim.claims.updatedAt;

                        if (claim.claims.residentialAddress != null)
                        {
                            entity.ResidentialAddressType = claim.claims.residentialAddress.addressType;
                            entity.ResidentialAddressLine = string.Join(", ", claim.claims.residentialAddress.addressLine ?? new List<string>());
                            entity.ResidentialBuildingNumber = claim.claims.residentialAddress.buildingNumber;
                            entity.ResidentialBuildingName = claim.claims.residentialAddress.buildingName;
                            entity.ResidentialFloor = claim.claims.residentialAddress.floor;
                            entity.ResidentialStreetName = claim.claims.residentialAddress.streetName;
                            entity.ResidentialDistrictName = claim.claims.residentialAddress.districtName;
                            entity.ResidentialPostBox = claim.claims.residentialAddress.postBox;
                            entity.ResidentialTownName = claim.claims.residentialAddress.townName;
                            entity.ResidentialCountrySubDivision = claim.claims.residentialAddress.countrySubDivision;
                            entity.ResidentialCountry = claim.claims.residentialAddress.country;
                        }
                    }

                    if (claim.organisationClaims != null)
                    {
                        entity.ClaimOrgName = claim.organisationClaims.name;
                    }
                }
            }

            return entity;
        }

        public async Task<CustomerDataRequest> GetTppCustomerDetails(Guid CorrelationId)
        {
            var requestDetails = new CustomerDataRequest();
            try
            {
                requestDetails = await GetTppCustomerMakeDetails(CorrelationId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex);
            }
            return requestDetails;
        }

        private async Task<CustomerRequest> ConvertRequesttoEfModel(CustomerDataRequest customerDataRequest)
        {
            var request = new CustomerRequest();
            try
            {
                request = new CustomerRequest
                {
                    CorrelationId = customerDataRequest.CorrelationId,
                    Page = 1,
                    PageSize = 10,
                    O3ProviderId = customerDataRequest.O3ProviderId,
                    O3AspspId = customerDataRequest.O3AspspId,
                    O3CallerOrgId = customerDataRequest.O3CallerOrgId,
                    O3CallerClientId = customerDataRequest.O3CallerClientId,
                    O3CallerSoftwareStatementId = customerDataRequest.O3CallerSoftwareStatementId,
                    O3ApiUri = customerDataRequest.O3ApiUri,
                    O3ApiOperation = customerDataRequest.O3ApiOperation,
                    O3ConsentId = customerDataRequest.O3ConsentId,
                    O3CallerInteractionId = customerDataRequest.O3CallerInteractionId,
                    O3OzoneInteractionId = customerDataRequest.O3OzoneInteractionId,
                    O3PsuIdentifier = customerDataRequest.O3PsuIdentifier,
                    AccountId = customerDataRequest.AccountId,
                    Status = "Pending",
                    Type = "CustomerDataRequest",
                    CreatedBy = "DatasharingAPI",
                    CreatedOn = DateTime.UtcNow,
                    RequestPayload = JsonConvert.SerializeObject(customerDataRequest)

                };

            }
            catch (Exception ex)
            {
                _logger.LogError(ex);
            }
            return request;
        }
        private async Task<CustomerDataRequest> GetTppCustomerMakeDetails(Guid CorrelationId)
        {
            var request = new CustomerDataRequest();
            try
            {
                var result = await _context.CustomerRequest!.FirstOrDefaultAsync(x => x.CorrelationId == CorrelationId);
                if (result != null)
                {
                    request = new CustomerDataRequest
                    {
                        Id = result.Id,
                        CorrelationId = result.CorrelationId,
                        O3ProviderId = result.O3ProviderId,
                        O3AspspId = result.O3AspspId,
                        O3CallerOrgId = result.O3CallerOrgId,
                        O3CallerClientId = result.O3CallerClientId,
                        O3CallerSoftwareStatementId = result.O3CallerSoftwareStatementId,
                        O3ApiUri = result.O3ApiUri,
                        O3ApiOperation = result.O3ApiOperation,
                        O3ConsentId = result.O3ConsentId,
                        O3CallerInteractionId = result.O3CallerInteractionId,
                        O3OzoneInteractionId = result.O3OzoneInteractionId,
                        O3PsuIdentifier = result.O3PsuIdentifier,
                        AccountId = result.AccountId,
                        Status = result.Status
                    };
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in GetTppCustomerMakeDetails");
                return new CustomerDataRequest();
            }
            return request;
        }

        public async Task<List<TppCustomerDetailDto>> FetchCutomerDetailsResponse()
        {
            _logger.LogInfo("GetAllTppAccountAsync started.");
            List<TppCustomerDetailDto> tppcustomersDetailDtos = new List<TppCustomerDetailDto>();
            try
            {
                var parameters = new DynamicParameters();

                using (var multi = await _idbConnection.QueryMultipleAsync(_storedProcedureParams.Value.dataSharingSPParams!.GetAllTppCustomerAsync!, parameters, commandType: CommandType.StoredProcedure))
                {
                    tppcustomersDetailDtos = multi.Read<TppCustomerDetailDto>().ToList();
                }

            }
            catch (Exception ex)
            {

                _logger.LogError(ex, "Error while fetching GetAllTppAccountAsync");
                return new List<TppCustomerDetailDto>();
            }
            _logger.LogInfo("GetAllTppAccountAsync fetched successfully.");
            return tppcustomersDetailDtos;
        }

        private async Task<List<CustomerDataRequest>> GetTppCustomerMakerList(string User)
        {
            var result = new List<CustomerRequest>();
            var makerList = new List<CustomerDataRequest>();
            try
            {
                if (User.ToUpper() == "MAKER")
                {
                    result = await _context.CustomerRequest!.ToListAsync();
                }
                else
                {
                    result = await _context.CustomerRequest!.Where(x => x.Status.ToUpper() == "PENDING").ToListAsync();
                }

                makerList = await MapDbcontenttoModel(result);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in GetTppCustomerList");
            }
            return makerList;
        }
        private async Task<List<CustomerDataRequest>> MapDbcontenttoModel(List<CustomerRequest> dbContent)
        {
            var result = new List<CustomerDataRequest>();
            try
            {
                foreach (var item in dbContent)
                {
                    var request = new CustomerDataRequest
                    {
                        CorrelationId = item.CorrelationId,
                        O3ProviderId = item.O3ProviderId,
                        O3AspspId = item.O3AspspId,
                        O3CallerOrgId = item.O3CallerOrgId,
                        O3CallerClientId = item.O3CallerClientId,
                        O3CallerSoftwareStatementId = item.O3CallerSoftwareStatementId,
                        O3ApiUri = item.O3ApiUri,
                        O3ApiOperation = item.O3ApiOperation,
                        O3ConsentId = item.O3ConsentId,
                        O3CallerInteractionId = item.O3CallerInteractionId,
                        O3OzoneInteractionId = item.O3OzoneInteractionId,
                        O3PsuIdentifier = item.O3PsuIdentifier,
                        AccountId = item.AccountId,
                        Status = item.Status
                    };
                    result.Add(request);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in MapDbcontenttoModel");
            }
            return result;
        }

        public async Task<List<TppCustomerDetailDto>> GetAllTppCustomerAsync()
        {
            _logger.LogInfo("GetAllTppCustomerAsync started.");
            List<TppCustomerDetailDto> tppCustomerDetailDto = new List<TppCustomerDetailDto>();
            try
            {
                var parameters = new DynamicParameters();

                using (var multi = await _idbConnection.QueryMultipleAsync(_storedProcedureParams.Value.dataSharingSPParams!.GetAllTppCustomerAsync!, parameters, commandType: CommandType.StoredProcedure))
                {
                    tppCustomerDetailDto = multi.Read<TppCustomerDetailDto>().ToList();
                }

            }
            catch (Exception ex)
            {

                _logger.LogError(ex, "Error while fetching GetAllTppCustomerAsync");
                return new List<TppCustomerDetailDto>();
            }
            _logger.LogInfo("GetAllTppCustomerAsync fetched successfully.");
            return tppCustomerDetailDto;
        }

        public async Task<List<TppCustomerDetailDto>> GetTppCustomerByDateAsync(TppCustomerViewDetails tppCustomerViewModel)
        {
            _logger.LogInfo("GetTppCustomerByDateAsync started.");
            List<TppCustomerDetailDto> tppCustomerDetailDto = new List<TppCustomerDetailDto>();
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@FromDate", tppCustomerViewModel.FromDate, DbType.DateTime);
                parameters.Add("@ToDate", tppCustomerViewModel.ToDate, DbType.DateTime);
                parameters.Add("@ConsentId", (object?)tppCustomerViewModel.tppCustomerRequest?.O3ConsentId ?? DBNull.Value, DbType.String);
                parameters.Add("@AccountId", tppCustomerViewModel.AccountId, DbType.String);
                parameters.Add("@Action", (object?)tppCustomerViewModel.tppCustomerResponse?.Status ?? DBNull.Value,DbType.String);
                parameters.Add("@TppName", (object?)tppCustomerViewModel.tppCustomerRequest?.O3CallerOrgId ?? DBNull.Value,DbType.String);
                parameters.Add("@TppID", (object?)tppCustomerViewModel.tppCustomerRequest?.O3CallerClientId ?? DBNull.Value,DbType.String);
                parameters.Add("@CustomerId", (object?)tppCustomerViewModel.tppCustomerResponse?.AccountId ?? DBNull.Value, DbType.String);
                parameters.Add("@CustomerNumber", (object?)tppCustomerViewModel.tppCustomerResponse?.CustomerNumber ?? DBNull.Value, DbType.String);
                parameters.Add("@ClaimFullName", (object?)tppCustomerViewModel.tppCustomerResponse?.ClaimFullName ?? DBNull.Value, DbType.String);


                using (var multi = await _idbConnection.QueryMultipleAsync(_storedProcedureParams.Value.dataSharingSPParams!.GetTppCustomerByDateAsync!, parameters, commandType: CommandType.StoredProcedure))
                {
                    tppCustomerDetailDto = multi.Read<TppCustomerDetailDto>().ToList();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while fetching GetTppCustomerByDateAsync");
                return new List<TppCustomerDetailDto>();
            }
            _logger.LogInfo("GetTppCustomerByDateAsync fetched successfully.");
            return tppCustomerDetailDto;
        }

        public async Task<TppCustomerDetailDto> GetTppCustomerByIdAsync(Guid CorrelationId)
        {
            _logger.LogInfo("GetTppCustomerByIdAsync started.");
            TppCustomerDetailDto tppCustomerDetailDto = new TppCustomerDetailDto();
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@CorrelationId", CorrelationId, DbType.Guid);

                using (var multi = await _idbConnection.QueryMultipleAsync(_storedProcedureParams.Value.dataSharingSPParams!.GetTppCustomerByIdAsync!, parameters, commandType: CommandType.StoredProcedure))
                {
                    tppCustomerDetailDto = multi.Read<TppCustomerDetailDto>().ToList().FirstOrDefault()!;
                }

            }
            catch (Exception ex)
            {

                _logger.LogError(ex, "Error while fetching GetTppCustomerByIdAsync");
                return new TppCustomerDetailDto();
            }
            _logger.LogInfo("GetTppCustomerByIdAsync fetched successfully.");
            return tppCustomerDetailDto;
        }

    }
}
