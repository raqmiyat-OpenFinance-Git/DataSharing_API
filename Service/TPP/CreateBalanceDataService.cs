using DataSharing_API.IService.TPP;

namespace DataSharing_API.Service.TPP;

public class CreateBalanceDataService : ICreateBalanceDataService
{
    private IDbConnection _idbConnection;
    private readonly IOptions<StoredProcedureParams> _storedProcedureParams;
    private readonly DataSharingLogger _logger;
    private readonly BalanceDbContext _context;

    public CreateBalanceDataService(IDbConnection idbConnection, IOptions<StoredProcedureParams> storedProcedureParams, DataSharingLogger logger, BalanceDbContext postbalanceDbContext)
    {
        _idbConnection = idbConnection;
        _storedProcedureParams = storedProcedureParams;
        _logger = logger;
        _context = postbalanceDbContext;

    }


    public async Task<List<TppBalancesDetailDto>> GetAllTppBalancesAsync()
    {
        _logger.Info("GetCheckerTppConsents started.");
        List<TppBalancesDetailDto> tppBalancesDetailDtos = new List<TppBalancesDetailDto>();
        try
        {
            var parameters = new DynamicParameters();

            using (var multi = await _idbConnection.QueryMultipleAsync(_storedProcedureParams.Value.dataSharingSPParams!.GetAllTppBalancesAsync!, parameters, commandType: CommandType.StoredProcedure))
            {
                tppBalancesDetailDtos = multi.Read<TppBalancesDetailDto>().ToList();
            }

        }
        catch (Exception ex)
        {

            _logger.Error(ex, "Error while fetching GetCheckerTppConsents");
            return new List<TppBalancesDetailDto>();
        }
        _logger.Info("GetCheckerTppConsents fetched successfully.");
        return tppBalancesDetailDtos;
    }

    public async Task<List<TppBalancesDetailDto>> GetTppBalancesByDateAsync(TppBalancesViewModel tppBalancesViewModel)
    {
        _logger.Info("GetTppConsentsByDate started.");
        List<TppBalancesDetailDto> tppBalancesDetailDtos = new List<TppBalancesDetailDto>();
        try
        {
            var parameters = new DynamicParameters();
            parameters.Add("@FromDate", tppBalancesViewModel.FromDate, DbType.DateTime);
            parameters.Add("@ToDate", tppBalancesViewModel.ToDate, DbType.DateTime);
            parameters.Add("@ConsentId", tppBalancesViewModel.ConsentId, DbType.String);
            parameters.Add("@AccountId", (object?)tppBalancesViewModel.tppBalancesResponse?.AccountId ?? DBNull.Value, DbType.String);
            parameters.Add("@BalanceStatus", (object?)tppBalancesViewModel.tppBalancesResponse?.Status ?? DBNull.Value, DbType.String);
            parameters.Add("@TppOrganizationId", (object?)tppBalancesViewModel.tppBalancesRequest?.O3CallerOrgId ?? DBNull.Value, DbType.String);
            parameters.Add("@TppClientId", (object?)tppBalancesViewModel.tppBalancesRequest?.O3CallerClientId ?? DBNull.Value, DbType.String);
            parameters.Add("@BalanceAmount", (object?)tppBalancesViewModel.tppBalancesResponse?.AccountBalanceAmount ?? DBNull.Value, DbType.Decimal);

            using (var multi = await _idbConnection.QueryMultipleAsync(_storedProcedureParams.Value.dataSharingSPParams!.GetTppBalancesByDateAsync!, parameters, commandType: CommandType.StoredProcedure))
            {
                tppBalancesDetailDtos = multi.Read<TppBalancesDetailDto>().ToList();
            }
        }
        catch (Exception ex)
        {

            _logger.Error(ex, "Error while fetching GetTppConsentsByDate");
            return new List<TppBalancesDetailDto>();
        }
        _logger.Info("GetTppConsentsByDate fetched successfully.");
        return tppBalancesDetailDtos;
    }

    public async Task<TppBalancesDetailDto> GetTppBalancesByIdAsync(long balanceRequestId)
    {
        _logger.Info("GetTppConsentById started.");
        TppBalancesDetailDto tppBalancesDetailDto = new TppBalancesDetailDto();
        try
        {
            var parameters = new DynamicParameters();
            parameters.Add("@BalanceRequestId", balanceRequestId, DbType.String);

            using (var multi = await _idbConnection.QueryMultipleAsync(_storedProcedureParams.Value.dataSharingSPParams!.GetTppBalancesByIdAsync!, parameters, commandType: CommandType.StoredProcedure))
            {
                tppBalancesDetailDto = multi.Read<TppBalancesDetailDto>().ToList().FirstOrDefault()!;
            }

        }
        catch (Exception ex)
        {

            _logger.Error(ex, "Error while fetching GetTppConsentById");
            return new TppBalancesDetailDto();
        }
        _logger.Info("GetTppConsentById fetched successfully.");
        return tppBalancesDetailDto;
    }

    async Task<long> ICreateBalanceDataService.SaveBalanceRequestAsync(TppBalancesRequest tppBalancesRequest)
    {
        long balanceRequestId = 0;
        try
        {
            _context.TppBalancesRequest.Add(tppBalancesRequest);
            await _context.SaveChangesAsync();
            balanceRequestId = tppBalancesRequest.BalanceRequestId;

            _logger.Info($"SaveConsentRequestAsync is done. Id:{tppBalancesRequest.BalanceRequestId})");
        }
        catch (Exception ex)
        {
            _logger.Error(ex, $"CorrelationId: {tppBalancesRequest.CorrelationId} || An error occurred while saving SaveConsentRequestAsync.");
        }
        return balanceRequestId;
    }

    public async Task<string> SaveBalanceResponseAsync(long id, TppBalancesResponse tppBalancesResponse)
    {
        string result = string.Empty;
        try
        {
            tppBalancesResponse.BalanceRequestId = id;

            _context.TppBalancesResponse.Add(tppBalancesResponse);
            await _context.SaveChangesAsync();
            result = tppBalancesResponse.BalanceResponseId > 0 ? "SUCCESS" : "FAILURE";
            _logger.Info($"SaveConsentResponseAsync is done. ConsentRequestId: {id}, ConsentResponseId:{tppBalancesResponse.BalanceResponseId})");
        }
        catch (Exception ex)
        {
            _logger.Error(ex, $"An error occurred while saving SaveConsentResponseAsync.");
        }
        return result;
    }

    public bool ValidateConsentId(string consentId)
    {
        try
        {
            var parameters = new DynamicParameters();
            parameters.Add("@ConsentId", consentId, DbType.String);

            int result = _idbConnection.QueryFirstOrDefault<int>(
                _storedProcedureParams.Value.dataSharingSPParams!.GetConsent_Status!,
                parameters,
                commandType: CommandType.StoredProcedure
            );

            // Return true if IsAuthorized = 1, false otherwise
            return result == 1;
        }
        catch (Exception ex)
        {
            _logger.Error(ex, "Error while checking consent status");
            return false;
        }
    }
}
