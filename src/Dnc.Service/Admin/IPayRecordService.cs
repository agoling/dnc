using System;
using System.Collections.Generic;
using System.Text;
using UtilsSharp.Dependency;
using UtilsSharp.Standard;

namespace Dnc.Service.Admin
{
    /// <summary>
    /// 支付记录服务
    /// </summary>
    public interface IPayRecordService : IUnitOfWorkDependency
    {
        /// <summary>
        /// 获取记录条数
        /// </summary>
        /// <returns></returns>
        BaseResult<int> GetRecord();
    }
}
