namespace Business.Entities
{
    public class ClientCar
    {
        public int Id { get; set; }
        public Client Client { get; set; }
        public int ClientId { get; set; }
        public Car Car { get; set; }
        public int CarId { get; set; }
    }
}
