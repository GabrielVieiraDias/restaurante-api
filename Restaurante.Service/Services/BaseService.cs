using AutoMapper;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using Restaurante.Domain.Entities;
using Restaurante.Domain.Interfaces.Repositories;
using Restaurante.Domain.Interfaces.Services;
using Restaurante.Domain.Interfaces.UnitOfWork;
using Restaurante.Domain.Request;
using Restaurante.Domain.Response;
using Restaurante.Infra.Resources;
using Restaurante.Service.Exceptions;

namespace Restaurante.Service.Services
{
    public class BaseService<T, R, E> : IService<T, R, E> where T : BaseRequest
                                                          where R : BaseResponse
                                                          where E : BaseEntity
    {
        private readonly IRepository<E> _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public BaseService(IRepository<E> repository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public R Insert<V>(T entity) where V : AbstractValidator<T>
        {
            Validate(entity, Activator.CreateInstance<V>());
            E entitySave = null;
            
            try
            {
                _unitOfWork.Begin();
                entitySave = _mapper.Map<E>(entity);
                _repository.Insert(entitySave);
                _unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                _unitOfWork.RollBack();
                throw ex;
            }

            return _mapper.Map<R>(entitySave);
        }

        public R Update<V>(T entity) where V : AbstractValidator<T>
        {
            Validate(entity, Activator.CreateInstance<V>());
            E entityUpdate = null;

            try
            {
                _unitOfWork.Begin();
                entityUpdate = _mapper.Map<E>(entity);
                _repository.Update(entityUpdate);
                _unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                _unitOfWork.RollBack();
                throw ex;
            }

            return _mapper.Map<R>(entityUpdate);
        }

        public void Remove(long id)
        {
            if (id == 0)
                throw new AppException(MessagesAPI.ID_INVALID);

            try
            {
                _unitOfWork.Begin();
                _repository.Remove(id);
                _unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                _unitOfWork.RollBack();
                throw ex;
            }
        }

        public IEnumerable<R> GetAll()
        {
            return _mapper.Map<List<R>>(_repository.GetAll());
        } 

        public R GetById(long id)
        {
            if (id == 0)
                throw new AppException(MessagesAPI.ID_INVALID);

            return _mapper.Map<R>(_repository.GetById(id));
        }

        protected void Validate(T entity, AbstractValidator<T> validator)
        {
            if (entity == null)
                throw new AppException(MessagesAPI.OBJECT_INVALID);

            validator.ValidateAndThrow(entity);
        }
    }
}
