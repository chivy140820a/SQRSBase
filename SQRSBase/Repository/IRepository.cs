using SQRSBase.Catalog;

namespace SQRSBase.Repository
{
    public interface IRepository { };
    public interface IRepository<T> where T:class
    {
        Task<Response<T>> FindById(int Id);
        Task<ResponseGetAll<T>> GetAll(string key);
    }
}
