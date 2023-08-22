using AutoMapper;
using Infrastructure.Aspects.Caching;
using Infrastructure.Aspects.IdParameter;
using Infrastructure.Aspects.Validation;
using Infrastructure.Utilities.ApiResponses;
using Microsoft.AspNetCore.Http;
using MovieApp.Business.Constants;
using MovieApp.Business.CustomExceptions;
using MovieApp.Business.Interfaces;
using MovieApp.Business.Validations.Country;
using MovieApp.DataAccess.Interfaces;
using MovieApp.Model.Dtos.Country;
using MovieApp.Model.Entities;

namespace MovieApp.Business.Implementations
{
    public class CountryService : ICountryService
    {
        private readonly ICountryRepository _repository;
        private readonly IMapper _mapper;

        public CountryService(ICountryRepository repository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }

        [ValidationAspect(typeof(CountryPostDtoValidator))]
        [CacheRemoveAspect("ICountryService.Get")]
        public async Task<ApiResponse<CountryDto>> AddAsync(CountryPostDto dto)
        {
            var country = _mapper.Map<Country>(dto);
            var insertedCountry = await _repository.AddAsync(country);
            var responseCountry = _mapper.Map<CountryDto>(insertedCountry);
            return ApiResponse<CountryDto>.Success(StatusCodes.Status201Created, responseCountry);
        }

        [IdCheckAspect]
        [CacheRemoveAspect("ICountryService.Get")]
        public async Task<ApiResponse<NoData>> DeleteAsync(int id)
        {
            var country = await _repository.GetByIdAsync(id);
            if (country != null)
            {
                await _repository.RemoveAsync(country);
                return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
            }
            throw new NotFoundException(ErrorMessages.NotFoundId);
        }

        [CacheAspect]
        public async Task<ApiResponse<List<CountryDto>>> GetCountriesAsync()
        {
            var countries = await _repository.GetAllAsync();
            if (countries != null && countries.Count > 0)
            {
                var returnList = _mapper.Map<List<CountryDto>>(countries);
                return ApiResponse<List<CountryDto>>.Success(StatusCodes.Status200OK, returnList);
            }
            throw new NotFoundException(ErrorMessages.NotFoundContent);
        }

        [CacheAspect]
        public async Task<ApiResponse<List<CountryWithPersonsDto>>> GetCountriesWithPersonsAsync(params string[] includeList)
        {
            var countriesWithPersons = await _repository.GetAllAsync(includeList: includeList);
            if (countriesWithPersons != null && countriesWithPersons.Count > 0)
            {
                var dto = _mapper.Map<List<CountryWithPersonsDto>>(countriesWithPersons);
                return ApiResponse<List<CountryWithPersonsDto>>.Success(StatusCodes.Status200OK, dto);
            }
            throw new NotFoundException(ErrorMessages.NotFoundContent);
        }

        [IdCheckAspect]
        public async Task<ApiResponse<CountryDto>> GetCountryById(int id)
        {
            var country = await _repository.GetByIdAsync(id);
            if (country != null)
            {
                var dto = _mapper.Map<CountryDto>(country);
                return ApiResponse<CountryDto>.Success(StatusCodes.Status200OK, dto);
            }
            throw new NotFoundException(ErrorMessages.NotFoundId);
        }

        [IdCheckAspect]
        public async Task<ApiResponse<CountryWithPersonsDto>> GetSingleCountryByIdWithPersonsAsync(int countryId, params string[] includeList)
        {
            var countryWithPersons = await _repository.GetSingleCountryByIdWithPersonsAsync(countryId, includeList);
            if (countryWithPersons != null)
            {
                var dto = _mapper.Map<CountryWithPersonsDto>(countryWithPersons);
                return ApiResponse<CountryWithPersonsDto>.Success(StatusCodes.Status200OK, dto);
            }
            throw new NotFoundException(ErrorMessages.NotFoundId);
        }

        [ValidationAspect(typeof(CountryPutDtoValidator))]
        [CacheRemoveAspect("ICountryService.Get")]
        public async Task<ApiResponse<NoData>> UpdateAsync(CountryPutDto dto)
        {
            var country = await _repository.GetByIdAsync(dto.Id);
            if (country != null)
            {
                var updatedCountry = _mapper.Map<Country>(dto);
                await _repository.UpdateAsync(updatedCountry);
                return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
            }
            throw new NotFoundException(ErrorMessages.NotFoundId);
        }
    }
}
