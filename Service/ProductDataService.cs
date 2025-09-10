using Dapper;
using DataSharing_API.IService;
using DataSharing_API.Model;
using Microsoft.Extensions.Options;
using System.Data;

namespace DataSharing_API.Service
{
    public class ProductDataService : IProductDataService
    {
        private IDbConnection _idbConnection;
        private readonly IOptions<StoredProcedureParams> _storedProcedureParams;

        public ProductDataService(IDbConnection idbConnection, IOptions<StoredProcedureParams> storedProcedureParams)
        {
            _idbConnection = idbConnection;
            _storedProcedureParams = storedProcedureParams;
        }
        public async Task<IEnumerable<ProductResponse>> GetProductDataListAsync()
        {
            try
            {
                var result = await _idbConnection.QueryAsync<ProductResponse>(
                    _storedProcedureParams.Value.dataSharingSPParams!.RetrieveProductData!,
                    commandType: CommandType.StoredProcedure
                );
                return result.ToList();
            }
            catch (Exception ex)
            {
                return Enumerable.Empty<ProductResponse>();
            }
        }
        public async Task<ProductResponse?> GetProductDataByRefIdAsync(string CorrelationId)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("CorrelationId", CorrelationId, DbType.String);

                var result = await _idbConnection.QueryFirstOrDefaultAsync<ProductResponse>(
                    _storedProcedureParams.Value.dataSharingSPParams!.RetrieveProductDataByRefId!,
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
        public async Task<IEnumerable<ProductResponse>> GetProductDataSearchByIdAsync(string Fromdate, string Todate, string ConsentId,string AccountId, string Type)
        {
            try
            {
                var parameters = new DynamicParameters();

                parameters.Add("Fromdate", Fromdate, DbType.String);
                parameters.Add("Todate", Todate, DbType.String);
                parameters.Add("ConsentId", ConsentId, DbType.String);
                parameters.Add("AccountId", AccountId, DbType.String);
             
                var result = await _idbConnection.QueryAsync<ProductResponse>(
                    _storedProcedureParams.Value.dataSharingSPParams!.RetrieveProductDataSearchByRefId!,
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
