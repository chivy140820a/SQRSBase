using MediatR;
using SQRSBase.Entity;
using SQRSBase.Repository;

namespace SQRSBase.SerVice.ProductSV
{
    public class ProductSerVice : Repository<Product>, IProductSerVice
    {
        public ProductSerVice(IMediator mediator) : base(mediator)
        {
        }
    }
}
