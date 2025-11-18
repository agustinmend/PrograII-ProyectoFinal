using Microsoft.AspNetCore.Mvc;
[ApiController]
[Route("api/Usuarios")]
public class UsuariosController : ControllerBase
{
    private readonly IUsuarioService Servicio;
    public UsuariosController(IUsuarioService servicio)
    {
        Servicio = servicio;
    }
    [HttpPost]
    public IActionResult CrearUsuario(Usuario nuevoUsuario)
    {
        Usuario nuevo = Servicio.Registrar(nuevoUsuario);
    }
}
