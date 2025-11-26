using System;
using System.Diagnostics.Eventing.Reader;
using System.IO;
//using System.Management.Instrumentation;
using System.Net;
using System.Threading.Tasks;
using Backend.Business;
using Microsoft.AspNetCore.Mvc;
[ApiController]
[Route("api/Publications")]
public class PublicationsController : ControllerBase
{
    private readonly IPublicationService _publicationService;
    private readonly SearchStrategyFactory _searchFactory;
    public PublicationsController(IPublicationService service, SearchStrategyFactory searchFactory)
    {
        _publicationService = service;
        _searchFactory = searchFactory;
    }
    [HttpPost]
    public async Task<IActionResult> CreatePublication([FromBody] CreatePublicationDto publicationDto)
    {
        try
        {
            await _publicationService.CreatePublicationAsync(publicationDto);
            return Created(string.Empty, new { message = "Publicacion creada exitosamente" });
        }
        catch(InvalidContent ex)
        {
            return BadRequest(new { error = ex.Message });
        }
        catch(NonExistentAuthor ex)
        {
            return BadRequest(new { error = ex.Message });
        }
        catch(Exception ex)
        {
            return StatusCode(500, new { error = "Error al intentar crear publicacion: " + ex.Message });
        }
    }
    [HttpGet("search")]
    public async Task<IActionResult> SearchPosts([FromQuery] string query = "" , [FromQuery] string type="normal")
    {
        try
        {
            var strategy = _searchFactory.GetStrategy(type);
            var result = await strategy.SearchAsync(query);
            return Ok(result);
        }
        catch(Exception ex)
        {
            return StatusCode(500, new { error = "No se pudo hacer la busqueda: " + ex.Message });
        }
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetPublicationById(string id)
    {
        try
        {
            var result = await _publicationService.GetPublicationDetailAsync(id);
            return Ok(result);
        }
        catch(Exception ex)
        {
            return StatusCode(500, new { error = "Ocurrio un problema : " + ex.Message });
        }
    }
}
