using Abp.Application.Services;
using IMTest.IM.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMTest.IM
{
    public interface IIMUserAppService: IApplicationService
    {
        void IMRegister(IMRegisterInput input);

        Task IMUpdate(IMUpdateUserInfoInput input);

        //List<IMUserDto> IMGetUser();
    }
}
