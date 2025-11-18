using System;
using System.Collections.Generic;
namespace Backend.Business
{
    public class Publicacion
    {
        public Usuario usuario { get; }
        public string Descripcion { get; }
        public DateTime FechaPublicacion { get; }
        public List<Comentario> Comentarios { get; }
    }
}