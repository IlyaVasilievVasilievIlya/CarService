﻿using System.Collections.Generic;


namespace Business.Entities
{
    public class Client
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public IEnumerable<ClientCar> Cars { get; set; }
    }
}
