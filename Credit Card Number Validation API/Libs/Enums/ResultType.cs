using System.Runtime.Serialization;

namespace Wasenshi.CreditCard.Libs.Enums
{
    public enum ResultType
    {
        Valid,
        Invalid,
        [EnumMember(Value = "Does Not Exist")]
        DoesNotExist
    }
}