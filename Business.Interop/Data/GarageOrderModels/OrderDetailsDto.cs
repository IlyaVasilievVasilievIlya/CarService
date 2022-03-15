using Business.Interop.Data.OrderPositionModels;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Business.Interop.Data.GarageOrderModels
{
    public class OrderDetailsDto
    {
        [Display(Name = "Order Number")]
        public int Id { get; set; }
        public ClientCarDto ClientCar { get; set; }

        public int ClientCarId { get; set; }

        [Display(Name = "Total Price")]
        public int TotalSum { get; set; }

        public IEnumerable<OrderPositionDetailsDto> Positions { get; set; }
    }
}
