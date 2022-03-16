using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class Car
    {
        public int Id { get; set; }
        public CarModel Model { get; set; }

        public int ModelId { get; set; }
        public int ManufactureYear { get; set; }
    }
}
