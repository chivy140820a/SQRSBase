using System.Net;

namespace SQRSBase.Catalog
{
    public class CQRSResponse
    {
        public HttpStatusCode StatusCode { get; init; } = HttpStatusCode.OK;
        public string ErrorMessage { get; init; }
    }
}
