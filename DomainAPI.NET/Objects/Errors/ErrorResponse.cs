namespace DomainApiNET.Objects.Errors
{
    public class ErrorResponse : APIHeader
    {
        public Error Error { get; set; }
    }
}