﻿using MediatR;
using SQRSBase.Catalog;
using SQRSBase.SerVice;

namespace SQRSBase.Repository
{
    public class Repository<T> : IRepository<T> where T : class 
    {
        private readonly IMediator _mediator;
        public Repository(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        public async Task<Response<T>> FindById(int Id)
        {
            var find = await _mediator.Send(new FindById<T>.Query(Id));
            return find;
        }

        public Task<ResponseGetAll<T>> GetAll(string key)
        {
            throw new NotImplementedException();
        }

        //public async Task<ResponseGetAll<T>> GetAll(string key)
        //{
        //    var find = await _mediator.Send(new GetAll<T>.Query(key));
        //    return find;
        //}
    }
}
