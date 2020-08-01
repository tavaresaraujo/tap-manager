namespace Application.Models.Account
{
    public class GetAccountResponse : BaseResponse
    {
        public string Name { get; set; }

        public string MerchantCode { get; set; }

        public string PhoneCode { get; set; }

        public string AddressCode { get; set; }
    }
}