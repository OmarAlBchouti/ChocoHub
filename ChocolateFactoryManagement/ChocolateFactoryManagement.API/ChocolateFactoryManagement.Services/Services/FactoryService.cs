﻿using AutoMapper;
using ChocolateFactoryManagement.Domain.DTOs;
using ChocolateFactoryManagement.Domain.Models;
using ChocolateFactoryManagement.Infrastructure.Repositories;

namespace ChocolateFactoryManagement.Services.Services
{
    public interface IFactoryService
    {
        Task<IEnumerable<FactoryDto>> GetAllAsync();
        Task CreateChocolateBar(int factoryId, ChocolateBar chocolateBar);
        Task DeleteChocolateBar(int factoryId, int chocolateBarId);
    }

    public class FactoryService : IFactoryService
    {
        private readonly IFactoryRepository _factoryRepository;
        private readonly IChocolateBarRepository _chocolateBarRepository;

        private readonly IMapper _mapper;
        public FactoryService(IFactoryRepository factoryRepository, IChocolateBarRepository chocolateBarRepository, IMapper mapper)
        {
            _factoryRepository = factoryRepository;
            _chocolateBarRepository = chocolateBarRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Get All Factories With ChocolateBar
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<FactoryDto>> GetAllAsync()
        {
            var factories = await _factoryRepository.GetAllFactories();
            var mappedFactories = _mapper.Map<IEnumerable<FactoryDto>>(factories);
            return mappedFactories;
        }

        /// <summary>
        /// Create ChocolateBar By Factory
        /// </summary>
        /// <param name="factoryId"></param>
        /// <param name="chocolateBar"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task CreateChocolateBar(int factoryId, ChocolateBar chocolateBar)
        {
            var factory = await _factoryRepository.GetFactoryById(factoryId);
            if (factory == null)
                throw new Exception("The Factory must exist!");

            factory.ChocolateBars.Add(chocolateBar);
            await _factoryRepository.UpdateFactory(factory);
        }

        /// <summary>
        /// Delete ChocolateBar  By Factory
        /// </summary>
        /// <param name="factoryId"></param>
        /// <param name="chocolateBarId"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task DeleteChocolateBar(int factoryId, int chocolateBarId)
        {
            var chocolateBar = await _chocolateBarRepository.GetChocolateBar(factoryId, chocolateBarId);
            if (chocolateBar == null)
                throw new Exception("The ChocolateBar must exist!");
            await _factoryRepository.DeleteChocolateBarFromFactory(chocolateBar);
        }
    }
}
