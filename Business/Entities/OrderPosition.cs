namespace Business.Entities
{
    public class OrderPosition
    {
        public int Id { get; set; }

        public GarageOrder Order { get; set; }
        public int OrderId { get; set; }

        public Work Work { get; set; }
        public int WorkId { get; set; }

        public Mechanic Mechanic { get; set; }
        public int MechanicId { get; set; }

        public int Count { get; set; }
    }
}
