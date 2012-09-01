namespace DomainApiNET.Objects.Errors
{
    public class ValidatorError
    {
        public string Message { get; set; }
        public string ValueError { get; set; }
        public int Code { get; set; }
    }
}