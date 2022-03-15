
using System.ComponentModel.DataAnnotations;

namespace Business.Interop.Data
{
    public class ClientCarDto
    {
        public int Id { get; set; }

        [Display(Name = "Client")]
        public ClientDto Client { get; set; }
        
        [Required]
        public int ClientId { get; set; }

        [Display(Name = "Car")]
        public CarDto Car { get; set; }
        
        [Required]
        public int CarId { get; set; }
    }
}
