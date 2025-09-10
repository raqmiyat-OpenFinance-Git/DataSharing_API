using Dapper;
using DataSharing_API.IService;
using DataSharing_API.Model;
using Microsoft.Extensions.Options;
using System.Data;

namespace DataSharing_API.Service
{
    public class BalanceDataService:IBalanceDataService
    {
        private IDbConnection _idbConnection;
        private readonly IOptions<StoredProcedureParams> _storedProcedureParams;

        public BalanceDataService(IDbConnection idbConnection, IOptions<StoredProcedureParams> storedProcedureParams)
        {
            _idbConnection = idbConnection;
            _storedProcedureParams = storedProcedureParams;
        }
        //public async Task<IEnumerable<BalanceData>> GetBalanceDataListAsync(string RequestType)
        //{
        //    try
        //    {
        //        var parameters = new DynamicParameters();
        //        parameters.Add("RequestType", RequestType, DbType.String);
        //        var result = await _idbConnection.QueryAsync<BalanceData>(
        //            _storedProcedureParams.Value.dataSharingSPParams!.RetrieveBalanceData!, parameters,
        //            commandType: CommandType.StoredProcedure
        //        );
        //        return result.ToList();
        //    }
        //    catch (Exception ex)
        //    {
        //        return Enumerable.Empty<BalanceData>();
        //    }
        //}

        public async Task<IEnumerable<BalanceData>> GetBalanceDataListAsync()
        {
            try
            {
                var parameters = new DynamicParameters();
                
                var result = await _idbConnection.QueryAsync<BalanceData>(
                    _storedProcedureParams.Value.dataSharingSPParams!.RetrieveBalanceData!, 
                    commandType: CommandType.StoredProcedure
                );
                return result.ToList();
            }
            catch (Exception ex)
            {
                return Enumerable.Empty<BalanceData>();
            }
        }

        public async Task<BalanceData?> GetBalanceDataByRefIdAsync(string CorrelationId)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("CorrelationId", CorrelationId, DbType.String);

                var result = await _idbConnection.QueryFirstOrDefaultAsync<BalanceData>(
                    _storedProcedureParams.Value.dataSharingSPParams!.RetrieveBalanceDataByRefId!,
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
        public async Task<IEnumerable<BalanceData?>> GetBalanceDataSearchByIdAsync(string AccountId, string Fromdate, string Todate,string ConsentId, string balancestatus, string OrganizationId, string ClientId, string amount)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("AccountId", AccountId, DbType.String);
                parameters.Add("Fromdate", Fromdate, DbType.String);
                parameters.Add("Todate", Todate, DbType.String);
                parameters.Add("ConsentId", ConsentId, DbType.String);
                parameters.Add("BalanceStatus", balancestatus, DbType.String);
                parameters.Add("TppOrganizationId", OrganizationId, DbType.String);
                parameters.Add("TppClientId", ClientId, DbType.String);
                parameters.Add("BalanceAmount", amount, DbType.String);
                var result = await _idbConnection.QueryAsync<BalanceData>(
                    _storedProcedureParams.Value.dataSharingSPParams!.RetrieveBalanceDataSearchByRefId!,
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
