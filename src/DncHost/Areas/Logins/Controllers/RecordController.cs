using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Dnc.Application.Contracts.Logins;
using UtilsSharp.AspNetCore.MVC;
using UtilsSharp.Standard;

namespace DncHost.Areas.Logins.Controllers
{
    /// <summary>
    /// 登入记录控制器
    /// </summary>
    [ApiExplorerSettings(GroupName = "Logins")]
    [Area("Logins")]
    public class RecordController : BaseAreaController
    {
        private readonly IRecordAppService _recordAppService;

        public RecordController(IRecordAppService recordAppService)
        {
            _recordAppService = recordAppService;
        }

        /// <summary>
        /// 获取记录
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async ValueTask<BaseResult<int>> GetRecord()
        {
            return await _recordAppService.GetRecordAsync();
        }
    }
}
