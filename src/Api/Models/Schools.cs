using System;

namespace Api.Models
{
    public partial class Schools
    {
        public long Id { get; set; }
        public Guid Uid { get; set; }
        public string Name { get; set; }
    }
}
