namespace Application.Models.Supply
{
    public class GetSupplyResponse : BaseResponse
    {
        public int Volume { get; set; }

        public string TapCode { get; set; }
    }
}