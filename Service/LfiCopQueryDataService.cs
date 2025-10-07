using Dapper;
using DataSharing_API.IService;
using DataSharing_API.Model;
using Microsoft.Extensions.Options;
using System.Data;

namespace DataSharing_API.Service
{
    public class LfiCopQueryDataService : ILfiCopQueryDataService
    {
        private IDbConnection _idbConnection;
        private readonly IOptions<StoredProcedureParams> _storedProcedureParams;

        public LfiCopQueryDataService(IDbConnection idbConnection, IOptions<StoredProcedureParams> storedProcedureParams)
        {
            _idbConnection = idbConnection;
            _storedProcedureParams = storedProcedureParams;
        }

        public async Task<IEnumerable<LfiCoPQueryData>> GetCopQueryDataListAsync()
        {
            try
            {
                var result = await _idbConnection.QueryAsync<LfiCoPQueryData>(
                    _storedProcedureParams.Value.dataSharingSPParams!.RetrieveCoPQueryData!,
                    commandType: CommandType.StoredProcedure
                );
                return result.ToList();
            }
            catch (Exception ex)
            {
                return Enumerable.Empty<LfiCoPQueryData>();
            }
        }

        public async Task<LfiCoPQueryData> GetCopQueryDataByRefIdAsync(string CorrelationId)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("CorrelationId", CorrelationId, DbType.String);

                var result = await _idbConnection.QueryFirstOrDefaultAsync<LfiCoPQueryData>(
                    _storedProcedureParams.Value.dataSharingSPParams!.RetrieveCoPQueryDataByRefId!,
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

        public async Task<IEnumerable<LfiCoPQueryData>> GetCopQueryDataSearchByIdAsync(string Fromdate, string todate, string CustomerName, string Customerstatus)
        {
            try
            {
                var parameters = new DynamicParameters();

                parameters.Add("Fromdate", Fromdate, DbType.String);
                parameters.Add("Todate", todate, DbType.String);
                parameters.Add("CustomerName", CustomerName, DbType.String);
                parameters.Add("CustomerStatus", Customerstatus, DbType.String);
                var result = await _idbConnection.QueryAsync<LfiCoPQueryData>(
                    _storedProcedureParams.Value.dataSharingSPParams!.RetrieveCoPQueryDataSearchByRefId!,
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
