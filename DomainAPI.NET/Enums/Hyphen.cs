using DomainApiNET.Misc;

namespace DomainApiNET.Enums
{
    public enum Hyphen
    {
        Unknown,

        [StringValue("c")]
        WithAndWithout,

        [StringValue("n")]
        Without,

        [StringValue("y")]
        With
    }
}