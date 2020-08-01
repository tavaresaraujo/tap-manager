namespace Application.Models.Beverage
{
    public class GetBeveragePriceResponse : BaseResponse
    {
        public int Amount { get; set; }

        public string AccountCode { get; set; }

        internal string BeverageCode { get; set; }
    }
}