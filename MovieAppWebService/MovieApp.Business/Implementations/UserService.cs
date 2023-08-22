using AutoMapper;
using Infrastructure.Aspects.Caching;
using Infrastructure.Aspects.LogIn;
using Infrastructure.Aspects.Validation;
using Infrastructure.Utilities.ApiResponses;
using Microsoft.AspNetCore.Http;
using MovieApp.Business.Constants;
using MovieApp.Business.CustomExceptions;
using MovieApp.Business.Interfaces;
using MovieApp.Business.Validations.User;
using MovieApp.DataAccess.Interfaces;
using MovieApp.Model.Dtos.User;
using MovieApp.Model.Entities;

namespace MovieApp.Business.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository repository, IMapper mapper) 
        {
            _mapper = mapper;
            _repository = repository;
        }

        [ValidationAspect(typeof(UserPostDtoValidator))]
        [CacheRemoveAspect("IUserService.Get")]
        public async Task<ApiResponse<UserDto>> AddUserAsync(UserPostDto dto)
        {
            var user = _mapper.Map<User>(dto);
            var insertedUser = await _repository.AddAsync(user);
            var userDto = await _repository.GetByIdAsync(insertedUser.Nickname, "MovieRatings", "MovieRatings.Movie", "PersonRatings", "PersonRatings.Person");
            var response = _mapper.Map<UserDto>(userDto);
            return ApiResponse<UserDto>.Success(StatusCodes.Status201Created, response);
        }

        [CacheRemoveAspect("IUserService.Get")]
        public async Task<ApiResponse<NoData>> DeleteUserAsync(string userId)
        {
            var user = await _repository.GetByIdAsync(userId);
            if (user != null)
            {
                await _repository.RemoveAsync(user);
                return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
            }
            throw new NotFoundException(ErrorMessages.NotFoundId);
        }

        [CacheAspect]
        public async Task<ApiResponse<List<UserDto>>> GetUserAsync(params string[] includeList)
        {
            var users = await _repository.GetAllAsync(includeList: includeList);
            if (users != null && users.Count > 0)
            {
                var dto = _mapper.Map<List<UserDto>>(users);
                return ApiResponse<List<UserDto>>.Success(StatusCodes.Status200OK, dto);
            }
            throw new NotFoundException(ErrorMessages.NotFoundContent);
        }

        public async Task<ApiResponse<UserDto>> GetUserByIdAsync(string nickName, params string[] includeList)
        {
            var user = await _repository.GetByIdAsync(nickName, includeList);
            if (user != null)
            {
                var dto = _mapper.Map<UserDto>(user);
                return ApiResponse<UserDto>.Success(StatusCodes.Status200OK, dto);
            }
            throw new NotFoundException(ErrorMessages.NotFoundId);
        }

        [LogInCheckAspect]
        public async Task<ApiResponse<UserDto>> GetUserByNicknameWithPasswordAsync(string nickname, string password, params string[] includeList)
        {
            var user = await _repository.GetUserByNicknameWithPasswordAsync(nickname, password, includeList);
            if (user != null)
            {
                var dto = _mapper.Map<UserDto>(user);
                return ApiResponse<UserDto>.Success(StatusCodes.Status200OK, dto);
            }
            throw new BadRequestException(ErrorMessages.LogInError);
        }

        public async Task<ApiResponse<List<UserDto>>> GetUsersByFullNameAsync(string fullName, params string[] includeList)
        {
            var users = await _repository.GetByFullNameAsync(fullName, includeList);
            if (users != null && users.Count > 0)
            {
                var dto = _mapper.Map<List<UserDto>>(users);
                return ApiResponse<List<UserDto>>.Success(StatusCodes.Status200OK, dto);
            }
            throw new NotFoundException(ErrorMessages.NotFoundFullName);
        }

        [ValidationAspect(typeof(UserPutDtoValidator))]
        [CacheRemoveAspect("IUserService.Get")]
        public async Task<ApiResponse<NoData>> UpdateUserAsync(UserPutDto dto)
        {
            var user = await _repository.GetByIdAsync(dto.Nickname);
            if (user != null)
            {
                var updateUser = _mapper.Map<User>(dto);
                await _repository.UpdateAsync(updateUser);
                return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
            }
            throw new NotFoundException(ErrorMessages.NotFoundId);
        }
    }
}
