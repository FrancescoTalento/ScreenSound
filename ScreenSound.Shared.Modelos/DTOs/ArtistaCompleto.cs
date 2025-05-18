using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenSound.Shared.Modelos.DTOs
{
    public record ArtistaCompleto
    {
        public int Id { get; set; }
        public string Nome {  get; set; }
        public string Bio { get; set; }
        public List<MusicaOutput> MusicasDoArtista { get; set; }
    }
}
