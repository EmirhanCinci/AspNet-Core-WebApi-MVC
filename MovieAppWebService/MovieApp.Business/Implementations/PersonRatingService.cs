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
using MovieApp.Business.Validations.PersonRating;
using MovieApp.DataAccess.Interfaces;
using MovieApp.Model.Dtos.PersonRating;
using MovieApp.Model.Entities;

namespace MovieApp.Business.Implementations
{
    public class PersonRatingService : IPersonRatingService
    {
        private readonly IPersonRatingRepository _repository;
        private readonly IMapper _mapper;

        public PersonRatingService(IPersonRatingRepository repository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }

        [ValidationAspect(typeof(PersonRatingPostDtoValidator))]
        [CacheRemoveAspect("IPersonRatingService.Get")]
        public async Task<ApiResponse<PersonRatingDto>> AddPersonRatingAsync(PersonRatingPostDto dto)
        {
            var personRating = _mapper.Map<PersonRating>(dto);
            var insertedPersonRating = await _repository.AddAsync(personRating);
            var response = await GetOnePersonRatingByIdAsync(insertedPersonRating.Id, "Person", "User");
            var returnDto = _mapper.Map<PersonRatingDto>(response.Data);
            return ApiResponse<PersonRatingDto>.Success(StatusCodes.Status200OK, returnDto);
        }

        [IdCheckAspect]
        [CacheRemoveAspect("IPersonRatingService.Get")]
        public async Task<ApiResponse<NoData>> DeletePersonRatingAsync(int id)
        {
            var personRating = await _repository.GetPersonRatingByIdAsync(id);
            if (personRating != null)
            {
                await _repository.RemoveAsync(personRating);
                return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
            }
            throw new NotFoundException(ErrorMessages.NotFoundContentByParameter);
        }

        [IdCheckAspect]
        public async Task<ApiResponse<PersonRatingDto>> GetOnePersonRatingByIdAsync(int id, params string[] includeList)
        {
            var personRating = await _repository.GetPersonRatingByIdAsync(id, includeList);
            if (personRating != null)
            {
                var dto = _mapper.Map<PersonRatingDto>(personRating);
                return ApiResponse<PersonRatingDto>.Success(StatusCodes.Status200OK, dto);
            }
            throw new NotFoundException(ErrorMessages.NotFoundContentByParameter);
        }

        [IdCheckAspect]
        [CacheAspect]
        public async Task<ApiResponse<List<PersonRatingDto>>> GetPersonRatingsByPersonIdAsync(int personId, params string[] includeList)
        {
            var personRatings = await _repository.GetCommentsByPersonIdAsync(personId, includeList);
            if (personRatings != null && personRatings.Count > 0)
            {
                var dtos = _mapper.Map<List<PersonRatingDto>>(personRatings);
                return ApiResponse<List<PersonRatingDto>>.Success(StatusCodes.Status200OK, dtos);
            }
            throw new NotFoundException(ErrorMessages.NotFoundId);
        }

        [MinAndMaxCheckAspect]
        public async Task<ApiResponse<List<PersonRatingDto>>> GetPersonRatingsByPointsRange(int min, int max, params string[] includeList)
        {
            var personRatings =  await _repository.GetCommentsByPointsRangeAsync(min, max, includeList);
            if (personRatings != null && personRatings.Count > 0)
            {
                var dtos = _mapper.Map<List<PersonRatingDto>>(personRatings);
                return ApiResponse<List<PersonRatingDto>>.Success(StatusCodes.Status200OK, dtos);
            }
            throw new NotFoundException(ErrorMessages.NotFoundContent);
        }

        [CacheAspect]
        public async Task<ApiResponse<List<PersonRatingDto>>> GetPersonRatingsByUserIdAsync(string userId, params string[] includeList)
        {
            var personRatings = await _repository.GetCommentsByUserIdAsync(userId, includeList);
            if (personRatings != null && personRatings.Count > 0)
            {
                var dtos = _mapper.Map<List<PersonRatingDto>>(personRatings);
                return ApiResponse<List<PersonRatingDto>>.Success(StatusCodes.Status200OK, dtos);
            }
            throw new NotFoundException(ErrorMessages.NotFoundContent);
        }

        [ValidationAspect(typeof(PersonRatingPutDtoValidator))]
        [CacheRemoveAspect("IPersonRatingService.Get")]
        public async Task<ApiResponse<NoData>> UpdatePersonRatingAsync(PersonRatingPutDto dto)
        {
            var personRating = await _repository.GetPersonRatingByIdAsync(dto.Id);
            if (personRating != null)
            {
                var personRatingDto = _mapper.Map<PersonRating>(dto);
                await _repository.UpdateAsync(personRatingDto);
                return ApiResponse<NoData>.Success(StatusCodes.Status204NoContent);
            }
            throw new NotFoundException(ErrorMessages.NotFoundId);
        }
    }
}
