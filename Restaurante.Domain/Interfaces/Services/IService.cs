using FluentValidation;
using System.Collections.Generic;
using Restaurante.Domain.Entities;
using Restaurante.Domain.Request;
using Restaurante.Domain.Response;

namespace Restaurante.Domain.Interfaces.Services
{
    public interface IService<T, R, E> where T : BaseRequest
                                       where R : BaseResponse
                                       where E : BaseEntity
    {
        R Insert<V>(T entity) where V : AbstractValidator<T>;

        R Update<V>(T entity) where V : AbstractValidator<T>;

        void Remove(long id);

        R GetById(long id);

        IEnumerable<R> GetAll();
    }
}