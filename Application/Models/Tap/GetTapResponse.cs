namespace Application.Models.Tap
{
    public class GetTapResponse : BaseResponse
    {
        public string Name { get; set; }

        /// <summary>
        /// Web location URL of the tap's server
        /// </summary>
        public string TargetUrl { get; set; }

        public int AddressId { get; set; }
    }
}