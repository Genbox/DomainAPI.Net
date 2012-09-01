namespace DomainApiNET.Objects
{
    public abstract class APIHeader
    {
        public string Service { get; set; }
        public string Domain { get; set; }
        public string Timestamp { get; set; }
    }
}
