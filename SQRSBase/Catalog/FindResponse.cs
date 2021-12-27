namespace SQRSBase.Catalog
{
    public class FindResponse<T>:CQRSResponse where T : class
    {
        public T entity { get; set; }
    }
}
