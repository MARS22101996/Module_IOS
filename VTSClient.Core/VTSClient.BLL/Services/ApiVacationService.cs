using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using VTSClient.BLL.Dto;
using VTSClient.BLL.Interfaces;
using VTSClient.DAL.Entities;
using VTSClient.DAL.Infrastructure;
using VTSClient.DAL.Interfaces;

namespace VTSClient.BLL.Services
{
    public class ApiVacationService : IApiVacationService
    {
        private readonly IApiRepository _vacationRepository;
        private readonly IMapper _mapper;

        public ApiVacationService(IApiRepository vacationRepository, IMapper mapper)
        {
            _vacationRepository = vacationRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<VacationDto>> GetVacationAsync()
        {
            var vacations = await _vacationRepository.GetAsync<Vacation>(UrlName.GetApiUrl());

            var vacationDtos = _mapper.Map<IEnumerable<VacationDto>>(vacations);

            return vacationDtos;
        }

        public async Task<VacationDto> GetVacationByIdAsync(Guid id)
        {
            var vacation = await _vacationRepository.GetByIdAsync<Vacation>(id, UrlName.GetApiUrl());

            var vacationDto = _mapper.Map<VacationDto>(vacation);

            return vacationDto;
        }

        public Task<bool> CreateVacationAsync(VacationDto entity)
        {
            var vacation = _mapper.Map<Vacation>(entity);

            return _vacationRepository.CreateAsync(vacation, UrlName.GetApiUrl());
        }

        public Task<bool> UpdateVacationAsync(VacationDto entity)
        {
            var vacation = _mapper.Map<Vacation>(entity);

            return _vacationRepository.UpdateAsync(vacation, UrlName.GetApiUrl());
        }

        public Task<bool> DeleteVacationByIdAsync(Guid id)
        {
            return _vacationRepository.DeleteAsync<Vacation>(id, UrlName.GetApiUrl());
        }
    }
}
