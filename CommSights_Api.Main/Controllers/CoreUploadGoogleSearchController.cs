using CommSights_Api.Abstractions.Services;
using CommSights_Api.Core.Interfaces;
using CommSights_Api.Database.ModelCommSights;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileSystemGlobbing;
using Newtonsoft.Json;
using System;
using System.Text;

namespace CommSights_Api.Main.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoreUploadGoogleSearchController : ControllerBase
    {
        private readonly ICoreUploadGoogleSearch ICore;
        private readonly IServiceProvider serviceProvider;
        public CoreUploadGoogleSearchController(ICoreUploadGoogleSearch core, IServiceProvider serviceProvider)
        {
            this.ICore = core;
            this.serviceProvider = serviceProvider;
        }
        [HttpPost("UploadGoogleSearch")]
        public async Task<ActionResult> UploadGoogleSearch(IFormFile file, int RequestUserID, int IndustryIDUploadGoogleSearch, bool IsIndustryIDUploadGoogleSearch, bool IsPriority)
        {
            ReponserApiService<string> responseAPI = new ReponserApiService<string>();
            try
            {
                var data = await ICore.SplitExcelFiles(file, RequestUserID, IndustryIDUploadGoogleSearch);
                int stt = 0;
                var tasks = data.excelUploadGoogleSearches.Select(async batch =>
                {
                    using (var scope = serviceProvider.CreateScope())
                    {
                        var scopedCore = scope.ServiceProvider.GetRequiredService<ICoreUploadGoogleSearch>();
                        var dataCheck = await scopedCore.UploadGoogleSearchUpdate(batch, data.fileName, data.baiVietUploadId, RequestUserID, IndustryIDUploadGoogleSearch, IsIndustryIDUploadGoogleSearch, IsPriority);
                        if (dataCheck)
                            stt++;
                    }
                });
                await Task.WhenAll(tasks);
                responseAPI.Data = "Successfully performed the operation with " + data.excelUploadGoogleSearches.Count() + " separated excel files and " + stt + " core executed list files successfully";
                responseAPI.Count = data.excelUploadGoogleSearches.Count();
                responseAPI.Message = "Load thành công!!";
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.Message = ex.Message;
                return BadRequest(responseAPI);
            }
        }
        //[HttpPost("UploadGoogleSearch_Goc")]
        //public async Task<ActionResult> UploadGoogleSearch(IFormFile file, int RequestUserID, int IndustryIDUploadGoogleSearch, bool IsIndustryIDUploadGoogleSearch, bool IsPriority)
        //{
        //    ReponserApiService<string> responseAPI = new ReponserApiService<string>();
        //    try
        //    {
        //        var data = await ICore.UploadGoogleSearch(file, RequestUserID, IndustryIDUploadGoogleSearch, IsIndustryIDUploadGoogleSearch, IsPriority);
        //        responseAPI.Data = "Successfully ";
        //        responseAPI.Count = 1;
        //        responseAPI.Message = "Load thành công!!";
        //        return Ok(responseAPI);
        //    }
        //    catch (Exception ex)
        //    {
        //        responseAPI.Message = ex.Message;
        //        return BadRequest(responseAPI);
        //    }
        //}
        //[HttpPost("SplitExcelFiles")]
        //public async Task<ActionResult> SplitExcelFiles(IFormFile file, int RequestUserID, int IndustryIDUploadGoogleSearch)
        //{
        //    ReponserApiService<string> responseAPI = new ReponserApiService<string>();
        //    try
        //    {
        //        var data = await ICore.SplitExcelFiles(file,RequestUserID,IndustryIDUploadGoogleSearch);
        //        responseAPI.Data = data;
        //        responseAPI.Count = data.excelUploadGoogleSearches.Count();
        //        responseAPI.Message = "Load thành công!!";
        //        return Ok(responseAPI);
        //    }
        //    catch (Exception ex)
        //    {
        //        responseAPI.Message = ex.Message;
        //        return BadRequest(responseAPI);
        //    }
        //}
    }
}
