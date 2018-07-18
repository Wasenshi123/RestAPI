using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Wasenshi.CreditCard.Libs.Enums;

namespace Wasenshi.CreditCard.Libs.Models
{
    public class ValidateResult
    {
        public ResultType Result { get; set; }
        public CardTypeEnum CardType { get; set; }
    }
}