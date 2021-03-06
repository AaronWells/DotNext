﻿namespace Models
{
    public class UserAuthorization
    {
        public long UserId { get; set; }
        public long AuthorizationId { get; set; }
        public long Permissions { get; set; }

        public virtual Authorization Authorization { get; set; }
        public virtual Users User { get; set; }
    }
}
