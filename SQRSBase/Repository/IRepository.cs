using SQRSBase.Catalog;

namespace SQRSBase.Repository
{
    public interface IRepository { };
    public interface IRepository<T> where T:class
    {
        Task<FindResponse<T>> FindById(int Id);
        Task<Response<T>> GetAll(string key);
    }
}
