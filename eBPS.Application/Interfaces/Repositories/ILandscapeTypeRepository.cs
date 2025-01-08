using eBPS.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eBPS.Application.Interfaces.Repositories
{
    public interface ILandscapeTypeRepository
    {
        
            Task<IEnumerable<LandscapeTypeDTO>> GetActiveLandscapeType();
        
    }
}
