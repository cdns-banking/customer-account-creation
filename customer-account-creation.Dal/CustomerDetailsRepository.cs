using customer_account_creation.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using customer_account_creation.Domain.Models;

namespace customer_account_creation.Dal
{
    public class CustomerDetailsRepository : DbContext
    {
        public CustomerDetailsRepository(DbContextOptions<CustomerDetailsRepository> options) : base(options) { }

        public DbSet<CustomerDetails> CustomerDetails { get; set; }


       
    }
}   
