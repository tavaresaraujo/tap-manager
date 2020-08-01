namespace Application.Models.Beverage
{
    public class CreateBeveragePriceRequest
    {
        public int Amount { get; set; }

        //Todo pegar a conta do header
        public string AccountCode { get; set; }

        internal int BeverageId { get; set; }

        internal int AccountId { get; set; }
    }
}