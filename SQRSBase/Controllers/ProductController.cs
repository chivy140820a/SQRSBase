using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SQRSBase.Catalog;
using SQRSBase.Data;
using SQRSBase.Entity;
using SQRSBase.SerVice;
using SQRSBase.SerVice.ProductSV;

namespace SQRSBase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private readonly IProductSerVice _productSerVice;
        public ProductController(IProductSerVice productSerVice)
        {
            _productSerVice = productSerVice;
        }
        [HttpPost("GetAll")]
        public async Task<IActionResult> GetAll(string key)
        {
            var getall = await _productSerVice.GetAll(key);
            return Ok(await getall.entity.ToListAsync());
        }
        [HttpPost("FindById")]
        public async Task<IActionResult> FindById([FromForm]int Id)
        {
            var find = await _productSerVice.FindById(Id);
            return Ok(find.entity);
        }

    }
}
