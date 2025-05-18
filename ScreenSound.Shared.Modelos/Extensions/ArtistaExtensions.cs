using ScreenSound.Modelos;
using ScreenSound.Shared.Modelos.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenSound.Shared.Modelos.Extensions
{
    public static class ArtistaExtensions
    {
        public static Artista ToEntity(this ArtistaCompleto output) 
        {
            return new Artista(output.Nome, output.Bio);
           
        }

      
    }
}
