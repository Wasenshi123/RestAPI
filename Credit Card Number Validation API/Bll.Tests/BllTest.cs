using Moq;
using NUnit.Framework;
using System;
using Wasenshi.CreditCard.BLL;
using Wasenshi.CreditCard.DAL.Interfaces;
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
        }

        [Test]
        public void ValidVisa()
        {
            // Define a leap year (multiple of 4, but not 100, or multiple of 400)
            var leapYear = DateTime.Parse("1/1/2400");
            Assert.IsTrue(DateTime.IsLeapYear(leapYear.Year));

        }
    }
}
