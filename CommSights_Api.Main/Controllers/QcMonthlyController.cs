using CommSights_Api.Abstractions.Services;
using CommSights_Api.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CommSights_Api.Main.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QcMonthlyController : ControllerBase
    {
        private readonly IQcMonthly IQc;
        public QcMonthlyController(IQcMonthly qcMonthly)
        {
            this.IQc = qcMonthly;
        }
        [HttpGet("GetListTmpUploadExcelMonthly")]
        public async Task<ActionResult> GetListTmpUploadExcelMonthly(int pageSize = 200, int pageNumber = 1)
        {
            ReponserApiService<string> responseAPI = new ReponserApiService<string>();
            try
            {
                var data = await IQc.GetListTmpUploadExcelMonthly(pageSize, pageNumber);
                responseAPI.Data = data;
                responseAPI.Count = data.Count();
                responseAPI.Message = "Load thành công!!";
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.Message = ex.Message;
                return BadRequest(responseAPI);
            }
        }
        [HttpPost("UpExcelToTmp")]
        public async Task<ActionResult> UpExcelToTmp(IFormFile file, int RequestUserID)
        {
            ReponserApiService<string> responseAPI = new ReponserApiService<string>();
            try
            {
                var data = await IQc.UpExcelToTmp(file);
                responseAPI.Data = data;
                responseAPI.Count = 1;
                responseAPI.Message = "Load thành công!!";
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.Message = ex.Message;
                return BadRequest(responseAPI);
            }
        }
    }
}
