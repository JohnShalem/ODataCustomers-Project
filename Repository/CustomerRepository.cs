using ODataProject_CustomersData.Model;
using ODataProject_CustomersData.Models;
using Microsoft.EntityFrameworkCore;

namespace ODataProject_CustomersData.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly CustomerDataContext _CustomerDataContext;

        public CustomerRepository(CustomerDataContext _customercontext)
        {
            this._CustomerDataContext = _customercontext;
        }

        //Getting all customers data
        public async Task<List<CustomerModel>> GetCustomerData()
        {
            var customer = _CustomerDataContext.Customers.Select(x => new CustomerModel()
            {
                CustomerId = x.CustomerId,
                FirstName = x.FirstName,
                LastName = x.LastName,
                City = x.City,
                ZipCode = x.ZipCode,
                State = x.State,
                Street = x.Street,
                Email = x.Email,
            });

            return await customer.ToListAsync();
        }

        //Getting customer data by id
        public async Task<CustomerModel> GetCustomerById(int id)
        {
            var customer = await _CustomerDataContext.Customers.Where(x => x.CustomerId == id).Select(x => new CustomerModel()
            {
                CustomerId = x.CustomerId,
                FirstName = x.FirstName,
                LastName = x.LastName,
                City = x.City,
                ZipCode = x.ZipCode,
                State = x.State,
                Street = x.Street,
                Email = x.Email,
            }).FirstOrDefaultAsync();

            
                return customer;
            
            
        }

        //Insert a New Customer
        public async Task<int> PostNewCustomer(CustomerModel customer)
        {
            var newcustomer = new Customer()
            {
                CustomerId = customer.CustomerId,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Email = customer.Email,
                City = customer.City,
                State = customer.State,
                Street = customer.Street,
                ZipCode = customer.ZipCode,

            };

            _CustomerDataContext.Customers.Add(newcustomer);
            await _CustomerDataContext.SaveChangesAsync();
            return customer.CustomerId;
        }


        //Delete a customer
        public async Task DeleteCustomer(int id)
        {
            var newcustomer = new Customer()
            {
                CustomerId = id
            };

            _CustomerDataContext.Customers.Remove(newcustomer);
            await _CustomerDataContext.SaveChangesAsync();
        }

        //Update a customer
        public async Task UpdateCustomer(CustomerModel customer)
        {
            var newcustomer = new Customer()
            {
                CustomerId= customer.CustomerId,
                FirstName= customer.FirstName,
                City = customer.City,
                State= customer.State,
                Email = customer.Email,
                Street = customer.Street,
                LastName = customer.LastName,
                ZipCode= customer.ZipCode,
            };

            _CustomerDataContext.Customers.Update(newcustomer);
            await _CustomerDataContext.SaveChangesAsync();
        }





    }
}
