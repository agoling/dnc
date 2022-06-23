using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UtilsSharp.Dependency;
using UtilsSharp.Standard;

namespace Dnc.Application.Contracts.Logins
{
    /// <summary>
    /// 登入记录服务
    /// </summary>
    public interface IRecordAppService: IUnitOfWorkDependency
    {
        /// <summary>
        /// 获取记录条数
        /// </summary>
        /// <returns></returns>
        ValueTask<BaseResult<int>> GetRecordAsync();
    }
}
