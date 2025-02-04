namespace eBPS.Application.DTOs.BuildingApplication
{
    public class CharkillaDTO
    {
        public int? ApplicationId { get; set; }
        public int Direction { get; set; }
        public int Side { get; set; }
        public int LandscapeType { get; set; }
        public string CharkillaName { get; set; }
        public int RoadId { get; set; }
        public bool? IsGLD { get; set; }
        public double RoadLength { get; set; }
        public double ProposedRow { get; set; }
        public double ExistingRow { get; set; }
        public double ActualSetback { get; set; }
        public double StandardSetback { get; set; }
        public string Kitta { get; set; }
    }

}
