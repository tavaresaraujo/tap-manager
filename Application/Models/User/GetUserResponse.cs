namespace Application.Models.User
{
    public class GetUserResponse : BaseResponse
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public int AddressId { get; set; }

        public int PhoneId { get; set; }
    }
}