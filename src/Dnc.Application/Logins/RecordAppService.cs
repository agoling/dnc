using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Dnc.Application.Contracts.Logins;
using UtilsSharp.Standard;

namespace Dnc.Application.Logins
{
    /// <summary>
    /// 登录记录服务
    /// </summary>
    public class RecordAppService: IRecordAppService
    {
        /// <summary>
        /// 获取登录记录条数
        /// </summary>
        /// <returns></returns>
        public async ValueTask<BaseResult<int>> GetRecordAsync()
        {

            var result=new BaseResult<int>();
            //查数据库
            //if (false)
            //{
            //    result.SetError("无法连接数据库",8000);
            //    return result;
            //}
            await Task.Delay(1000);//模拟执行了1秒
            result.Result = 101;
            return result;
        }
    }
}
