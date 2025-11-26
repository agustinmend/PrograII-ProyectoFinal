using System.Diagnostics.Eventing.Reader;
//using System.Management.Instrumentation;
using System.Net;
using System.Threading.Tasks;
using Backend.Business;
using Microsoft.AspNetCore.Mvc;
[ApiController]
[Route("api/Usuarios")]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;
    public UsersController(IUserService service)
    {
        _userService = service;
    }
    [HttpPost]
    public async Task<IActionResult> CreateUser([FromBody] CreateUserDto userDto)
    {
        try
        {
            await _userService.RegisterUserAsync(userDto);
            return Created(string.Empty, new { message = "Usuario creado correctamente" });
        }
        catch (InvalidUsername ex)
        {
            return BadRequest(new { error = ex.Message });
        }
        catch (ExistingUsername ex)
        {
            return BadRequest(new { error = ex.Message });
        }
        catch(InvalidPassword ex)
        {
            return BadRequest(new { error = ex.Message });
        }
        catch(InvalidEmail ex)
        {
            return BadRequest(new { error = ex.Message });
        }
        catch(ExistingEmail ex)
        {
            return BadRequest(new { error = ex.Message });
        }
        catch(Exception ex)
        {
            return StatusCode(500, new { error = "Ocurrio un error interno: " + ex.Message });
        }
    }
    [HttpGet("{id}/profile")]
    public async Task<IActionResult> GetUserProfile(string id)
    {
        try
        {
            var profile = await _userService.GetUserProfileAsync(id);
            return Ok(profile);
        }
        catch(Exception ex)
        {
            return StatusCode(500, new { error = "No se pudo realizar la accion: " + ex.Message });
        }
    }
}
