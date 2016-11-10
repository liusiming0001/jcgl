using jrt.jcgl.Dto;

namespace jrt.jcgl.Common.Dto
{
    public class FindUsersInput : PagedAndFilteredInputDto
    {
        public int? TenantId { get; set; }
    }
}