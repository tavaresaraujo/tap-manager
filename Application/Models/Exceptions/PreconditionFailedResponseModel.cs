namespace Application.Models.Exceptions
{
    public class PreconditionFailedResponseModel
    {

        /// <summary>
        /// Error code.
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Error message.
        /// </summary>
        public string Message { get; set; }
    }
}
