using System.Collections.Generic;

namespace Api.Models
{
    public class Users
    {
        public long Id { get; set; }
        public string Identifier { get; set; }

        public virtual ICollection<UserAuthorization> UserAuthorization { get; set; } = new HashSet<UserAuthorization>();
    }
}
