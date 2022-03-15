using System.Collections.Generic;
using System.Linq;

namespace Business.Entities
{
    public class GarageOrder
    {
        public int Id { get; set; }
        public ClientCar ClientCar { get; set; }
        public int ClientCarId { get; set; }
        public IEnumerable<OrderPosition> Positions { get; set; } = new HashSet<OrderPosition>();
        public int TotalSum => Positions.Select((p) => p.Work.Price* p.Count).Sum(); 
    }
}
