using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentCarStore.Contracts.Domain.Services.Interfaces
{
    public interface IContractService
    {
        Task CreateContract(Contract contract);

    }
}
