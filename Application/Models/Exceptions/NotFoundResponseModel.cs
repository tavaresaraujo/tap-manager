namespace Application.Models.Exceptions
{
    public class NotFoundResponseModel
    {

        /// <summary>
        /// String representing the object’s type.
        /// </summary>
        public string Object { get; set; }

        /// <summary>
        /// Error message.
        /// </summary>
        public string Message { get; set; }
    }
}
