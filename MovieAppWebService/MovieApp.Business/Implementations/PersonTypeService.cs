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
using MovieApp.Business.Validations.PersonType;
using MovieApp.DataAccess.Interfaces;
using MovieApp.Model.Dtos.PersonType;
using MovieApp.Model.Entities;

namespace MovieApp.Business.Implementations
{
    public class PersonTypeService : IPersonTypeService
    {
        private readonly IPersonTypeRepository _repository;
        private readonly IMapper _mapper;

        public PersonTypeService(IPersonTypeRepository repository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }

        [ValidationAspect(typeof(PersonTypePostDtoValidator))]
        [CacheRemoveAspect("IPersonTypeService.Get")]
        public async Task<ApiResponse<PersonTypeDto>> AddAsync(PersonTypePostDto dto)
        {
            var personType = _mapper.Map<PersonType>(dto);
            var insertedPersonType = await _repository.AddAsync(personType);
            var response = await _repository.GetPersonTypeByIdAsync(insertedPersonType.Id);
            var dtoPersonType = _mapper.Map<PersonTypeDto>(response);
            return ApiResponse<PersonTypeDto>.Success(StatusCodes.Status201Created, dtoPersonType);
        }

        [IdCheckAspect]
        [CacheRemoveAspect("IPersonTypeService.Get")]
        public async Task<ApiResponse<NoData>> DeleteAsync(int id)
        {
            var personType = await _repository.GetPersonTypeByIdAsync(id);
            if (personType != null)
            {
                await _repository.RemoveAsync(personType);
                return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
            }
            throw new NotFoundException(ErrorMessages.NotFoundId);
        }

        [IdCheckAspect]
        public async Task<ApiResponse<PersonTypeDto>> GetPersonsByPersonTypeIdAsync(int personTypeId, params string[] includeList)
        {
            var personType = await _repository.GetPersonsByPersonTypeIdAsync(personTypeId, includeList);
            if (personType != null)
            {
                var dto = _mapper.Map<PersonTypeDto>(personType);
                return ApiResponse<PersonTypeDto>.Success(StatusCodes.Status200OK, dto);
            }
            throw new NotFoundException(ErrorMessages.NotFoundId);
        }

        [CacheAspect]
        public async Task<ApiResponse<List<PersonTypeDto>>> GetPersonTypesAsync(params string[] includeList)
        {
            var personTypes = await _repository.GetAllAsync(includeList: includeList);
            if (personTypes != null && personTypes.Count > 0)
            {
                var dto = _mapper.Map<List<PersonTypeDto>>(personTypes);
                return ApiResponse<List<PersonTypeDto>>.Success(StatusCodes.Status200OK, dto);
            }
            throw new NotFoundException(ErrorMessages.NotFoundContent);
        }

        [ValidationAspect(typeof(PersonTypePutDtoValidator))]
        [CacheRemoveAspect("IPersonTypeService.Get")]
        public async Task<ApiResponse<NoData>> UpdateAsync(PersonTypePutDto dto)
        {
            var personType = await _repository.GetPersonTypeByIdAsync(dto.Id);
            if (personType != null)
            {
                var personTypeDto = _mapper.Map<PersonType>(dto);
                await _repository.UpdateAsync(personTypeDto);
                return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
            }
            throw new BadRequestException(ErrorMessages.NotFoundId);
        }
    }
}
