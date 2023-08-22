using AutoMapper;
using Infrastructure.Aspects.Caching;
using Infrastructure.Aspects.IdParameter;
using Infrastructure.Aspects.MinMaxParameter;
using Infrastructure.Aspects.Validation;
using Infrastructure.Utilities.ApiResponses;
using Microsoft.AspNetCore.Http;
using MovieApp.Business.Constants;
using MovieApp.Business.CustomExceptions;
using MovieApp.Business.Interfaces;
using MovieApp.Business.Validations.Country;
using MovieApp.Business.Validations.Person;
using MovieApp.DataAccess.Interfaces;
using MovieApp.Model.Dtos.Person;
using MovieApp.Model.Entities;

namespace MovieApp.Business.Implementations
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _repository;
        private readonly IMapper _mapper;

        public PersonService(IPersonRepository repository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }

        [ValidationAspect(typeof(PersonPostDtoValidator))]
        [CacheRemoveAspect("IPersonService.Get")]
        public async Task<ApiResponse<PersonDto>> AddAsync(PersonPostDto dto)
        {
            var person = _mapper.Map<Person>(dto);
            var insertedPerson = await _repository.AddAsync(person);
            var response = await GetPersonByIdAsync(insertedPerson.Id, "PersonRatings", "PersonRatings.User", "MoviePersons", "MoviePersons.Movie", "MoviePersons.PersonType", "Country", "Gender");
            return ApiResponse<PersonDto>.Success(StatusCodes.Status201Created, response.Data);
        }

        [IdCheckAspect]
        [CacheRemoveAspect("IPersonService.Get")]
        public async Task<ApiResponse<NoData>> DeleteAsync(int personId)
        {
            var person = await _repository.GetPersonByIdAsync(personId);
            if (person != null)
            {
                await _repository.RemoveAsync(person);
                return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
            }
            throw new NotFoundException(ErrorMessages.NotFoundId);
        }

        [IdCheckAspect]
        public async Task<ApiResponse<PersonDto>> GetPersonByIdAsync(int personId, params string[] includeList)
        {
            var person = await _repository.GetPersonByIdAsync(personId, includeList);
            if (person != null)
            {
                var dto = _mapper.Map<PersonDto>(person);
                return ApiResponse<PersonDto>.Success(StatusCodes.Status200OK, dto);
            }
            throw new NotFoundException(ErrorMessages.NotFoundId);
        }

        [CacheAspect]
        public async Task<ApiResponse<List<PersonDto>>> GetPersonsAsync(params string[] includeList)
        {
            var persons = await _repository.GetAllAsync(includeList: includeList);
            if (persons != null && persons.Count > 0)
            {
                var dtoList = _mapper.Map<List<PersonDto>>(persons);
                return ApiResponse<List<PersonDto>>.Success(StatusCodes.Status200OK, dtoList);
            }
            throw new NotFoundException(ErrorMessages.NotFoundContent);
        }

        [MinAndMaxCheckAspect]
        public async Task<ApiResponse<List<PersonDto>>> GetPersonsByAgeRangeAsync(int min, int max, params string[] includeList)
        {
            var persons = await _repository.GetPersonsByAgeRangeAsync(min, max, includeList);
            if (persons != null && persons.Count > 0)
            {
                var dto = _mapper.Map<List<PersonDto>>(persons);
                return ApiResponse<List<PersonDto>>.Success(StatusCodes.Status200OK, dto);
            }
            throw new NotFoundException(ErrorMessages.NotFoundContent);
        }

        public async Task<ApiResponse<List<PersonDto>>> MostCommentsPersonsAsync(int personTypeId, int personCount, params string[] includeList)
        {
            if (personTypeId <= 0)
            {
                throw new BadRequestException(ErrorMessages.InvalidId);
            }
            if (personCount <= 0)
            {
                throw new BadRequestException(ErrorMessages.InvalidCount);
            }
            var persons = await _repository.MostCommentsPersonsAsync(personTypeId, personCount, includeList);
            if (persons != null && persons.Count > 0)
            {
                var dto = _mapper.Map<List<PersonDto>>(persons);
                return ApiResponse<List<PersonDto>>.Success(StatusCodes.Status200OK, dto);
            }
            throw new NotFoundException(ErrorMessages.NotFoundContent);
        }

        public async Task<ApiResponse<List<PersonDto>>> MostPointsPersonsAsync(int personTypeId, int personCount, params string[] includeList)
        {
            if (personTypeId <= 0)
            {
                throw new BadRequestException(ErrorMessages.InvalidId);
            }
            if (personCount <= 0)
            {
                throw new BadRequestException(ErrorMessages.InvalidCount);
            }
            var persons = await _repository.MostPointsPersonsAsync(personTypeId, personCount, includeList);
            if (persons != null && persons.Count > 0)
            {
                var dto = _mapper.Map<List<PersonDto>>(persons);
                return ApiResponse<List<PersonDto>>.Success(StatusCodes.Status200OK, dto);
            }
            throw new NotFoundException(ErrorMessages.NotFoundContent);
        }

        [ValidationAspect(typeof(PersonPutDtoValidator))]
        [CacheRemoveAspect("IPersonService.Get")]
        public async Task<ApiResponse<NoData>> UpdateAsync(PersonPutDto dto)
        {
            var person = await _repository.GetPersonByIdAsync(dto.Id);
            if (person != null)
            {
                var updatePerson = _mapper.Map<Person>(dto);
                await _repository.UpdateAsync(updatePerson);
                return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
            }
            throw new NotFoundException(ErrorMessages.NotFoundId);
        }
    }
}
