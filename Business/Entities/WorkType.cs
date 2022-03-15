using System.Collections.Generic;

namespace Business.Entities
{
    public class WorkType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Mechanic> Mechanics { get; set; } = new HashSet<Mechanic>();
    }
}
