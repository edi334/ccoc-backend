using System.Runtime.Serialization;

namespace CCOCBackend.API.Stacks.MenuItems;
public enum MenuItemType
{
    [EnumMember(Value = "0")]
    InternalLink,
    [EnumMember(Value = "1")]
    ExternalLink,
    [EnumMember(Value = "2")]
    Parent,
}