using System;
using System.ComponentModel.DataAnnotations;

namespace Application.Models
{
    public class BaseResponse
    {
        [Required, StringLength(36)]
        public string Code { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public DateTimeOffset UpdatedAt { get; set; }

        public DateTimeOffset? DeletedAt { get; set; }

        public bool Active { get; set; }
    }
}
