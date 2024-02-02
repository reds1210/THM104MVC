using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace WebApplication1.Controllers.Api
{
    [Route("api/Products/[action]")]
    [ApiController]
    public class ProductsApiController : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status502BadGateway)]
        public IActionResult GetProduct()
        {
            //var data = new
            //{
            //    StatusCode = 400,
            //    Detail = "Bad Request",
            //    Message = "id is null"
            //};
            var data = new
            {
                Status = false,
                Message = "id is null"
            };
            var j = JsonSerializer.Serialize(data);

            return NotFound(j);
            //return new
            //{
            //    id = 1,
            //    name = "chloe",
            //    age = 18,
            //    CreateDate = DateTime.Now,
            //};
        }
    }
}
