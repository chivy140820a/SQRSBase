namespace SQRSBase.Catalog
{
    public class Response<T>: CQRSResponse where T : class
    {
        public T entity { get; set; }
    }
}
