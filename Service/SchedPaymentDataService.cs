using Dapper;
using DataSharing_API.IService;
using DataSharing_API.Model;
using Microsoft.Extensions.Options;
using System.Data;

namespace DataSharing_API.Service
{
    public class SchedPaymentDataService : ISchedPaymentDataService
    {
        private IDbConnection _idbConnection;
        private readonly IOptions<StoredProcedureParams> _storedProcedureParams;

        public SchedPaymentDataService(IDbConnection idbConnection, IOptions<StoredProcedureParams> storedProcedureParams)
        {
            _idbConnection = idbConnection;
            _storedProcedureParams = storedProcedureParams;
        }
        public async Task<IEnumerable<SchedPaymentResponse>> GetPaymentDataListAsync()
        {
            try
            {
                var result = await _idbConnection.QueryAsync<SchedPaymentResponse>(
                    _storedProcedureParams.Value.dataSharingSPParams!.RetrievePaymentData!,
                    commandType: CommandType.StoredProcedure
                );
                return result.ToList();
            }
            catch (Exception ex)
            {
                return Enumerable.Empty<SchedPaymentResponse>();
            }
        }
        public async Task<SchedPaymentResponse?> GetPaymentDataByRefIdAsync(string CorrelationId)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("CorrelationId", CorrelationId, DbType.String);

                var result = await _idbConnection.QueryFirstOrDefaultAsync<SchedPaymentResponse>(
                    _storedProcedureParams.Value.dataSharingSPParams!.RetrievePaymentDataByRefId!,
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
        public async Task<IEnumerable<SchedPaymentResponse>> GetPaymentDataSearchByIdAsync(string Fromdate, string Todate, string ConsentId,string AccountId, string Type)
        {
            try
            {
                var parameters = new DynamicParameters();

                parameters.Add("Fromdate", Fromdate, DbType.String);
                parameters.Add("Todate", Todate, DbType.String);
                parameters.Add("ConsentId", ConsentId, DbType.String);
                parameters.Add("AccountId", AccountId, DbType.String);
             
                var result = await _idbConnection.QueryAsync<SchedPaymentResponse>(
                    _storedProcedureParams.Value.dataSharingSPParams!.RetrievePaymentDataSearchByRefId!,
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
