using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Dnc.Application.Contracts.Logins;
using Dnc.Application.Contracts.Users;
using Dnc.Application.Contracts.Users.DTOs;
using UtilsSharp.Logger;
using UtilsSharp.Standard;

namespace Dnc.Application.Users
{
    /// <summary>
    /// 用户信息服务
    /// </summary>
    public class UserAppService: IUserAppService
    {
        private readonly IRecordAppService _recordAppService;

        public UserAppService(IRecordAppService recordAppService)
        {
            _recordAppService = recordAppService;
        }

        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <returns></returns>
        public async ValueTask<BaseResult<UserResponse>> GetAsync()
        {
            var result=new BaseResult<UserResponse>();
            LogHelper.Info("我进来咯");
            //查询数据库.....
            //if (false)
            //{
            //    result.SetError("未查询到该条记录");
            //    return result;
            //}
            await Task.Delay(1000);//模拟执行1秒
            var r = await _recordAppService.GetRecordAsync();
            if (r.Code != 200)
            {
                result.SetError(r.Msg,r.Code);
                return result;
            }
            result.Result = new UserResponse { UserName = "Agoling", Mobile = "136xxxxxxxx", Age = 10, LoginCount = r.Result};
            return result;
        }
    }
}
