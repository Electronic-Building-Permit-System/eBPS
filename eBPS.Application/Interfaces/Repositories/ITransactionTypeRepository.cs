using eBPS.Application.DTOs.BuildingApplication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eBPS.Application.Interfaces.Repositories
{
    public interface ITransactionTypeRepository
    {
        
            Task<IEnumerable<TransactionTypeDTO>> GetActiveTransactionType();
        
    }
}
