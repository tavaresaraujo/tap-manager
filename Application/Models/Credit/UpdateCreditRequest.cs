using System.ComponentModel.DataAnnotations;

namespace Application.Models.Credit
{
    public class UpdateCreditRequest
    {
        [Required]
        public int Amount { get; set; }

        [Required]
        public int UserId { get; set; }
    }
}