using CommSights_Api.Abstractions.Services;
using CommSights_Api.Core.Interfaces;
using CommSights_Api.Database.ModelCommSights;
using CommSights_Api.Database.ModelViews;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;

namespace CommSights_Api.Main.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QcMonthlyController : ControllerBase
    {
        private readonly IQcMonthly IQc;
        private readonly IServiceProvider serviceProvider;
        public QcMonthlyController(IQcMonthly qcMonthly, IServiceProvider serviceProvider)
        {
            this.IQc = qcMonthly;
            this.serviceProvider = serviceProvider;
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
                var data = await IQc.UpExcelToTmp(file, RequestUserID);
                var result = new List<TmpUploadExcelMonthl>();
                var tasks = data.UploadExcelMonthlyModelVies.Select(async batch =>
                {
                    using (var scope = serviceProvider.CreateScope())
                    {
                        var scopedCore = scope.ServiceProvider.GetRequiredService<IQcMonthly>();
                        var Repon = await scopedCore.InsertDataTmp(batch);
                        foreach (var item in Repon)
                        {
                            result.Add(item);
                        };
                    }
                });
                await Task.WhenAll(tasks);
                responseAPI.Data = result.OrderBy(a=>a.Headline).ToList();
                responseAPI.Count = data.UploadExcelMonthlyModelVies.Count();
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
