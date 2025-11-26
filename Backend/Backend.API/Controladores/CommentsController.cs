using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Backend.Business;
using Microsoft.AspNetCore.Mvc;
[ApiController]
[Route("api/[controller]")]
public class CommentsController : ControllerBase
{
	private readonly ICommentService _commentService;
	public CommentsController(ICommentService commentService)
	{
		_commentService = commentService;
	}

	[HttpPost]
	public async Task<IActionResult> CreateComment([FromBody] CommentDto comment)
	{
		try
		{
			await _commentService.AddCommentAsync(comment);
			return Ok(new { mensaje = "Comentario agregado exitosamente" });
		}
		catch(EmptyComment ex)
		{
			return BadRequest(new { error = ex.Message });
		}
		catch(NoUserExists ex)
		{
			return BadRequest(new { error = ex.Message });
		}
		catch(Exception ex)
		{
			return StatusCode(500, new { error = "Ocurrio un problema al anadir comentario: " + ex.Message });
		}
	}
}
