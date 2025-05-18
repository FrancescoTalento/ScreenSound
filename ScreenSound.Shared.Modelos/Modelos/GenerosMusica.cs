using ScreenSound.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenSound.Shared.Modelos.Modelos
{
    public class GenerosMusica
    {
        public int MusicaId { get; set; }
        public virtual Musica Musica{ get; set; }


        public int GeneroId { get; set; }
        public virtual Genero Genero { get; set; }
        

    }
}
