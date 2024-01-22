
namespace Core.Entities
{
    public class TechnicalSpecification: BaseEntity
    {
        public string CPU { get; set; }
        public string GPU { get; set; }
        public string RAM { get; set; }
        public string Storage { get; set; }
        public string MaxResolution { get; set; }
        public int MaxFPS { get; set; }
    }
}