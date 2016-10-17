using System;
using System.Collections.Generic;

namespace Api.Models
{
    public class Authorization
    {
        public long Id { get; set; }
        public Guid Uid { get; set; }
        public string Path { get; set; }

        public virtual ICollection<UserAuthorization> UserAuthorization { get; set; } = new HashSet<UserAuthorization>();
    }
}
