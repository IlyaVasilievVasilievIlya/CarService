using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interop.Data
{
    public class CarDto
    {
        public int Id { get; set; }
        public CarModelDto Model { get; set; }
        public int ModelId { get; set; }
        public int ManufactureYear { get; set; }
    }
}
