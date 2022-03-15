using System;
using System.ComponentModel.DataAnnotations;

namespace Business.Interop.Data
{
    public class WorkDto
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        [Display(Name = "Work type")]
        public WorkTypeDto WorkType { get; set; }

        [Required]
        public int WorkTypeId { get; set; }

        [Range(1, int.MaxValue)]
        [DataType(DataType.Currency)]
        [Required]
        public int Price { get; set; }

        [DisplayFormat(DataFormatString =@"{dd:hh\:mm}")]
        [DataType(DataType.Duration)]
        [Required]
        public TimeSpan Duration { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Description { get; set; }

    }
}
