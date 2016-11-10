using Abp.Application.Services;
using Abp.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMTest.IM.Dto;
using Abp.Domain.Repositories;
using IMTest.Core.IM.IMUsers;
using Abp.AutoMapper;
namespace IMTest.IM
{
    [AbpAuthorize]
    public class IMUserAppService : ApplicationService, IIMUserAppService
    {
        //private readonly IRepository<IMUser,long> _imuserRepositoty;
        private readonly IRepository<IMUser,long> _imuserRepositoty;
        public IMUserAppService(/*IRepository<IMUser, long> imuserRepositoty*/
            IRepository<IMUser, long> imuserRepositoty
            )
        {
            _imuserRepositoty = imuserRepositoty;
        }

        public void IMRegister(IMRegisterInput input)
        {
            IMUser imuser = new IMUser
            {
                //Id = 1,
                Id = input.UserId,
                test = 100,
                NickName = input.Name,
                PassWord = input.Password,
                Role = input.Role,
                AppKey = input.Appkey,
                CreateTime = DateTime.Now,
                UserType=(int)IMUserType.Normal
            };
            try
            {
                _imuserRepositoty.Insert(imuser);
            }
            catch (Exception e)
            {
                string message =e.ToString();
            }
        }

        public async Task IMUpdate(IMUpdateUserInfoInput input)
        {
            var user = await _imuserRepositoty.GetAsync(input.Id);

            //input.MapTo<IMUser>();

            await _imuserRepositoty.UpdateAsync(input.MapTo<IMUser>());
        }

        //public List<IMUserDto> IMGetUser()
        //{

        //}
    }
}
