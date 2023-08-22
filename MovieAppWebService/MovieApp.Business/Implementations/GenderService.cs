using AutoMapper;
using Infrastructure.Aspects.Caching;
using Infrastructure.Aspects.IdParameter;
using Infrastructure.Utilities.ApiResponses;
using Microsoft.AspNetCore.Http;
using MovieApp.Business.Constants;
using MovieApp.Business.CustomExceptions;
using MovieApp.Business.Interfaces;
using MovieApp.DataAccess.Interfaces;
using MovieApp.Model.Dtos.Gender;

namespace MovieApp.Business.Implementations
{
    public class GenderService : IGenderService
    {
        private readonly IGenderRepository _repository;
        private readonly IMapper _mapper;

        public GenderService(IGenderRepository repository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }

        [CacheAspect]
        public async Task<ApiResponse<List<GenderDto>>> GetGendersAsync()
        {
            var genders = await _repository.GetAllAsync();
            if (genders != null && genders.Count > 0)
            {
                var dto = _mapper.Map<List<GenderDto>>(genders);
                return ApiResponse<List<GenderDto>>.Success(StatusCodes.Status200OK, dto);
            }
            throw new NotFoundException(ErrorMessages.NotFoundContent);
        }

        [CacheAspect]
        public async Task<ApiResponse<List<GenderWithPersonsDto>>> GetGendersWithPersonsAsync(params string[] includeList)
        {
            var gendersWithPersons = await _repository.GetAllAsync(includeList: includeList);
            if (gendersWithPersons != null && gendersWithPersons.Count > 0)
            {
                var dto = _mapper.Map<List<GenderWithPersonsDto>>(gendersWithPersons);
                return ApiResponse<List<GenderWithPersonsDto>>.Success(StatusCodes.Status200OK, dto);
            }
            throw new NotFoundException(ErrorMessages.NotFoundContent);
        }

        [IdCheckAspect]
        public async Task<ApiResponse<GenderWithPersonsDto>> GetSingleGenderByIdWithPersonsAsync(int genderId, params string[] includeList)
        {
            var genderWithPersons = await _repository.GetSingleGenderByIdWithPersonsAsync(genderId, includeList);
            if (genderWithPersons != null)
            {
                var dto = _mapper.Map<GenderWithPersonsDto>(genderWithPersons);
                return ApiResponse<GenderWithPersonsDto>.Success(StatusCodes.Status200OK, dto);
            }
            throw new NotFoundException(ErrorMessages.NotFoundId);
        }
    }
}
