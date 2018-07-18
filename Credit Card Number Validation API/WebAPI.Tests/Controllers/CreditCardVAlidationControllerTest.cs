using Moq;
using NUnit.Framework;
using Wasenshi.CreditCard.BLL.Interfaces;
using Wasenshi.CreditCard.DAL.Interfaces;
using Wasenshi.CreditCard.WebAPI.Controllers;

namespace WebAPI.Tests.Controllers
{
    [TestFixture]
    public class CreditCardValidationControllerTest
    {
        //private Mock<ICreditCardRepository> _repo;
        private Mock<ICreditCardBll> _bll;
        private CreditCardValidationController _controller;

        [SetUp]
        public void Setup()
        {
            _bll = new Mock<ICreditCardBll>();
            _controller = new CreditCardValidationController(_bll.Object);
            _controller.Request = new System.Net.Http.HttpRequestMessage();
        }

        [Test]
        public void ValidateCardAction_Must_Return_200_With_ValidateResult_Valid()
        {
            
        }

        [Test]
        public void ValidateCardAction_Must_Return_400_With_ValidateResult_Invalid()
        {

        }

        [Test]
        public void ValidateCardAction_Must_Return_404_With_ValidateResult_DoesNotExist()
        {

        }
    }
}
