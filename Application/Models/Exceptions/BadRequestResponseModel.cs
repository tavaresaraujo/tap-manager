namespace Application.Models.Exceptions
{
    public class UnprocessableEntityResponseModel
    {

        /// <summary>
        /// Nome da propriedade.
        /// </summary>
        public string Property { get; set; }

        /// <summary>
        /// Erros.
        /// </summary>
        public string[] Errors { get; set; }
    }
}
