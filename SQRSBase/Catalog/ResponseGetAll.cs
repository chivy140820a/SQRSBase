namespace SQRSBase.Catalog
{
    public class ResponseGetAll<T>: CQRSResponse where T:class
    {
        public IQueryable<T> entity { get; set; }
    }
}
