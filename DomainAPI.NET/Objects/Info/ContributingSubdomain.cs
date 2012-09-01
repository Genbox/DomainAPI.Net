namespace DomainApiNET.Objects.Info
{
    public class ContributingSubdomain
    {
        public TimeRange TimeRange { get; set; }
        public string DataUrl { get; set; }
        public PageViews PageViews { get; set; }
        public Reach Reach { get; set; }
    }
}