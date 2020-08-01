using System.ComponentModel.DataAnnotations;

namespace Application.Models.Phone
{
    public class UpdatePhoneRequest
    {
        [StringLength(128)]
        public string Discription { get; set; }

        [StringLength(13)]
        public string Number { get; set; }
    }
}