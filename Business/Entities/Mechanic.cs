using System;
using System.Collections.Generic;

namespace Business.Entities
{
    public class Mechanic
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public IEnumerable<WorkType> WorkScope { get; set; } = new HashSet<WorkType>();
    }
}
