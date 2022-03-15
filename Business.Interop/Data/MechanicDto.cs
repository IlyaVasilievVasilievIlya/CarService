using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Business.Interop.Data
{
    public class MechanicDto
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        [DataType(DataType.Date)]
        [Display(Name="Date of birth")]
        [Required]
        public DateTime BirthDate { get; set; }

        [DataType(DataType.EmailAddress)]
        [Required]
        public string Email { get; set; }

        [Display(Name = "Phone number")] 
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{2})[-. ]?([0-9]{2})$", ErrorMessage = "Not a valid phone number")]
        [Required]
        public string PhoneNumber { get; set; }

        [Display(Name = "Possible works")]
        public IEnumerable<WorkTypeDto> WorkScope { get; set; }

        public IEnumerable<int> WorkScopeId { get; set; }
    }
}
