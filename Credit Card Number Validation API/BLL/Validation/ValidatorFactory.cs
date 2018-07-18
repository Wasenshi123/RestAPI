using Wasenshi.CreditCard.BLL.Validation.ValidatorUnits;
using Wasenshi.CreditCard.Libs.Enums;

namespace Wasenshi.CreditCard.BLL.Validation
{
    public static class ValidatorFactory
    {
        public static ValidatorUnit GetValidator(CardTypeEnum cardType)
        {
            switch (cardType)
            {
                case CardTypeEnum.Visa:
                    return new VisaValidator();
                case CardTypeEnum.Master:
                    return new MasterValidator();
                case CardTypeEnum.Amex:
                    return new AmexValidator();
                case CardTypeEnum.JCB:
                    return new JCBValidator();
                case CardTypeEnum.Unknown:
                default:
                    return null;
            }
        }
    }
}
