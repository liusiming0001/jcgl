using Microsoft.VisualStudio.TestTools.UnitTesting;
using IMTest.IM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMTest.IM.Dto;
namespace IMTest.IM.Tests
{
    [TestClass()]
    public class IMUserAppServiceTests
    {
        private readonly IMUserAppService _imUserAppService;

        public IMUserAppServiceTests(IMUserAppService imUserAppService)
        {
            _imUserAppService = imUserAppService;
        }

        [TestMethod()]
        public void IMUpdateTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void IMRegisterTest()
        {
            IMRegisterInput input = new IMRegisterInput
            {
                UserId=0,

            };

            //_imUserAppService.IMRegister();
            Assert.Fail();
        }
    }
}