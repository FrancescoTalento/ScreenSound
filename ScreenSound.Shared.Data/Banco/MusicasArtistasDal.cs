using Microsoft.EntityFrameworkCore;
using ScreenSound.Modelos;
using ScreenSound.Shared.Modelos.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenSound.Banco
{

    public class MusicasArtistasDal
    {
        private readonly ScreenSoundContext _context;
        public MusicasArtistasDal(ScreenSoundContext context)
        {
            _context = context;
        }

        public IEnumerable<Musica> GetMusicasByArtista(int idArtista)
        {
            var musicasDoArtista = _context.Artistas
                .Include(a => a.MusicasArtistas)
                .ThenInclude(ma => ma.Musica)
                .FirstOrDefault(a => a.Id == idArtista);

            if (musicasDoArtista == null)
            {
                return Enumerable.Empty<Musica>();
            }
            return musicasDoArtista.MusicasArtistas
                .Select(ma => ma.Musica)
                 .Where(m => m != null);
        }


        public void Add(int musicaId, int artistaId)
        {
            MusicasArtista musicasArtista = new MusicasArtista{ ArtistaId = artistaId, MusicaId = musicaId };

            _context.MusicasArtistas.Add(musicasArtista);
           // _context.SaveChanges();
        }

        public void UpdateRelacoes(
    Func<MusicasArtista, bool> filtro,
    Func<int, MusicasArtista> novaRelacao,
    List<int> listaId)
        {
            
            try
            {
                var antigas = _context.MusicasArtistas
                    .Where(filtro)
                    .ToList();

                _context.MusicasArtistas.RemoveRange(antigas);

                var novasRelacoes = listaId.Select(novaRelacao);
                _context.MusicasArtistas.AddRange(novasRelacoes);

                _context.SaveChanges();
               
            }
            catch
            {
                throw;
            }
        }

        public IEnumerable<MusicaOutput> GetMusicasOfArtista(int artistaId)
        {
            var musicasDoArtista = from ma in _context.MusicasArtistas
                                   join m in _context.Musicas
                                   on ma.MusicaId equals m.Id
                                   where ma.ArtistaId == artistaId
                                   select new MusicaOutput
                                   {
                                       Id = m.Id,
                                       Nome = m.Nome,
                                       AnoDeLancamento = m.AnoLancamento
                                   };

            return musicasDoArtista.ToList();
        }


        public List<int> GetArtistaIdsOfMusica(int musicaId)
        {
            if (_context.MusicasArtistas == null)
            {
                Console.WriteLine("⚠️ MusicasArtistas está null!");
                return new List<int>();
            }
            
            var retorno = _context.MusicasArtistas
                .Where(ma => ma.MusicaId == musicaId)
                .Select(ma => ma.ArtistaId)
                .ToList();

            
            return retorno;
        }


        public IEnumerable<ArtistaResumo> GetArtistasOfMusica(int musicaId) 
        {
            var artistasDaMusica = from ma in _context.MusicasArtistas
                                   join a in _context.Artistas
                                   on ma.ArtistaId equals a.Id
                                   where ma.MusicaId == musicaId
                                   select new ArtistaResumo
                                   {
                                       Nome = a.Nome,
                                       Bio = a.Bio,
                                   };
            return artistasDaMusica.ToList();
        }

        //public void UpdateRelacaoMusicaComArtistas(int idMusica, List<int> listaId)
        //{
        //    using var transaction = _context.Database.BeginTransaction();
        //    try
        //    {
        //        var relacoesAntigas = _context.MusicasArtistas
        //        .Where(ma => ma.MusicaId == idMusica)
        //        .ToList();

        //        if (relacoesAntigas.Any())
        //        {
        //            _context.MusicasArtistas.RemoveRange(relacoesAntigas);
        //        }

        //        foreach (int id in listaId)
        //        {
        //            this.Add(idMusica, id);
        //        }

        //        _context.SaveChanges();
        //        transaction.Commit();
        //    }
        //    catch (Exception)
        //    {
        //        transaction.Rollback();
        //        throw;
        //    }
        //}

        //public void UpdateRelacaoArtistaComMusicas(int idArtista, List<int> listaId)
        //{
        //    using var transaction = _context.Database.BeginTransaction();
        //    try
        //    {
        //        var relacoesAntigas = _context.MusicasArtistas
        //            .Where(ma => ma.ArtistaId == idArtista)
        //            .ToList();

        //        if (relacoesAntigas.Any())
        //        {
        //            _context.MusicasArtistas.RemoveRange(relacoesAntigas);
        //        }

        //        foreach(int id in listaId)
        //        {
        //            this.Add(id, idArtista);
        //        }
        //        _context.SaveChanges(); 
        //        transaction.Commit();

        //    }
        //    catch (Exception)
        //    {
        //        transaction.Rollback();
        //        throw;
        //    }

        //}

    }
}
