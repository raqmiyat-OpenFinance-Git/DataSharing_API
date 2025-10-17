using DataSharing_API.IService.TPP;

namespace DataSharing_API.Service.TPP;

public class CreateAccountDataService : ICreateAccountDataService
{
    private IDbConnection _idbConnection;
    private readonly IOptions<StoredProcedureParams> _storedProcedureParams;
    private readonly DataSharingLogger _logger;
    private readonly AccountDbContext _context;

    public CreateAccountDataService(IDbConnection idbConnection, IOptions<StoredProcedureParams> storedProcedureParams, DataSharingLogger logger, AccountDbContext context)
    {
        _idbConnection = idbConnection;
        _storedProcedureParams = storedProcedureParams;
        _logger = logger;
        _context = context;

    }

    public async Task<List<TppAccountsDetailDto>> GetAllTppAccountAsync()
    {
        _logger.Info("GetAllTppAccountAsync started.");
        List<TppAccountsDetailDto> tppAccountsDetailDtos = new List<TppAccountsDetailDto>();
        try
        {
            var parameters = new DynamicParameters();

            using (var multi = await _idbConnection.QueryMultipleAsync(_storedProcedureParams.Value.dataSharingSPParams!.GetAllTppAccountsAsync!, parameters, commandType: CommandType.StoredProcedure))
            {
                tppAccountsDetailDtos = multi.Read<TppAccountsDetailDto>().ToList();
            }

        }
        catch (Exception ex)
        {

            _logger.Error(ex, "Error while fetching GetAllTppAccountAsync");
            return new List<TppAccountsDetailDto>();
        }
        _logger.Info("GetAllTppAccountAsync fetched successfully.");
        return tppAccountsDetailDtos;
    }

    public async Task<List<TppAccountsDetailDto>> GetTppAccountByDateAsync(TppAccountsViewModel tppAccountsViewModel)
    {
        _logger.Info("GetTppAccountByDateAsync started.");
        List<TppAccountsDetailDto> tppAccountsDetailDtos = new List<TppAccountsDetailDto>();
        try
        {
            var parameters = new DynamicParameters();
            parameters.Add("@FromDate", tppAccountsViewModel.FromDate, DbType.DateTime);
            parameters.Add("@ToDate", tppAccountsViewModel.ToDate, DbType.DateTime);
            parameters.Add("@ConsentId", (object?)tppAccountsViewModel.tppAccountsRequest?.O3ConsentId ?? DBNull.Value, DbType.String);
            parameters.Add("@AccountId", (object?)tppAccountsViewModel.tppAccountsResponse?.AccountId ?? DBNull.Value, DbType.String);
            parameters.Add("@Status", (object?)tppAccountsViewModel.tppAccountsResponse?.Status ?? DBNull.Value, DbType.String);
            parameters.Add("@TppName", (object?)tppAccountsViewModel.tppAccountsRequest?.O3CallerOrgId ?? DBNull.Value, DbType.String);
            parameters.Add("@TppID", (object?)tppAccountsViewModel.tppAccountsRequest?.O3CallerClientId ?? DBNull.Value, DbType.String);
            using (var multi = await _idbConnection.QueryMultipleAsync(_storedProcedureParams.Value.dataSharingSPParams!.GetTppAccountsByDateAsync!, parameters, commandType: CommandType.StoredProcedure))
            {
                tppAccountsDetailDtos = multi.Read<TppAccountsDetailDto>().ToList();
            }
        }
        catch (Exception ex)
        {

            _logger.Error(ex, "Error while fetching GetTppAccountByDateAsync");
            return new List<TppAccountsDetailDto>();
        }
        _logger.Info("GetTppAccountByDateAsync fetched successfully.");
        return tppAccountsDetailDtos;
    }

    public async Task<TppAccountsDetailDto> GetTppAccountByIdAsync(long accountsRequestId)
    {
        _logger.Info("GetTppAccountByIdAsync started.");
        TppAccountsDetailDto tppAccountsDetailDto = new TppAccountsDetailDto();
        try
        {
            var parameters = new DynamicParameters();
            parameters.Add("@AccountsRequestId", accountsRequestId, DbType.String);

            using (var multi = await _idbConnection.QueryMultipleAsync(_storedProcedureParams.Value.dataSharingSPParams!.GetTppAccountsByIdAsync!, parameters, commandType: CommandType.StoredProcedure))
            {
                tppAccountsDetailDto = multi.Read<TppAccountsDetailDto>().ToList().FirstOrDefault()!;
            }

        }
        catch (Exception ex)
        {

            _logger.Error(ex, "Error while fetching GetTppAccountByIdAsync");
            return new TppAccountsDetailDto();
        }
        _logger.Info("GetTppAccountByIdAsync fetched successfully.");
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

            _logger.Info($"SaveAccountRequestAsync is done. Id:{tppAccountsRequest.AccountsRequestId})");
        }
        catch (Exception ex)
        {
            _logger.Error(ex, $"CorrelationId: {tppAccountsRequest.CorrelationId} || An error occurred while saving SaveAccountRequestAsync.");
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
            _logger.Info($"SaveAccountResponseAsync is done. AccountsRequestId: {id}, AccountsResponseId:{tppAccountsResponse.AccountsResponseId})");
        }
        catch (Exception ex)
        {
            _logger.Error(ex, $"An error occurred while saving SaveAccountResponseAsync.");
        }
        return result;
    }
}
