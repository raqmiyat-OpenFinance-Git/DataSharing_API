using Dapper;
using DataSharing_API.IService;
using DataSharing_API.Model;
using Microsoft.Extensions.Options;
using System.Data;

namespace DataSharing_API.Service
{
    public class CustomerDataService:ICustomerDataService
    {
        private IDbConnection _idbConnection;
        private readonly IOptions<StoredProcedureParams> _storedProcedureParams;

        public CustomerDataService(IDbConnection idbConnection, IOptions<StoredProcedureParams> storedProcedureParams)
        {
            _idbConnection = idbConnection;
            _storedProcedureParams = storedProcedureParams;
        }
        public async Task<IEnumerable<CustomerDataResponse>> GetCustomerDataListAsync()
        {
            try
            {
                var result = await _idbConnection.QueryAsync<CustomerDataResponse>(
                    _storedProcedureParams.Value.dataSharingSPParams!.RetrieveCustomerData!,
                    commandType: CommandType.StoredProcedure
                );
                return result.ToList();
            }
            catch (Exception ex)
            {
                return Enumerable.Empty<CustomerDataResponse>();
            }
        }

        public async Task<CustomerDataResponse?> GetCustomerDataByRefIdAsync(string CorrelationId)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("CorrelationId", CorrelationId, DbType.String);

                var result = await _idbConnection.QueryFirstOrDefaultAsync<CustomerDataResponse>(
                    _storedProcedureParams.Value.dataSharingSPParams!.RetrieveCustomerDataByRefId!,
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
        public async Task<IEnumerable<CustomerDataResponse>> GetCustomerDataSearchByIdAsync(string Fromdate, string Todate,string ConsentId, string Type,string CustomerId, string Customernbr, string Customername, string Customerstatus
            , string OrganizationId, string ClientId)
        {
            try
            {
                var parameters = new DynamicParameters();
              
                parameters.Add("Fromdate", Fromdate, DbType.String);
                parameters.Add("Todate", Todate, DbType.String);
                parameters.Add("ConsentId", ConsentId, DbType.String);
                parameters.Add("Type", Type, DbType.String);
                parameters.Add("CustomerId", CustomerId, DbType.String);
                parameters.Add("CustomerName", Customername, DbType.String);
                parameters.Add("CustomerNbr", Customernbr, DbType.String);
                parameters.Add("CustomerStatus", Customerstatus, DbType.String);
                parameters.Add("OrganizationId", OrganizationId, DbType.String);
                parameters.Add("ClientId", ClientId, DbType.String);
                var result = await _idbConnection.QueryAsync<CustomerDataResponse>(
                    _storedProcedureParams.Value.dataSharingSPParams!.RetrieveCustomerDataSearchByRefId!,
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
