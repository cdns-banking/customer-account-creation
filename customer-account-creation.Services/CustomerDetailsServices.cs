using customer_account_creation.Dal;
using customer_account_creation.Domain.Interfaces;
using customer_account_creation.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace customer_account_creation.Services
{
    public class CustomerDetailsServices : ICustomerDetailsService
    {
        //private readonly ICustomerDetailsRepository _repo;
        private readonly CustomerDetailsRepository _context;

        public CustomerDetailsServices(CustomerDetailsRepository context)
        {
            //_repo = repo;
            _context = context;
        }

        

        public async Task<CustomerDetails> GetCustomerDetails(string userId)
        {
            return await _context.CustomerDetails.FindAsync(userId);
        }

        public async Task<CustomerDetails> PostCustomerDetails(CustomerDetails customerDetails)
        {
            await _context.CustomerDetails.AddAsync(customerDetails);
            await _context.SaveChangesAsync();
            return customerDetails;
        }

        public async Task<CustomerDetails> UpdateCustomerDetails(CustomerDetails customerDetails)
        {
            var customerDetail = await _context.CustomerDetails.FindAsync(customerDetails.AccountNumber);
            if (customerDetail == null)
                throw new Exception("Cutomer details not found");

            customerDetail.FirstName = customerDetails.FirstName;
            customerDetail.LastName = customerDetails.LastName;
            customerDetail.EmailId = customerDetails.EmailId;
            customerDetail.PhoneNumber = customerDetails.PhoneNumber;
            customerDetail.UniversityName = customerDetails.UniversityName;
            customerDetail.UserType = customerDetails.UserType;
            customerDetail.IsEnabled = customerDetails.IsEnabled;



            await _context.SaveChangesAsync();

            return customerDetails;
        }
        public Task<CustomerDetails> DeleteCustomerDetails(CustomerDetails customerDetails)
        {
            throw new NotImplementedException();
        }

    }
}
