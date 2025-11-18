using System;
namespace Backend.Business
{
    public abstract class Usuario
    {
        public string UsuarioID { get; }
        public string Nombre { get; }
        public string Apellidos { get; }
        public string Username { get; }
        public DateTime FechaCreacion { get; }
        public string Correo { get; }
        public Usuario(string UsuarioID, string Nombre, string Apellidos, string Username, DateTime FechaCreacion, string Correo)
        {
            this.UsuarioID = UsuarioID;
            this.Nombre = Nombre;
            this.Apellidos = Apellidos;
            this.Username = Username;
            this.FechaCreacion = FechaCreacion;
            this.Correo = Correo;
        }
    }
}