using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCore.MVC;
using Dnc.Service.Admin;
using Microsoft.AspNetCore.Mvc;
using UtilsSharp.Standard;

namespace Dnc.Areas.Admin.Controllers
{
    /// <summary>
    /// Admin控制器
    /// </summary>
    [ApiExplorerSettings(GroupName = "admin")]
    [Area("Admin")]
    public class UserInfoController :BaseAreaController
    {

        private readonly IUserInfoService _userInfoService;

        public UserInfoController(IUserInfoService userInfoService)
        {
            _userInfoService = userInfoService;
        }

        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public BaseResult<UserInfo> Get()
        {
            return _userInfoService.Get();
        }
    }
}