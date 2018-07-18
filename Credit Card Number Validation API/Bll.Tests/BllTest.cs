using Moq;
using NUnit.Framework;
using System;
using System.Globalization;
using Wasenshi.CreditCard.BLL;
using Wasenshi.CreditCard.DAL.Interfaces;
using Wasenshi.CreditCard.Libs.Enums;
using Wasenshi.CreditCard.Libs.Models;

namespace Bll.Tests
{
    [TestFixture]
    public class BllTest
    {
        private Mock<ICreditCardRepository> _repo;
        private CreditCardBll _bll;
        private Card _card;


        [SetUp]
        public void Setup()
        {
            _repo = new Mock<ICreditCardRepository>();
            _bll = new CreditCardBll(_repo.Object);
            _card = new Card { Number = "1234", ExpiryDate = DateTime.UtcNow.AddYears(10) };

            _repo.Setup(c => c.CheckCardNumberExist(It.IsAny<string>()))
                .Returns(true);
        }

        [Test]
        public void Wrong_Format_CardNumber()
        {
            var result = _bll.ValidateCreditCard(_card);

            Assert.AreEqual(CardTypeEnum.Unknown, result.CardType);
            Assert.AreEqual(ResultType.Invalid, result.Result);
        }

        [Test]
        public void Does_Not_Exist_CardNumber()
        {
            _repo.Setup(c => c.CheckCardNumberExist(It.IsAny<string>()))
                .Returns(false);
            _card.Number = "4123456789012345";


            var result = _bll.ValidateCreditCard(_card);

            Assert.AreEqual(CardTypeEnum.Visa, result.CardType);
            Assert.AreEqual(ResultType.DoesNotExist, result.Result);
        }

        [Test]
        public void ValidVisa()
        {
            // Define a leap year (multiple of 4, but not 100, or multiple of 400)
            var leapYear = DateTime.Parse("1/1/2400", CultureInfo.InvariantCulture);
            Assert.IsTrue(DateTime.IsLeapYear(leapYear.Year), "If this is not true, it means current date and year is geater than the parsed string.");

            _card.ExpiryDate = leapYear;
            _card.Number = "4123456789012345";

            var result = _bll.ValidateCreditCard(_card);

            Assert.AreEqual(CardTypeEnum.Visa, result.CardType);
            Assert.AreEqual(ResultType.Valid, result.Result);
        }

        [Test]
        public void ValidMaster()
        {
            // Define a prime number year
            var primeYear = DateTime.Parse("1/1/2411", CultureInfo.InvariantCulture);

            _card.ExpiryDate = primeYear;
            _card.Number = "5123456789012345";

            var result = _bll.ValidateCreditCard(_card);

            Assert.AreEqual(CardTypeEnum.Master, result.CardType);
            Assert.AreEqual(ResultType.Valid, result.Result);
        }

        [Test]
        public void ValidAmex()
        {

            _card.Number = "312345678901234";

            var result = _bll.ValidateCreditCard(_card);

            Assert.AreEqual(CardTypeEnum.Amex, result.CardType);
            Assert.AreEqual(ResultType.Valid, result.Result);
        }

        [Test]
        public void ValidJCB()
        {

            _card.Number = "3123456789012345";

            var result = _bll.ValidateCreditCard(_card);

            Assert.AreEqual(CardTypeEnum.JCB, result.CardType);
            Assert.AreEqual(ResultType.Valid, result.Result);
        }

        [Test]
        public void InvalidVisa()
        {
            // Define a leap year (multiple of 4, but not 100, or multiple of 400)
            var leapYear = DateTime.Parse("1/1/2400", CultureInfo.InvariantCulture);
            Assert.IsTrue(DateTime.IsLeapYear(leapYear.Year), "If this is not true, it means current date and year is geater than the parsed string.");

            _card.ExpiryDate = leapYear;
            _card.Number = "4123456789012345555555";

            var result = _bll.ValidateCreditCard(_card);

            Assert.AreEqual(CardTypeEnum.Visa, result.CardType);
            Assert.AreEqual(ResultType.Invalid, result.Result);

            _card.ExpiryDate = leapYear.AddYears(1);
            _card.Number = "4123456789012345";

            result = _bll.ValidateCreditCard(_card);

            Assert.AreEqual(CardTypeEnum.Visa, result.CardType);
            Assert.AreEqual(ResultType.Invalid, result.Result);
        }

        [Test]
        public void InvalidMaster()
        {
            // Define a prime number year
            var primeYear = DateTime.Parse("1/1/2411", CultureInfo.InvariantCulture);

            _card.ExpiryDate = primeYear;
            _card.Number = "512345678";

            var result = _bll.ValidateCreditCard(_card);

            Assert.AreEqual(CardTypeEnum.Master, result.CardType);
            Assert.AreEqual(ResultType.Invalid, result.Result);

            _card.Number = "5123456789012345";
            _card.ExpiryDate = primeYear.AddYears(1);

            result = _bll.ValidateCreditCard(_card);

            Assert.AreEqual(CardTypeEnum.Master, result.CardType);
            Assert.AreEqual(ResultType.Invalid, result.Result);

        }

        [Test]
        public void InvalidAmex()
        {
            //Because Amex has no validation logic other than digit number
            //Making digit number longer would result in JCB (if 16, otherwise, Unknown if digit is not 15 or 16)
            //The only way to make it invalid is to use wrong format number
            _card.Number = "31234567f901234";

            var result = _bll.ValidateCreditCard(_card);

            //Expected to be Unknown because we check first if the number is legit (contain only numbers)
            Assert.AreEqual(CardTypeEnum.Unknown, result.CardType);
            Assert.AreEqual(ResultType.Invalid, result.Result);

            //Test shorter than expected would also result in Unknown card
            _card.Number = "312345674901";

            result = _bll.ValidateCreditCard(_card);

            Assert.AreEqual(CardTypeEnum.Unknown, result.CardType);
            Assert.AreEqual(ResultType.Invalid, result.Result);
        }

        [Test]
        public void InvalidJCB()
        {
            //Because JCB is always valid
            //The only way to make it invalid is to use wrong format number
            _card.Number = "31234h6789012345";

            var result = _bll.ValidateCreditCard(_card);

            Assert.AreEqual(CardTypeEnum.Unknown, result.CardType);
            Assert.AreEqual(ResultType.Invalid, result.Result);
        }
    }
}
