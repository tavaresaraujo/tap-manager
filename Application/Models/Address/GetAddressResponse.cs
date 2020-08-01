namespace Application.Models.Address
{
    public class GetAddressResponse : BaseResponse
    {
        public int Number { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Neighborhood { get; set; }
        public string Zip { get; set; }
        public string Country { get; set; }
    }
}