using Dapper;
using DataSharing_API.IService;
using DataSharing_API.Model;
using Microsoft.Extensions.Options;
using System.Data;

namespace DataSharing_API.Service
{
    public class AccountDataService : IAccountDataService
    {
        private IDbConnection _idbConnection;
        private readonly IOptions<StoredProcedureParams> _storedProcedureParams;

        public AccountDataService(IDbConnection idbConnection, IOptions<StoredProcedureParams> storedProcedureParams)
        {
            _idbConnection = idbConnection;
            _storedProcedureParams = storedProcedureParams;
        }
        public async Task<IEnumerable<AccountDataResponse>> GetAccountDataListAsync()
        {
            try
            {
                var result = await _idbConnection.QueryAsync<AccountDataResponse>(
                    _storedProcedureParams.Value.dataSharingSPParams!.RetrieveAccountData!,
                    commandType: CommandType.StoredProcedure
                );
                return result.ToList();
            }
            catch (Exception ex)
            {
                return Enumerable.Empty<AccountDataResponse>();
            }
        }

        public async Task<AccountDataResponse?> GetAccountDataByRefIdAsync(string CorrelationId)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("CorrelationId", CorrelationId, DbType.String);

                var result = await _idbConnection.QueryFirstOrDefaultAsync<AccountDataResponse>(
                    _storedProcedureParams.Value.dataSharingSPParams!.RetrieveAccountDataByRefId!,
                    parameters,
                    commandType: CommandType.StoredProcedure
                );
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<IEnumerable<AccountDataResponse>> GetAccountDataSearchByIdAsync(string Fromdate, string Todate, string ConsentId,string AccountId, string Type)
        {
            try
            {
                var parameters = new DynamicParameters();

                parameters.Add("Fromdate", Fromdate, DbType.String);
                parameters.Add("Todate", Todate, DbType.String);
                parameters.Add("ConsentId", ConsentId, DbType.String);
                parameters.Add("AccountId", AccountId, DbType.String);
                parameters.Add("Type", Type, DbType.String);
                var result = await _idbConnection.QueryAsync<AccountDataResponse>(
                    _storedProcedureParams.Value.dataSharingSPParams!.RetrieveAccountDataSearchByRefId!,
                    parameters,
                    commandType: CommandType.StoredProcedure
                );
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
