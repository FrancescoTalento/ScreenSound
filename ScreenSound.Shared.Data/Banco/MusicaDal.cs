using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using ScreenSound.Modelos;
using ScreenSound.Shared.Data.Banco;
using ScreenSound.Shared.Modelos.DTOs;
using ScreenSound.Shared.Modelos.Extensions;
using ScreenSound.Shared.Modelos.Modelos;
using System.Transactions;

namespace ScreenSound.Banco
{
    public class MusicaDal 
    {
        private readonly ScreenSoundContext _context;
        private readonly MusicasArtistasDal _musicasArtistasDal;
        private readonly GenerosMusicaDal _generosMusicaDal;
        private readonly GeneroDal _generoDal;
        public MusicaDal(ScreenSoundContext context) 
        {
            _context = context;
            _musicasArtistasDal = new MusicasArtistasDal(context);
            _generosMusicaDal = new GenerosMusicaDal(context);
            _generoDal = new GeneroDal(context);
        }

        // GETTING STUFF
        public  List<MusicaOutput> ListarItens()
        {
            var musicas = _context.Musicas.ToList();
            List<MusicaOutput> musicaOutputs = new List<MusicaOutput>();

            foreach (var item in musicas)
            {
                musicaOutputs.Add(this.CreateMusicOutput(item));
            }
            return musicaOutputs;
        }

        public MusicaOutput GetByName(string name)
        {
            var musica = _context.Musicas
                .FirstOrDefault(m => m.Nome.Replace(" ", "").Equals(name));
            if(musica is null)
            {
                return null;
            }

           return this.CreateMusicOutput(musica);
        }


        public MusicaOutput GetById(int id)
        { //add os generos no retorno
            try
            {
                var musica = _context.Musicas.FirstOrDefault(m => m.Id == id);

                if (musica is null)
                {
                    return null;
                }
                return this.CreateMusicOutput(musica);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }


        public IEnumerable<MusicaOutput> GetManyByYear(int year)
        {
            var musicas = _context.Musicas
                .Where(m => m.AnoLancamento == year)
                .ToList();

            if(!musicas.Any())
            {
                return null;
            }
            var list = musicas.Select(m => this.CreateMusicOutput(m));

            return list;
        }

        public MusicaOutput CreateMusicOutput(Musica musica)
        {
            ICollection<GeneroRequest> generoRequests = _generosMusicaDal.GetGenerosOfMusica(musica.Id);

            return musica.ToOutput(generoRequests);
        }

        public bool Add(MusicaInput musicaInput)
        {
            try
            {
                Musica musica = new Musica
                {
                    Nome = musicaInput.Nome,
                    AnoLancamento = musicaInput.AnoLancamento,
                };  

                _context.Musicas.Add(musica);
                _context.SaveChanges();

                // Criando os vinculos com a musica
                foreach (int id in musicaInput.IdArtistas)
                {
                    _musicasArtistasDal.Add(musica.Id, id);
                }
                
                foreach (int id in musicaInput.IdGenres)
                {
                    _generosMusicaDal.Add(musica.Id, id);
                }

            
                _context.SaveChanges();
                //transaction.Commit();
                return true;
            }
            catch (Exception)
            {
                //transaction.Rollback();
                return false;
            }

        }

        public bool Update(int musicaId, MusicaInput newValue)
        {
            var musicaToUpdate = _context.Musicas
                .FirstOrDefault(m => m.Id == musicaId);

            if (musicaToUpdate == null)
                return false;

            
            musicaToUpdate.Nome = newValue.Nome;
            musicaToUpdate.AnoLancamento = newValue.AnoLancamento;
            Console.WriteLine("entou aqui");
            // Atualiza relacionamento: artistas da música
            _musicasArtistasDal.UpdateRelacoes(
                filtro: ma => ma.MusicaId == musicaId,
                novaRelacao: artistaId => new MusicasArtista
                {
                    MusicaId = musicaId,
                    ArtistaId = artistaId
                },
                listaId: newValue.IdArtistas 
            );
            Console.WriteLine("saiu");

            // Atualiza relacionamento: generos da musica
            _generosMusicaDal.UpdateRelacoes(
                filtro: ma => ma.MusicaId == musicaId,
                novaRelacao: generoId => new GenerosMusica
                {
                    MusicaId = musicaId,
                    GeneroId = generoId
                },
                listaId: newValue.IdGenres
            );
            Console.WriteLine("saiu 3");
            _context.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            var musicaToDelete = _context.Musicas.FirstOrDefault(m => m.Id == id);
            if (musicaToDelete == null) return false;

            _context.Remove(musicaToDelete);
            _context.SaveChanges();
            return true;
        }



        

    }

}
