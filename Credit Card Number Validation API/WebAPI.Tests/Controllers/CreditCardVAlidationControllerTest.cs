using Moq;
using NUnit.Framework;
using System;
using System.Net;
using System.Threading;
using System.Web.Http;
using Wasenshi.CreditCard.BLL.Interfaces;
using Wasenshi.CreditCard.Libs.Enums;
using Wasenshi.CreditCard.Libs.Models;
using Wasenshi.CreditCard.WebAPI.Controllers;

namespace WebAPI.Tests.Controllers
{
    [TestFixture]
    public class CreditCardValidationControllerTest
    {
        //private Mock<ICreditCardRepository> _repo;
        private Mock<ICreditCardBll> _bll;
        private CreditCardValidationController _controller;
        private Card _card;

        [SetUp]
        public void Setup()
        {
            _bll = new Mock<ICreditCardBll>();
            _controller = new CreditCardValidationController(_bll.Object);
            _controller.Request = new System.Net.Http.HttpRequestMessage();
            _controller.Configuration = new HttpConfiguration();
            _card = new Card { Number = "1234", ExpiryDate = DateTime.UtcNow.AddYears(10) };

            
        }

        [Test]
        public void ValidateCardAction_Must_Return_200_With_ValidateResult_Valid()
        {
            _bll.Setup(c => c.ValidateCreditCard(It.IsAny<Card>()))
                .Returns(ValidateResult.New(ResultType.Valid, CardTypeEnum.Unknown));
            IHttpActionResult result = _controller.ValidateCard(_card);
            var response = result.ExecuteAsync(CancellationToken.None).Result;
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [Test]
        public void ValidateCardAction_Must_Return_400_With_ValidateResult_Invalid()
        {
            _bll.Setup(c => c.ValidateCreditCard(It.IsAny<Card>()))
                .Returns(ValidateResult.New(ResultType.Invalid, CardTypeEnum.Unknown));
            IHttpActionResult result = _controller.ValidateCard(_card);
            var response = result.ExecuteAsync(CancellationToken.None).Result;
            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Test]
        public void ValidateCardAction_Must_Return_404_With_ValidateResult_DoesNotExist()
        {
            _bll.Setup(c => c.ValidateCreditCard(It.IsAny<Card>()))
                .Returns(ValidateResult.New(ResultType.DoesNotExist, CardTypeEnum.Unknown));
            IHttpActionResult result = _controller.ValidateCard(_card);
            var response = result.ExecuteAsync(CancellationToken.None).Result;
            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
        }
    }
}
