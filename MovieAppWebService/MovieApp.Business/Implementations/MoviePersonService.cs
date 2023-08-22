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
using MovieApp.Business.Validations.MoviePerson;
using MovieApp.DataAccess.Interfaces;
using MovieApp.Model.Dtos.MoviePerson;
using MovieApp.Model.Entities;

namespace MovieApp.Business.Implementations
{
    public class MoviePersonService : IMoviePersonService
    {
        private readonly IMoviePersonRepository _repository;
        private readonly IMapper _mapper;

        public MoviePersonService(IMoviePersonRepository repository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }

        [ValidationAspect(typeof(MoviePersonPostDtoValidator))]
        public async Task<ApiResponse<MoviePersonDto>> AddMoviePersonAsync(MoviePersonPostDto dto)
        {
            var moviePerson = _mapper.Map<MoviePerson>(dto);
            var insertedMoviePerson = await _repository.AddAsync(moviePerson);
            var response = await _repository.GetMoviePersonsByMovieIdAndPersonIdWithPersonTypeIdAsync(insertedMoviePerson.MovieId, insertedMoviePerson.PersonId, insertedMoviePerson.PersonTypeId, "Movie", "Person", "PersonType"); ;
            var returnDto = _mapper.Map<MoviePersonDto>(response);
            return ApiResponse<MoviePersonDto>.Success(StatusCodes.Status201Created, returnDto);
        }

        public async Task<ApiResponse<NoData>> DeleteMoviePersonAsync(int movieId, int personId, int personTypeId)
        {
            if (movieId <= 0 || personId <= 0 || personTypeId <= 0)
            {
                throw new BadRequestException(ErrorMessages.InvalidIds);
            }
            var moviePerson = await _repository.GetMoviePersonsByMovieIdAndPersonIdWithPersonTypeIdAsync(movieId, personId, personTypeId);
            if (moviePerson != null)
            {
                await _repository.RemoveAsync(moviePerson);
                return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
            }
            throw new NotFoundException(ErrorMessages.NotFoundIds);
        }

        public async Task<ApiResponse<MoviePersonDto>> GetMoviePersonById(int movieId, int personId, int personTypeId, params string[] includeList)
        {
            if (movieId <= 0 || personId <= 0 || personTypeId <= 0)
            {
                throw new BadRequestException(ErrorMessages.InvalidIds);
            }
            var moviePerson = await _repository.GetMoviePersonsByMovieIdAndPersonIdWithPersonTypeIdAsync(movieId, personId, personTypeId, includeList);
            if (moviePerson != null)
            {
                var dto = _mapper.Map<MoviePersonDto>(moviePerson);
                return ApiResponse<MoviePersonDto>.Success(StatusCodes.Status200OK, dto);
            }
            throw new NotFoundException(ErrorMessages.NotFoundIds);
        }

        public async Task<ApiResponse<List<MoviePersonDto>>> GetMoviePersonsByMovieIdWithPersonTypeIdAsync(int movieId, int personTypeId, params string[] includeList)
        {
            if (movieId <= 0 || personTypeId <= 0)
            {
                throw new BadRequestException(ErrorMessages.InvalidIds);
            }
            var moviePersons = await _repository.GetMoviePersonsByMovieIdWithPersonTypeIdAsync(movieId, personTypeId, includeList);
            if (moviePersons != null && moviePersons.Count > 0)
            {
                var dtos = _mapper.Map<List<MoviePersonDto>>(moviePersons);
                return ApiResponse<List<MoviePersonDto>>.Success(StatusCodes.Status200OK, dtos);
            }
            throw new NotFoundException(ErrorMessages.NotFoundIds);
        }

        public async Task<ApiResponse<List<MoviePersonDto>>> GetMoviePersonsByPersonIdWithPersonTypeIdAsync(int personId, int personTypeId, params string[] includeList)
        {
            if (personId <= 0 || personTypeId <= 0)
            {
                throw new BadRequestException(ErrorMessages.InvalidIds);
            }
            var moviePersons = await _repository.GetMoviePersonsByPersonIdWithPersonTypeIdAsync(personId, personTypeId, includeList);
            if (moviePersons != null && moviePersons.Count > 0)
            {
                var dtos = _mapper.Map<List<MoviePersonDto>>(moviePersons);
                return ApiResponse<List<MoviePersonDto>>.Success(StatusCodes.Status200OK, dtos);
            }
            throw new NotFoundException(ErrorMessages.NotFoundIds);
        }
    }
}
