using Core.WebApi.Dapper.Business.Api.v1.CustomersFacade;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Core.WebApi.Dapper.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly ILogger<CustomersController> _logger;
        private readonly ICustomersFacade _facade;
        public CustomersController(ILogger<CustomersController> logger, ICustomersFacade facade)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _facade = facade ?? throw new ArgumentNullException(nameof(facade));
        }

        [HttpGet]
        //[ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse))]
        //[ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        public async Task<IActionResult> GetAllCustomersAsync(CancellationToken cancellationToken)
        {
            _logger.LogDebug("{method} started", "GetAllCustomersAsync");

            var result = await _facade.GetAllCustomersAsync(cancellationToken);
            return new ObjectResult(result);
        }
    }
}
