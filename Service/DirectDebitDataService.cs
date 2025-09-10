using Dapper;
using DataSharing_API.IService;
using DataSharing_API.Model;
using Microsoft.Extensions.Options;
using System.Data;

namespace DataSharing_API.Service
{
    public class DirectDebitDataService : IDirectDebitDataService
    {
        private IDbConnection _idbConnection;
        private readonly IOptions<StoredProcedureParams> _storedProcedureParams;

        public DirectDebitDataService(IDbConnection idbConnection, IOptions<StoredProcedureParams> storedProcedureParams)
        {
            _idbConnection = idbConnection;
            _storedProcedureParams = storedProcedureParams;
        }
        public async Task<IEnumerable<DirectDebitResponse>> GetDirectdebitDataListAsync()
        {
            try
            {
                var result = await _idbConnection.QueryAsync<DirectDebitResponse>(
                    _storedProcedureParams.Value.dataSharingSPParams!.RetrieveDirectDebitData!,
                    commandType: CommandType.StoredProcedure
                );
                return result.ToList();
            }
            catch (Exception ex)
            {
                return Enumerable.Empty<DirectDebitResponse>();
            }
        }
        public async Task<DirectDebitResponse?> GetDirectdebitDataByRefIdAsync(string CorrelationId)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("CorrelationId", CorrelationId, DbType.String);

                var result = await _idbConnection.QueryFirstOrDefaultAsync<DirectDebitResponse>(
                    _storedProcedureParams.Value.dataSharingSPParams!.RetrieveDirectDebitDataByRefId!,
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
        public async Task<IEnumerable<DirectDebitResponse>> GetDirectdebitDataSearchByIdAsync(string Fromdate, string Todate, string ConsentId,string AccountId, string Type)
        {
            try
            {
                var parameters = new DynamicParameters();

                parameters.Add("Fromdate", Fromdate, DbType.String);
                parameters.Add("Todate", Todate, DbType.String);
                parameters.Add("ConsentId", ConsentId, DbType.String);
                parameters.Add("AccountId", AccountId, DbType.String);
             
                var result = await _idbConnection.QueryAsync<DirectDebitResponse>(
                    _storedProcedureParams.Value.dataSharingSPParams!.RetrieveDirectDebitDataSearchByRefId!,
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
