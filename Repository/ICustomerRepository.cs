using ODataProject_CustomersData.Model;

namespace ODataProject_CustomersData.Repository
{
    public interface ICustomerRepository
    {
        Task<List<CustomerModel>> GetCustomerData();
        Task<CustomerModel> GetCustomerById(int id);
        Task<int> PostNewCustomer(CustomerModel customer);
        Task DeleteCustomer(int id);
        Task UpdateCustomer(CustomerModel customer);
     }
}


