using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interop.Data
{
    public class GarageOrderDto
    {
        [Display(Name = "Order Number")]
        public int Id { get; set; }
        public ClientCarDto ClientCar { get; set; }
       
        public int ClientCarId { get; set; }  
        
        [Display(Name = "Total Price")]
        public int TotalSum { get; set; }
    }
}
