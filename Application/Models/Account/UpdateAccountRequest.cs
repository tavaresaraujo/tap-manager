using System.ComponentModel.DataAnnotations;

namespace Application.Models.Account
{
    public class UpdateAccountRequest
    {
        [Required, StringLength(100)]
        public string Name { get; set; }
    }
}