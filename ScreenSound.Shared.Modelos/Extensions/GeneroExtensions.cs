using ScreenSound.Shared.Modelos.DTOs;
using ScreenSound.Shared.Modelos.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenSound.Shared.Modelos.Extensions
{
    public static class GeneroExtensions
    {
        public static Genero ToEntity(this GeneroRequest generoRequest)
        {
            if (generoRequest == null) throw new ArgumentNullException(nameof(generoRequest));

            return new Genero
            {
                Nome = generoRequest.Name
            };
        }

        public static GeneroRequest ToOutput(this Genero genero)
        {
            if (genero == null) throw new ArgumentNullException(nameof(genero));

            return new GeneroRequest
            {
                Id = genero.Id,
                Name = genero.Nome
            };
        }
    }
}
