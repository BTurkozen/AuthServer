﻿using AppShared.Library.DTOs;
using AuthServer.Core.Repositories;
using AuthServer.Core.Services;
using AuthServer.Core.UnitOfWorks;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AuthServer.Service.Services
{
    public class ServiceGeneric<TEntity, TDto> : IServiceGeneric<TEntity, TDto> where TEntity : class where TDto : class
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGenericRepository<TEntity> _genericRepository;

        public ServiceGeneric(IUnitOfWork unitOfWork, IGenericRepository<TEntity> genericRepository)
        {
            _unitOfWork = unitOfWork;
            _genericRepository = genericRepository;
        }

        public async Task<Response<TDto>> AddAsync(TDto dto)
        {
            var newEntity = ObjectMapper.Mapper.Map<TEntity>(dto);

            await _genericRepository.AddAsync(newEntity);

            await _unitOfWork.CommitAsync();

            var newDto = ObjectMapper.Mapper.Map<TDto>(newEntity);

            return Response<TDto>.Success(newDto, 200);

        }

        public async Task<Response<IEnumerable<TDto>>> GetAllAsync()
        {
            var products = ObjectMapper
                .Mapper
                .Map<List<TDto>>(
                await _genericRepository.GetAllAsync());

            return Response<IEnumerable<TDto>>.Success(products, 200);

        }

        public async Task<Response<TDto>> GetByIdAsync(int id)
        {
            var product = await _genericRepository.GetByIdAsync(id);

            if (product != null)
            {
                return Response<TDto>.Fail("Id Not Found", 404, true);
            }
            return Response<TDto>.Success(ObjectMapper.Mapper.Map<TDto>(product), 200);
        }

        public async Task<Response<NoDataDTO>> Remove(int id)
        {
            //TDto dto aldıgımız zaman direk silebilirizde fakat id sine göre alip ıd not found dondurecegğiz.

            var isExistEntity = await _genericRepository.GetByIdAsync(id);

            if (isExistEntity == null)
            {
                return Response<NoDataDTO>.Fail("Id Not Found", 404, true);
            }

            _genericRepository.Remove(isExistEntity);

            await _unitOfWork.CommitAsync();

            return Response<NoDataDTO>.Success(204);

        }

        public async Task<Response<NoDataDTO>> Update(TDto dto, int id)
        {
            var isExistEntity = await _genericRepository.GetByIdAsync(id);

            if (isExistEntity == null)
            {
                return Response<NoDataDTO>.Fail("Id Not Found", 404, true);
            }

            var updateEntity = ObjectMapper.Mapper.Map<TEntity>(dto);

            _genericRepository.Update(updateEntity);

            await _unitOfWork.CommitAsync();

            return Response<NoDataDTO>.Success(204);
        }

        public async Task<Response<IEnumerable<TDto>>> Where(Expression<Func<TEntity, bool>> predicate)
        {
            var list = _genericRepository.Where(predicate);

            return Response<IEnumerable<TDto>>.Success(
                ObjectMapper
                .Mapper
                .Map<IEnumerable<TDto>>(
                    await list.ToListAsync()), 200);


        }
    }
}
