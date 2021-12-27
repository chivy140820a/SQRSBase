using MediatR;
using SQRSBase.Catalog;

namespace SQRSBase.HandlerRequest
{
    public class ProductRequestHandler<T> : IRequest<bool> where T:class
    {
         public ResponseGetAll<T> entity { get; set; }
    }
}
