using System.Diagnostics.Eventing.Reader;
//using System.Management.Instrumentation;
using System.Net;
using System.Threading.Tasks;
using Backend.API;
using Backend.Business;
using Microsoft.AspNetCore.Mvc;
[ApiController]
[Route("api/Users")]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly IFileStorageServices _fileStorage;
    private readonly IPublicationService _publicationService;
    public UsersController(IUserService service, IFileStorageServices fileStorageServices, IPublicationService publicationService)
    {
        _userService = service;
        _fileStorage = fileStorageServices;
        _publicationService = publicationService;
    }
    [HttpPost("register")]
    public async Task<IActionResult> CreateUser([FromForm] UserRegisterDto user)
    {
        try
        {
            Console.WriteLine("Username: " + user.Username);
            string photoUrl = await _fileStorage.SaveFileAsync(user.ProfilePhoto, "images/users");
            var userDto = new CreateUserDto
            {
                FullName = user.FullName,
                Username = user.Username,
                Password = user.Password,
                Email = user.Email,
                Description = user.Description,
                ProfilePhotoUrl = photoUrl,
                Contacts = new List<string>(),
                Publicaciones = new List<string>()
            };

            await _userService.RegisterUserAsync(userDto);
            return Created(string.Empty, new { message = "Usuario creado correctamente" });
        }
        catch (InvalidUsername ex)
        {
            return BadRequest(new { message = ex.Message });
        }
        catch (ExistingUsername ex)
        {
            return BadRequest(new { message = ex.Message });
        }
        catch(InvalidPassword ex)
        {
            return BadRequest(new { message = ex.Message });
        }
        catch(InvalidEmail ex)
        {
            return BadRequest(new { message = ex.Message });
        }
        catch(ExistingEmail ex)
        {
            return BadRequest(new { message = ex.Message });
        }
        catch(Exception ex)
        {
            return StatusCode(500, new { message = "Ocurrio un error interno: " + ex.Message });
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
    [HttpGet("{id}/likes")]
    public async Task<IActionResult> GetUserLikes(string id)
    {
        try
        {
            var likedPost = await _publicationService.GetLikedByUserAsync(id);
            return Ok(likedPost);
        }
        catch(Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
    {
        try
        {
            string userId = await _userService.LoginAsync(loginDto.Username, loginDto.Password);
            return Ok(new { message = "Login exitoso", userId = userId });
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }
}
