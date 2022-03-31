using customer_account_creation.Domain.Interfaces;
using customer_account_creation.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace customer_account_creation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CustomerAccountController : ControllerBase
    {
        private readonly ICustomerDetailsService _service;
        private readonly ILogger<CustomerAccountController> _logger;

        public CustomerAccountController(ICustomerDetailsService service, ILogger<CustomerAccountController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet("GetCustomerDetails")]
        public async Task<ActionResult<CustomerDetails>> GetCustomerDetails(string userId)
        {
            try
            {

                return await _service.GetCustomerDetails(userId);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("PostCustomerDetails")]
        public async Task<ActionResult<CustomerDetails>> PostCustomerDetails(CustomerDetails customerDetails)
        {
            try
            {
                return await _service.PostCustomerDetails(customerDetails);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
            
        }

    }
}
