using System.Threading.Tasks;
using jrt.jcgl.Authorization.Roles;
using Shouldly;
using Xunit;

namespace jrt.jcgl.Tests.Authorization.Roles
{
    public class RoleAppService_Tests : AppTestBase
    {
        private readonly IRoleAppService _roleAppService;

        public RoleAppService_Tests()
        {
            _roleAppService = Resolve<IRoleAppService>();
        }

        [Fact]
        public async Task Should_Get_Roles_For_Host()
        {
            LoginAsHostAdmin();

            //Act
            var output = await _roleAppService.GetRoles();

            //Assert
            output.Items.Count.ShouldBe(1);
        }

        [Fact]
        public async Task Should_Get_Roles_For_Tenant()
        {
            //Act
            var output = await _roleAppService.GetRoles();

            //Assert
            output.Items.Count.ShouldBe(2);
        }
    }
}
