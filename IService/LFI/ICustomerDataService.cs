namespace DataSharing_API.IService.LFI;

public interface ICustomerDataService
{
    Task<IEnumerable<CustomerDataResponse>> GetCustomerDataListAsync(string CustomerCategory);

    Task<CustomerDataResponse> GetCustomerDataByRefIdAsync(string CorrelationId);

    Task<IEnumerable<CustomerDataResponse>> GetCustomerDataSearchByIdAsync(string Fromdate, string todate, string ConsentId, string Type, string CustomerId, string Customernbr,
        string Customername, string Customerstatus, string OrganizationId, string ClientId,string CustomerCategory);
}
