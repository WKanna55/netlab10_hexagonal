using Lab10_wkana.Application.Dtos.Role;

namespace Lab10_wkana.Application.Intefaces;

public interface IRoleService
{
    Task<List<RoleDto>> GetAllRolesAsync();
    Task<RoleDto> GetRoleByIdAsync(int roleId);
    Task<RoleDto> CreateRoleAsync(CreateRoleDto createRoleDto);
}