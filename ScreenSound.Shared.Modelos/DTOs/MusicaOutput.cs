using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenSound.Shared.Modelos.DTOs
{
    public class MusicaOutput
    {
        public int Id { get; set; } 
        public string Nome { get; set; }
        public int? AnoDeLancamento { get; set; }

        public ICollection<GeneroRequest> GenerosRequest { get; set; }
    }
}
