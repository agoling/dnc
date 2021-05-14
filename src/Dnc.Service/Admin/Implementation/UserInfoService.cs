using System;
using System.Collections.Generic;
using System.Text;
using Logger;
using UtilsSharp.Standard;

namespace Dnc.Service.Admin.Implementation
{
    /// <summary>
    /// 用户信息服务
    /// </summary>
    public class UserInfoService: IUserInfoService
    {
        private readonly IPayRecordService _payRecordService;

        public UserInfoService(IPayRecordService payRecordService)
        {
            _payRecordService = payRecordService;
        }

        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <returns></returns>
        public BaseResult<UserInfo> Get()
        {
            var result=new BaseResult<UserInfo>();
            LogHelper.Info("我是测试日志");
            //查询数据库.....
            //if (false)
            //{
            //    result.SetError("未查询到该条记录");
            //    return result;
            //}
            var r = _payRecordService.GetRecord();
            if (r.Code != 200)
            {
                result.SetError(r.Msg,r.Code);
                return result;
            }
            result.Result = new UserInfo {UserName = "Agoling", Mobile = "136xxxxxxxx", Age = 10, PayCount = r.Result};
            return result;
        }
    }
}
