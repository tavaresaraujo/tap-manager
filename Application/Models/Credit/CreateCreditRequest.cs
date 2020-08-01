using System.ComponentModel.DataAnnotations;

namespace Application.Models.Credit
{
    public class CreateCreditRequest
    {
        [Required]
        public int Amount { get; set; }
    }
}