using System;
using System.Collections.Generic;
using System.Text;
using UtilsSharp.Standard;

namespace Dnc.Service.Admin.Implementation
{
    /// <summary>
    /// 支付记录服务
    /// </summary>
    public class PayRecordService: IPayRecordService
    {
        /// <summary>
        /// 获取记录条数
        /// </summary>
        /// <returns></returns>
        public BaseResult<int> GetRecord()
        {

            var result=new BaseResult<int>();
            //查数据库
            //if (false)
            //{
            //    result.SetError("无法连接数据库",8000);
            //    return result;
            //}
            result.Result = 101;
            return result;
        }
    }
}
