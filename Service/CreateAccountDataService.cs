using Dapper;
using DataSharing_API.IService;
using DataSharing_API.Model;
using DataSharing_API.Models;
using DataSharing_API.Services;
using Microsoft.Extensions.Options;
using OF.ServiceInitiation.CoreBankConn.API.EFModel;
using System.Data;

namespace DataSharing_API.Service
{
    public class CreateAccountDataService: ICreateAccountDataService
    {
        private IDbConnection _idbConnection;
        private readonly IOptions<StoredProcedureParams> _storedProcedureParams;
        private readonly NLogManagerService _logger;
        private readonly AccountDbContext _context;

        public CreateAccountDataService(IDbConnection idbConnection, IOptions<StoredProcedureParams> storedProcedureParams, NLogManagerService logger, AccountDbContext context)
        {
            _idbConnection = idbConnection;
            _storedProcedureParams = storedProcedureParams;
            _logger = logger;
            _context = context;

        }

        public async Task<List<TppAccountsDetailDto>> GetAllTppAccountAsync()
        {
            _logger.LogInfo("GetAllTppAccountAsync started.");
            List<TppAccountsDetailDto> tppAccountsDetailDtos = new List<TppAccountsDetailDto>();
            try
            {
                var parameters = new DynamicParameters();

                using (var multi = await _idbConnection.QueryMultipleAsync(_storedProcedureParams.Value.dataSharingSPParams!.GetAllTppBalancesAsync!, parameters, commandType: CommandType.StoredProcedure))
                {
                    tppAccountsDetailDtos = multi.Read<TppAccountsDetailDto>().ToList();
                }

            }
            catch (Exception ex)
            {

                _logger.LogError(ex, "Error while fetching GetAllTppAccountAsync");
                return new List<TppAccountsDetailDto>();
            }
            _logger.LogInfo("GetAllTppAccountAsync fetched successfully.");
            return tppAccountsDetailDtos;
        }

        public async Task<List<TppAccountsDetailDto>> GetTppAccountByDateAsync(TppAccountsViewModel tppAccountsViewModel)
        {
            _logger.LogInfo("GetTppAccountByDateAsync started.");
            List<TppAccountsDetailDto> tppAccountsDetailDtos = new List<TppAccountsDetailDto>();
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@FromDate", tppAccountsViewModel.FromDate, DbType.DateTime);
                parameters.Add("@ToDate", tppAccountsViewModel.ToDate, DbType.DateTime);
                parameters.Add("@ConsentId", tppAccountsViewModel.ConsentId, DbType.String);
                parameters.Add("@AccountId", tppAccountsViewModel.ConsentId, DbType.String);
                parameters.Add("@Action", tppAccountsViewModel.Action, DbType.String);

                using (var multi = await _idbConnection.QueryMultipleAsync(_storedProcedureParams.Value.dataSharingSPParams!.GetTppBalancesByDateAsync!, parameters, commandType: CommandType.StoredProcedure))
                {
                    tppAccountsDetailDtos = multi.Read<TppAccountsDetailDto>().ToList();
                }
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, "Error while fetching GetTppAccountByDateAsync");
                return new List<TppAccountsDetailDto>();
            }
            _logger.LogInfo("GetTppAccountByDateAsync fetched successfully.");
            return tppAccountsDetailDtos;
        }

        public async Task<TppAccountsDetailDto> GetTppAccountByIdAsync(long accountRequestId)
        {
            _logger.LogInfo("GetTppAccountByIdAsync started.");
            TppAccountsDetailDto tppAccountsDetailDto = new TppAccountsDetailDto();
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@AccountRequestId", accountRequestId, DbType.String);

                using (var multi = await _idbConnection.QueryMultipleAsync(_storedProcedureParams.Value.dataSharingSPParams!.GetTppBalancesByIdAsync!, parameters, commandType: CommandType.StoredProcedure))
                {
                    tppAccountsDetailDto = multi.Read<TppAccountsDetailDto>().ToList().FirstOrDefault()!;
                }

            }
            catch (Exception ex)
            {

                _logger.LogError(ex, "Error while fetching GetTppAccountByIdAsync");
                return new TppAccountsDetailDto();
            }
            _logger.LogInfo("GetTppAccountByIdAsync fetched successfully.");
            return tppAccountsDetailDto;
        }

        public async Task<long> SaveAccountRequestAsync(TppAccountsRequest tppAccountsRequest)
        {
            long balanceRequestId = 0;
            try
            {
                _context.tppAccountsRequests.Add(tppAccountsRequest);
                await _context.SaveChangesAsync();
                balanceRequestId = tppAccountsRequest.AccountsRequestId;

                _logger.LogInfo($"SaveAccountRequestAsync is done. Id:{tppAccountsRequest.AccountsRequestId})");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"CorrelationId: {tppAccountsRequest.CorrelationId} || An error occurred while saving SaveAccountRequestAsync.");
            }
            return balanceRequestId;
        }

        public async Task<string> SaveAccountResponseAsync(long id, TppAccountsResponse tppAccountsResponse)
        {
            string result = string.Empty;
            try
            {
                tppAccountsResponse.AccountsRequestId = id;

                _context.tppAccountsResponses.Add(tppAccountsResponse);
                await _context.SaveChangesAsync();
                result = tppAccountsResponse.AccountsResponseId > 0 ? "SUCCESS" : "FAILURE";
                _logger.LogInfo($"SaveAccountResponseAsync is done. AccountsRequestId: {id}, AccountsResponseId:{tppAccountsResponse.AccountsResponseId})");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while saving SaveAccountResponseAsync.");
            }
            return result;
        }
    }
}
