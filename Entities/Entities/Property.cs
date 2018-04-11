using System;
namespace Loan.Entities
{
    public enum PropertyLocationState
    {
        NewYork = 1,
        Louisiana = 2,
        Mississippi = 3,
        Illinois = 4,
        Maine = 5,
        Texas  6,
        Missouri = 7,
        Kansas = 8,
        Alabama = 9
    }

    public class Property
    {
        public bool IsUnderKatrinaAssistance { get; set; }
        public BoundaryPoints FullLocation { get; set; }
        public string PlatteId { get; set; }
        public PropertyLocationState LocationState { get; set; }
    }
}
