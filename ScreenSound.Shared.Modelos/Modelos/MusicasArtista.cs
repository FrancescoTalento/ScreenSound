using ScreenSound.Modelos;

namespace ScreenSound.Modelos
{
    public class MusicasArtista
    {
        public int ArtistaId { get; set; }
        public virtual Artista Artista { get; set; }

        public int MusicaId { get; set; }
        public virtual Musica Musica { get; set; }
    }
}
