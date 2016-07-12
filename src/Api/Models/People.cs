using System;
using System.Collections.Generic;

namespace Api.Models
{
    public partial class People
    {
        public long Id { get; set; }
        public Guid Uid { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string Ssn { get; set; }
        public string Race { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public DateTime Birthdate { get; set; }
    }
}
