using System.ComponentModel.DataAnnotations;

namespace Business.Interop.Data
{
    public class OrderPositionDto
    {
        public int Id { get; set; }

        public GarageOrderDto Order { get; set; }

        [Required]
        public int OrderId{ get; set; }

        public WorkDto Work { get; set; }
        
        [Display(Name = "Work")]
        [Required]
        public int WorkId { get; set; }

        public MechanicDto Mechanic { get; set; }

        [Required]
        [Display(Name = "Mechanic")]
        public int MechanicId { get; set; }

        [Required]
        [Range(1, 100)]
        public int Count { get; set; }

    }
}
