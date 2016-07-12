using System;
using System.Collections.Generic;

namespace Api.Models
{
    public partial class Districts
    {
        public long Id { get; set; }
        public Guid Uid { get; set; }
        public string Name { get; set; }
    }
}
