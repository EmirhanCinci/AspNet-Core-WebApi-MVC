using AutoMapper;
using Infrastructure.Aspects.LogIn;
using Infrastructure.Utilities.ApiResponses;
using Microsoft.AspNetCore.Http;
using MovieApp.Business.Constants;
using MovieApp.Business.CustomExceptions;
using MovieApp.Business.Interfaces;
using MovieApp.DataAccess.Interfaces;
using MovieApp.Model.Dtos.Admin;

namespace MovieApp.Business.Implementations
{
    public class AdminService : IAdminService
    {
        private readonly IAdminRepository _repository;
        private readonly IMapper _mapper;

        public AdminService(IAdminRepository repository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }

        [LogInCheckAspect]
        public async Task<ApiResponse<AdminDto>> LogInAsync(string userName, string password)
        {
            var adminUser = await _repository.GetByUserNameAndPasswordAsync(userName, password);
            if (adminUser != null)
            {
                var dto = _mapper.Map<AdminDto>(adminUser);
                return ApiResponse<AdminDto>.Success(StatusCodes.Status200OK, dto);
            }
            throw new NotFoundException(ErrorMessages.LogInError);
        }
    }
}
