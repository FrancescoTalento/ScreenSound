using ScreenSound.Banco;
using ScreenSound.Modelos;
using ScreenSound.Shared.Modelos.DTOs;
using ScreenSound.Shared.Modelos.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenSound.Shared.Data.Banco
{
    public class GenerosMusicaDal
    {
        private readonly ScreenSoundContext _context;


        public void Add(int musicaId, int generoId)
        {
            GenerosMusica novaRealacao = new GenerosMusica
            {
                GeneroId = generoId,
                MusicaId = musicaId
            };
            _context.GenerosMusica.Add(novaRealacao);
        }
        public GenerosMusicaDal(ScreenSoundContext context)
        {
            _context = context;
        }

        public ICollection<GeneroRequest> GetGenerosOfMusica(int musicaId)
        {
            var generosList = from gm in _context.GenerosMusica
                              join g in _context.Generos
                              on gm.GeneroId equals g.Id
                              where gm.MusicaId == musicaId
                              select new GeneroRequest
                              {
                                  Id = g.Id,
                                  Name = g.Nome
                              };
           return generosList.ToList();
                              
        }

        public void UpdateRelacoes(
            Func<GenerosMusica, bool> filtro,
            Func<int, GenerosMusica> novaRelacao,
            List<int>? listaId)
        {
            try
            {
                // Proteção contra lista nula
                if (listaId == null || !listaId.Any())
                {
                    Console.WriteLine("Nenhum ID recebido para atualização de relação.");
                    return;
                }

                var antigas = _context.GenerosMusica
                    .Where(filtro)
                    .ToList();

                _context.GenerosMusica.RemoveRange(antigas);

                var novasRelacoes = listaId.Select(novaRelacao);
                _context.GenerosMusica.AddRange(novasRelacoes);

                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro em UpdateRelacoes: " + ex.Message);
                throw;
            }
        }

    }
}
