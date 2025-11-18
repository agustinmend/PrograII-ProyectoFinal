using System;
namespace Backend.Business
{
    public class UsuarioEmpresa : Usuario
    {
        public UsuarioEmpresa(string UsuarioID, string Nombre, string Apellidos, string Username, DateTime FechaCreacion, string Correo)
            : base(UsuarioID, Nombre, Apellidos, Username, FechaCreacion, Correo) { }
    }
}
