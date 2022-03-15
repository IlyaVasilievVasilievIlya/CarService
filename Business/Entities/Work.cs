using System;

namespace Business.Entities
{
    public class Work
    {
        public int Id { get; set; }     
        public string Name { get; set; }
        public WorkType WorkType { get; set; }
        public int WorkTypeId { get; set; }
        public int Price { get; set; }
        public TimeSpan Duration { get; set; }
        public string Description { get; set; }
    }
}
