namespace DomainApiNET.Objects.Errors
{
    public class ParameterError
    {
        public string Name { get; set; }
        public ValidatorError ValidatorError { get; set; }
    }
}