using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DateService.Logic;
using DateService.Models;
using DateService.Services;
using Moq;
using NUnit.Framework;

namespace DateService.Tests.Logic
{
    [TestFixture]
    public class UserLogicTests
    {
        private Mock<IDateService> _dateServiceMock;

        private UserLogic Create()
        {
            _dateServiceMock = new Mock<IDateService>();

            return new UserLogic(_dateServiceMock.Object);
        }

        [Test]
        public void Update_SetUpdatedDate()
        {
            var userLogic = Create();

            _dateServiceMock.Setup(u => u.Now)
                .Returns(new DateTime(2017, 1, 1));

            var user = userLogic.Update(new User());

            Assert.AreEqual(new DateTime(2017, 1, 1), user.UpdatedDate);
        }
    }
}
