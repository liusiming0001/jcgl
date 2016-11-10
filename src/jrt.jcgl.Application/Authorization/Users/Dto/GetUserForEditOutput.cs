﻿using System;
using Abp.Application.Services.Dto;

namespace jrt.jcgl.Authorization.Users.Dto
{
    public class GetUserForEditOutput : IOutputDto
    {
        public Guid? ProfilePictureId { get; set; }

        public UserEditDto User { get; set; }

        public UserRoleDto[] Roles { get; set; }
    }
}