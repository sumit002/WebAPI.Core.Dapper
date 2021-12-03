using Core.WebApi.Dapper.Models.CustomModels;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Core.WebApi.Dapper.Business.Api.v1.CustomersFacade
{
    public interface ICustomersFacade
    {
        //Task<bool> GetAllCustomersAsync(CancellationToken cancellationToken);
        Task<IEnumerable<Customers>> GetAllCustomersAsync(CancellationToken cancellationToken);
    }
}
