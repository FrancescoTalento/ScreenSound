using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ScreenSound.Modelos;
using ScreenSound.Shared.Data.Banco;
using ScreenSound.Shared.Modelos.DTOs;
using ScreenSound.Shared.Modelos.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenSound.Banco
{
    public class ArtistaDal
    {
        private readonly ScreenSoundContext _context;
        private readonly MusicasArtistasDal _musicasArtistasDal;
        private readonly MusicaDal _musicaDal;
        private readonly GenerosMusicaDal _generosMusicaDal;

        public ArtistaDal(ScreenSoundContext context)
        {
            _context = context;
            _musicasArtistasDal = new MusicasArtistasDal(context);
            _musicaDal = new MusicaDal(context);
            _generosMusicaDal = new GenerosMusicaDal(context);
        }
        public IEnumerable<ArtistaResumo> ListarItens()
        {
            var artistas = from ar in _context.Artistas
                           select new ArtistaResumo
                           {
                               Id = ar.Id,
                               Nome = ar.Nome,
                               Bio = ar.Bio,
                           };
            return artistas.ToList();
        }
            
       
        public ArtistaCompleto GetByName(string nome)
        {
            Artista artistaToGet = _context.Artistas.FirstOrDefault(a => a.Nome.Replace(" ","").Equals(nome));

            if (artistaToGet == null) 
            {
                return null;
            }

            return this.CreateArtistaCompleto(artistaToGet);
        }

        public ArtistaCompleto GetById(int id)
        {
            Artista artista = _context.Artistas.FirstOrDefault(a => a.Id == id);

            if (artista == null) 
            {
                return null;
            }  

            return this.CreateArtistaCompleto(artista);
            
        }

        public ArtistaCompleto CreateArtistaCompleto(Artista artista) 
        {
            var musicasDoArtista = _musicasArtistasDal.GetMusicasByArtista(artista.Id);
            List<MusicaOutput> outputs = new List<MusicaOutput>();

            foreach (Musica item in musicasDoArtista)
            {
                var generosDaMusica = _generosMusicaDal.GetGenerosOfMusica(item.Id);
                outputs.Add(item.ToOutput(generosDaMusica));
            }

            return new ArtistaCompleto { Id =artista.Id, Nome = artista.Nome, Bio = artista.Bio, MusicasDoArtista = outputs };
        }

        public bool Update(int id, ArtistaCompleto newValue)
        {
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                var artistaToUpdate = _context.Artistas.FirstOrDefault(a => a.Id == id);
                if (artistaToUpdate == null) return false;
            

                AtualizarDadosBasicos(artistaToUpdate, newValue);
                AtualizarMusicasDoArtista(newValue, id);

                _context.SaveChanges();
                transaction.Commit();
                return true;
            }
            catch (Exception)
            {
                transaction.Rollback();
                throw;
            }
        }

        private void AtualizarDadosBasicos(Artista artista, ArtistaCompleto novoValor)
        {
            artista.Nome = novoValor.Nome;
            artista.Bio = novoValor.Bio;
        }

        public void AtualizarMusicasDoArtista(ArtistaCompleto artista, int idArtista)
        {
            var listaIdMusicas = new List<int>();

            foreach (var output in artista.MusicasDoArtista)
            {
                try
                {
                    var musica =  _musicaDal.GetById(output.Id);
                    
                    if (musica != null)
                    {
                       
                        _musicaDal.Update(musica.Id, new MusicaInput
                        {
                            Nome = output.Nome,
                            AnoLancamento = output.AnoDeLancamento ?? 0,
                            IdArtistas = _musicasArtistasDal.GetArtistaIdsOfMusica(musica.Id)
                        });

                        listaIdMusicas.Add(musica.Id);
                    }
                    else
                    {
                        var input = new MusicaInput
                        {
                            Nome = output.Nome,
                            AnoLancamento = output.AnoDeLancamento ?? 0,
                            IdArtistas = new List<int> { idArtista }
                        };

                        _musicaDal.Add(input);
                        
                        var novaMusica = _context.Musicas
                            .OrderByDescending(m => m.Id)
                            .FirstOrDefault(m => m.Nome == input.Nome);
                        if (novaMusica != null)
                        {
                            listaIdMusicas.Add(novaMusica.Id);
                        }
                    }
                }
                catch (Exception ex)
                {
                  
                    Console.WriteLine($"Erro ao processar música '{output.Nome}': {ex.Message}");

                }


               
            }
        
            AtualizarRelacoesArtistaMusicas(idArtista, listaIdMusicas);
        }

        private void AtualizarRelacoesArtistaMusicas(int artistaId, List<int> musicasId)
        {
            _musicasArtistasDal.UpdateRelacoes(
                filtro: ma => ma.ArtistaId == artistaId,
                novaRelacao: musicaId => new MusicasArtista
                {
                    ArtistaId = artistaId,
                    MusicaId = musicaId
                },
                listaId: musicasId
            );
        }




        public bool Delete(int id)
        {
            var artistaToDelete = _context.Artistas.FirstOrDefault(a => a.Id == id);
            
            if(artistaToDelete == null) return false;
            
            _context.Remove(artistaToDelete);
            _context.SaveChanges();

            return true;
        }

        public bool Add(ArtistaResumo artistaToAdd)
        {
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                Artista artista = new Artista(artistaToAdd.Nome, artistaToAdd.Bio);

                _context.Add(artista);
                _context.SaveChanges();
                transaction.Commit();
                return true;
            }
            catch (Exception)
            {
                transaction.Rollback();
                return false;
            }
        }


    }

}
