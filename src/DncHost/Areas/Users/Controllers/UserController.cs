using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Dnc.Application.Contracts.Users;
using Dnc.Application.Contracts.Users.DTOs;
using UtilsSharp.AspNetCore.MVC;
using UtilsSharp.Standard;

namespace DncHost.Areas.Users.Controllers
{
    /// <summary>
    /// 用户控制器
    /// </summary>
    [ApiExplorerSettings(GroupName = "Users")]
    [Area("Users")]
    public class UserController : BaseAreaController
    {
        private readonly IUserAppService _userAppService;

        public UserController(IUserAppService userAppService)
        {
            _userAppService = userAppService;
        }

        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async ValueTask<BaseResult<UserResponse>> Get()
        {
           return await _userAppService.GetAsync();
        }
    }
}
