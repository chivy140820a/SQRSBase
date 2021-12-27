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
        private readonly AppDbContext _context;
        private readonly IMediator _mediator;
        public ProductController(IMediator mediator, AppDbContext context)
        {
            _context = context;
            _mediator = mediator;
        }
        //private readonly IProductSerVice _productSerVice;
        //public ProductController(IProductSerVice productSerVice)
        //{
        //    _productSerVice = productSerVice;
        //}
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var getall = await _mediator.Send(new GetAll<Product>.Query("content")) ;
            return Ok(await getall.ToListAsync());
        }
        [HttpGet("GetAllContent")]
        public async Task<IActionResult> GetAllContent()
        {
            var get = new ResponseGetAll<Product>
            {
                entity =  _context.Products,
            };
            return Ok(await get.entity.ToListAsync());
        }
    }
}
