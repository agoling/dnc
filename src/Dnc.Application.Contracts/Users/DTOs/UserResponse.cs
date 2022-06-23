using System;
using System.Collections.Generic;
using System.Text;

namespace Dnc.Application.Contracts.Users.DTOs
{
    /// <summary>
    /// 用户信息
    /// </summary>
    public class UserResponse
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
        /// 登入次数
        /// </summary>
        public int LoginCount { set; get; }
    }
}
