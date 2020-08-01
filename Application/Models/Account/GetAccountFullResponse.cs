namespace Application.Models.Account
{
    public class GetAccountFullResponse : BaseResponse
    {
        public string Name { get; set; }

        public string MerchantCode { get; set; }

        public string PhoneCode { get; set; }

        public string AddressCode { get; set; }
    }
}