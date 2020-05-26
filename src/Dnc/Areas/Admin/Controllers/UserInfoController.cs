using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dnc.Service.Admin;
using Microsoft.AspNetCore.Mvc;
using UtilsSharp.Standard;

namespace Dnc.Areas.Admin.Controllers
{
    /// <summary>
    /// Admin控制器
    /// </summary>
    [Route("api/[area]/[controller]/[action]")]
    [Area("Admin")]
    [ApiController]
    public class UserInfoController : ControllerBase
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