using Lab10_wkana.Application.Dtos.Role;
using Lab10_wkana.Application.Intefaces;
using Microsoft.AspNetCore.Mvc;

namespace Lab10_wkana.Persistense.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RoleController : ControllerBase
{
    private readonly IRoleService _roleService;
    
    public RoleController(IRoleService roleService)
    {
        _roleService = roleService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllRoles()
    {
        //var responses = await _roleService.GetAllRolesAsync();
        //return Ok(responses);
        return Ok();
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateRole([FromBody] CreateRoleDto createRoleDto)
    {
        var role = await _roleService.CreateRoleAsync(createRoleDto);
        return Ok(role);
    }
    
}