using MediatR;
using Microsoft.EntityFrameworkCore;
using SQRSBase.Cache;
using SQRSBase.Catalog;
using SQRSBase.Data;
using SQRSBase.Validation;

namespace SQRSBase.SerVice
{
    public abstract class GetAll<T> where T:class
    {
        public record Query(string key) : IRequest<IQueryable<T>>, ICacheable
        {
            public string CacheKey => $"GetAll{key}";
        }

        //public class Validator : IValidationHandler<Query>
        //{
        //    private readonly AppDbContext _context1;
        //    private DbSet<T> table1;
        //    public Validator(AppDbContext context1)
        //    {
        //        _context1 = context1;
        //        table1 = _context1.Set<T>();
        //    }
        //    public async Task<ValidationResult> Validate(Query request)
        //    {
        //        var list = await table1.ToListAsync();
        //        if (list.Count == 0)
        //        {
        //            return ValidationResult.Fail("Không có sản phẩm");
        //        }
        //        return ValidationResult.Success;
        //    }
        //}
        public class Handler : IRequestHandler<Query, IQueryable<T>>
        {
            private readonly AppDbContext _context;
            private DbSet<T> table;
            public Handler(AppDbContext context)
            {
                _context = context;
                table = _context.Set<T>();
            }

            public async Task<IQueryable<T>> Handle(GetAll<T>.Query request, CancellationToken cancellationToken)
            {
                //var res = new ResponseGetAll<T>
                //{
                //    entity = table,

                //};
                return table;
            }

            
        }

    }
}
