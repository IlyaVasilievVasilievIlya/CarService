namespace Business.Interop.Data.OrderPositionModels
{
    public class OrderPositionDetailsDto
    {
        public int Id { get; set; }
        public WorkDto Work { get; set; }
        public int WorkId { get; set; }
        public MechanicDto Mechanic { get; set; }
        public int MechanicId { get; set; }
        public int Count { get; set; }
    }
}
