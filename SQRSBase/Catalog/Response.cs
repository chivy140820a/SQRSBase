namespace SQRSBase.Catalog
{
    public class Response<T>: CQRSResponse where T : class
    {
        public IQueryable<T> entity { get; set; }
    }
}
