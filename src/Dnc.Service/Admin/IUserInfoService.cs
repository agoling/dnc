using System;
using System.Collections.Generic;
using System.Text;
using UtilsSharp.Dependency;
using UtilsSharp.Standard;

namespace Dnc.Service.Admin
{
    /// <summary>
    /// 用户信息服务
    /// </summary>
    public interface IUserInfoService : IUnitOfWorkDependency
    {
        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <returns></returns>
        BaseResult<UserInfo> Get();
    }

    /// <summary>
    /// 用户信息
    /// </summary>
    public class UserInfo
    {
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { set; get; }
        /// <summary>
        /// 手机号
        /// </summary>
        public string Mobile { set; get; }
        /// <summary>
        /// 年龄
        /// </summary>
        public int Age { set; get; }
        /// <summary>
        /// 支付条数
        /// </summary>
        public int PayCount { set; get; }
    }
}
