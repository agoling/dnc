using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Dnc.Application.Contracts.Users.DTOs;
using UtilsSharp.Dependency;
using UtilsSharp.Standard;

namespace Dnc.Application.Contracts.Users
{
    /// <summary>
    /// 用户信息服务
    /// </summary>
    public interface IUserAppService : IUnitOfWorkDependency
    {
        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <returns></returns>
        ValueTask<BaseResult<UserResponse>> GetAsync();
    }
}
