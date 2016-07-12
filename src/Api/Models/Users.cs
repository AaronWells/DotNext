using System;
using System.Collections.Generic;

namespace Api.Models
{
    public partial class Users
    {
        public Users()
        {
            UserAuthorization = new HashSet<UserAuthorization>();
        }

        public long Id { get; set; }
        public string Identifier { get; set; }

        public virtual ICollection<UserAuthorization> UserAuthorization { get; set; }
    }
}
