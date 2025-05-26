using Lab10_wkana.Application.Dtos.Role;
using Lab10_wkana.Application.Intefaces;
using Lab10_wkana.Domain.Entities;
using Lab10_wkana.Domain.Interfaces.Base;
using Mapster;

namespace Lab10_wkana.Application.Services;

public class RoleService : IRoleService
{
    private readonly IUnitOfWork _unitOfWork;

    public RoleService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    public async Task<List<RoleDto>> GetAllRolesAsync()
    {
        var roles = await _unitOfWork.Repository<Role>().GetAllAsync();
        return roles.Adapt<List<RoleDto>>();
    }
    
    public async Task<RoleDto> GetRoleByIdAsync(int roleId)
    {
        var role = await _unitOfWork.Repository<Role>().GetByIdAsync(roleId);
        return role.Adapt<RoleDto>();
    }
    
    public async Task<RoleDto> CreateRoleAsync(CreateRoleDto createRoleDto)
    {
        var role = createRoleDto.Adapt<Role>();
        await _unitOfWork.Repository<Role>().AddAsync(role);
        await _unitOfWork.Complete();
        return role.Adapt<RoleDto>();
    }

    //public async Task<> UpdateeRoleAsync()
    //{
    //    
    //}
    
}