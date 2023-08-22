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
using MovieApp.Business.Validations.MovieRating;
using MovieApp.DataAccess.Interfaces;
using MovieApp.Model.Dtos.MovieRating;
using MovieApp.Model.Entities;

namespace MovieApp.Business.Implementations
{
    public class MovieRatingService : IMovieRatingService
    {
        private readonly IMovieRatingRepository _repository;
        private readonly IMapper _mapper;

        public MovieRatingService(IMovieRatingRepository repository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }

        [ValidationAspect(typeof(MovieRatingPostDtoValidator))]
        [CacheRemoveAspect("IMovieRatingService.Get")]
        public async Task<ApiResponse<MovieRatingDto>> AddMovieRatingAsync(MovieRatingPostDto dto)
        {
            var movieRating = _mapper.Map<MovieRating>(dto);
            var insertedMovieRating = await _repository.AddAsync(movieRating);
            var response = await GetOneMovieRatingByIdAsync(insertedMovieRating.Id, "Movie", "User");
            var returnDto = _mapper.Map<MovieRatingDto>(response.Data);
            return ApiResponse<MovieRatingDto>.Success(StatusCodes.Status201Created, returnDto);
        }

        [IdCheckAspect]
        [CacheRemoveAspect("IMovieRatingService.Get")]
        public async Task<ApiResponse<NoData>> DeleteMovieRatingAsync(int id)
        {
            var movieRating = await _repository.GetMovieRatingByIdAsync(id);
            if (movieRating != null)
            {
                await _repository.RemoveAsync(movieRating);
                return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
            }
            throw new NotFoundException(ErrorMessages.NotFoundId);
        }

        [IdCheckAspect]
        public async Task<ApiResponse<MovieRatingDto>> GetOneMovieRatingByIdAsync(int id, params string[] includeList)
        {
            var movieRating = await _repository.GetMovieRatingByIdAsync(id, includeList);
            if (movieRating != null)
            {
                var dto = _mapper.Map<MovieRatingDto>(movieRating);
                return ApiResponse<MovieRatingDto>.Success(StatusCodes.Status200OK, dto);
            }
            throw new NotFoundException(ErrorMessages.NotFoundContentByParameter);
        }

        [IdCheckAspect]
        [CacheAspect]
        public async Task<ApiResponse<List<MovieRatingDto>>> GetMovieRatingsByMovieIdAsync(int movieId, params string[] includeList)
        {
            if (movieId <= 0)
            {
                throw new BadRequestException(ErrorMessages.InvalidId);
            }
            var movieRatings = await _repository.GetCommentsByMovieIdAsync(movieId, includeList);
            if (movieRatings != null && movieRatings.Count > 0)
            {
                var dtos = _mapper.Map<List<MovieRatingDto>>(movieRatings);
                return ApiResponse<List<MovieRatingDto>>.Success(StatusCodes.Status200OK, dtos);
            }
            throw new NotFoundException(ErrorMessages.NotFoundContentByParameter);
        }

        [MinAndMaxCheckAspect]
        public async Task<ApiResponse<List<MovieRatingDto>>> GetMovieRatingsByPointsRange(int min, int max, params string[] includeList)
        {
            var movieRatings = await _repository.GetCommentsByPointsRangeAsync(min, max, includeList);
            if (movieRatings != null && movieRatings.Count > 0)
            {
                var dtos = _mapper.Map<List<MovieRatingDto>>(movieRatings);
                return ApiResponse<List<MovieRatingDto>>.Success(StatusCodes.Status200OK, dtos);
            }
            throw new NotFoundException(ErrorMessages.NotFoundContent);
        }

        [CacheAspect]
        public async Task<ApiResponse<List<MovieRatingDto>>> GetMovieRatingsByUserIdAsync(string userId, params string[] includeList)
        {
            var movieRatings = await _repository.GetCommentsByUserIdAsync(userId, includeList);
            if (movieRatings != null && movieRatings.Count > 0)
            {
                var dtos = _mapper.Map<List<MovieRatingDto>>(movieRatings);
                return ApiResponse<List<MovieRatingDto>>.Success(StatusCodes.Status200OK, dtos);
            }
            throw new NotFoundException(ErrorMessages.NotFoundContent);
        }

        [ValidationAspect(typeof(MovieRatingPutDtoValidator))]
        [CacheRemoveAspect("IMovieRatingService.Get")]
        public async Task<ApiResponse<NoData>> UpdateMovieRatingAsync(MovieRatingPutDto dto)
        {
            var movieRating = await GetOneMovieRatingByIdAsync(dto.Id);
            if (movieRating != null)
            {
                var movieRatingDto = _mapper.Map<MovieRating>(dto);
                await _repository.UpdateAsync(movieRatingDto);
                return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
            }
            throw new NotFoundException(ErrorMessages.NotFoundContentByParameter);
        }
    }
}
