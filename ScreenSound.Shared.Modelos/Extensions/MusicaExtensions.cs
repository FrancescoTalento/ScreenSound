using ScreenSound.Modelos;
using ScreenSound.Shared.Modelos.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenSound.Shared.Modelos.Extensions
{
    public static class MusicaExtensions
    {
        public static Musica ToEntity(this MusicaOutput output)
        {
            return new Musica
            {
                Id = output.Id,
                Nome = output.Nome,
                AnoLancamento = output.AnoDeLancamento
            };
        }

        public static MusicaOutput ToOutput(this Musica musica, ICollection<GeneroRequest> generoRequests = null )
        {
            return new MusicaOutput
            {
                Id = musica.Id,
                Nome = musica.Nome,
                AnoDeLancamento = musica.AnoLancamento,
                GenerosRequest = generoRequests ?? new List<GeneroRequest>()
            };
        }

        public static MusicaInput ToInput(this Musica musica) 
        {
            return new MusicaInput
            {
                Nome = musica.Nome,
                AnoLancamento = musica.AnoLancamento,

            };
        }
    }
}
