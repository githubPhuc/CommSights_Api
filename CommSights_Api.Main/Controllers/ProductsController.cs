using CommSights_Api.Abstractions.Services;
using CommSights_Api.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CommSights_Api.Main.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProducts IPro;
        public ProductsController(IProducts iPro) { this.IPro = iPro; }
        [HttpGet("GetProduct")]
        public async Task<ActionResult> GetProduct()
        {
            ReponserApiService<string> responseAPI = new ReponserApiService<string>();
            try
            {
                responseAPI.Data= IPro.GetProducts();
                responseAPI.Count = 12000000;
                responseAPI.Message = "Load thành công!!";
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.Message = ex.Message;
                return BadRequest(responseAPI);
            }


        }
        [HttpGet("GetProduct2")]
        public async Task<ActionResult> GetProduct2()
        {
            ReponserApiService<string> responseAPI = new ReponserApiService<string>();
            try
            {
                var data = await IPro.GetProducts2();
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
    }
}
