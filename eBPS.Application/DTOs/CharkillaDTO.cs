using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eBPS.Application.DTOs
{
    public class CharkillaDTO
    {
        public int ApplicationId { get; set; }
        public int Direction { get; set; }
        public int Side { get; set; }
        public int LandscapeTypeId { get; set; }
        public string CharkillaName { get; set; }
        public int RoadId { get; set; }
        public bool IsGLD { get; set; }
        public string RoadLength { get; set; }
        public decimal ProposedROW { get; set; }
        public decimal ExistingROW { get; set; }
        public decimal ActualSetback { get; set; }
        public decimal StandardSetback { get; set; }
        public decimal Kitta { get; set; }
    }
}
