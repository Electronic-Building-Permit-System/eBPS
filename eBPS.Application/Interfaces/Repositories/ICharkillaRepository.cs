using eBPS.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eBPS.Application.Interfaces.Repositories
{
    public interface ICharkillaRepository
    {
        Task AddCharkillaAsync(List<CharkillaDTO> houseOwner, int applicationId, string connectionString);
    }
    
       
    
}
