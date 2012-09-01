using DomainApiNET.Misc;

namespace DomainApiNET.Enums
{
    public enum YesNo
    {
        Unknown,
        [StringValue("y")]
        Yes,
        [StringValue("n")]
        No
    }
}