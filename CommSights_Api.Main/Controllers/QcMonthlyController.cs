using CommSights_Api.Abstractions.Services;
using CommSights_Api.Core.Interfaces;
using CommSights_Api.Database.ModelCommSights;
using CommSights_Api.Database.ModelViews;
using CommSights_Api.Database.ModelViews.QcMonthlyModelView;
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
        public async Task<ActionResult> GetListTmpUploadExcelMonthly(int pageSize = 200, int pageNumber = 1,string filename="",int RequestUserID=6637)
        {
            ReponserApiService<string> responseAPI = new ReponserApiService<string>();
            try
            {
                var data = await IQc.GetListTmpUploadExcelMonthlyWithTotalPages(pageSize, pageNumber, filename, RequestUserID);
                responseAPI.Data = data.results;
                responseAPI.Count = data.totalPages;
                responseAPI.Message = "Load thành công!!";
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.Message = ex.Message;
                return BadRequest(responseAPI);
            }
        }
        [HttpGet("getListNameFile")]
        public async Task<ActionResult> getListNameFile(int RequestUserID)
        {
            ReponserApiService<string> responseAPI = new ReponserApiService<string>();
            try
            {
                var data = await IQc.getListNameFile(RequestUserID);
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
        [HttpPost("UploadAndCheckExcel")]
        public async Task<ActionResult> UpExcelToTmp(IFormFile file, int RequestUserID)
        {
            ReponserApiService<string> responseAPI = new ReponserApiService<string>();
            try
            {
                var data = await IQc.UpExcelToTmp(file, RequestUserID);
                var tasks = data.UploadExcelMonthlyModelVies.Select(async batch =>
                {
                    using (var scope = serviceProvider.CreateScope())
                    {
                        var scopedCore = scope.ServiceProvider.GetRequiredService<IQcMonthly>();
                        await scopedCore.InsertDataTmp(batch);
                    }
                });
                await Task.WhenAll(tasks);
                var repon = new ReponUploadQcMonthly()
                {
                    nameFile = data.fileName,
                    totalCount = data.countArr,
                    usernameId = RequestUserID,
                };
                responseAPI.Data = repon;
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
