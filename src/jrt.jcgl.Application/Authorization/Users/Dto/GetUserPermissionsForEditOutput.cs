﻿using System.Collections.Generic;
using Abp.Application.Services.Dto;
using jrt.jcgl.Authorization.Dto;

namespace jrt.jcgl.Authorization.Users.Dto
{
    public class GetUserPermissionsForEditOutput : IOutputDto
    {
        public List<FlatPermissionDto> Permissions { get; set; }

        public List<string> GrantedPermissionNames { get; set; }
    }
}