using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenSound.Shared.Modelos.Modelos
{
    public class Genero
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public virtual List<GenerosMusica> GenerosMusicas { get; set; }
    }
}
