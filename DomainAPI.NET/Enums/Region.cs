using DomainApiNET.Misc;

namespace DomainApiNET.Enums
{
    public enum Region
    {
        None,
        [StringValue("eu")]
        Europe,
        [StringValue("aeu")]
        Oceania,
        [StringValue("gen")]
        Generic,
        [StringValue("asia")]
        Asia,
        [StringValue("americas")]
        America,
        [StringValue("africa")]
        Africa
    }
}