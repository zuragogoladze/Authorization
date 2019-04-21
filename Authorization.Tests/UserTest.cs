using Authorization.Core.Interfaces;
using Authorization.WEB.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;

namespace Authorization.Tests
{
    [TestClass]
    public class UserTest
    {
        [TestMethod]
        [TestCategory("Unit")]
        public void GetUsers()
        {
            var mUsrSvc = new Mock<IUserResolver>();
            mUsrSvc
              .Setup(t => t.User)
              .Returns(new ClaimsPrincipal(new GenericIdentity("Zura")));
            var ctr = new UsersController(mUsrSvc.Object);
            var result = ctr.GetUser();
            Assert.AreEqual("Zura", result);
        }
    }
}
