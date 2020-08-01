using System;

namespace Domain
{
    public class BaseEntity
    {
        public int Id { get; set; }

        public string Code { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public DateTimeOffset UpdatedAt { get; set; }

        public DateTimeOffset? DeletedAt { get; set; }

        public bool Active { get; set; }
    }
}