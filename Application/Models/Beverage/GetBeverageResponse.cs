namespace Application.Models.Beverage
{
    public class GetBeverageResponse : BaseResponse
    {
        public string Name { get; set; }

        public int AchoolPercentage { get; set; }

        /// <summary>
        /// What contry is
        /// </summary>
        public string Origin { get; set; }

        public string Description { get; set; }

        public string PictureUrl { get; set; }
    }
}
