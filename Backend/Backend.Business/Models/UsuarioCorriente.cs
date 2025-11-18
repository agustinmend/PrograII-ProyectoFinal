using System;
namespace Backend.Business
{
    public class UsuarioCorriente : Usuario
    {
        public UsuarioCorriente(string UsuarioID, string Nombre, string Apellidos, string Username, DateTime FechaCreacion, string Correo) 
            : base(UsuarioID, Nombre, Apellidos, Username, FechaCreacion, Correo) { }
    }
}

