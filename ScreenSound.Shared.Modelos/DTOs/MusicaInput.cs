using ScreenSound.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ScreenSound.Shared.Modelos.DTOs
{
    public record MusicaInput
    {
 
        [Required]
        public string Nome { get; set; }
        
        [Required]
        public int? AnoLancamento { get; set; }

        [Required]
        public List<int> IdArtistas { get; set; }

        
        public List<int> IdGenres { get; set; }
    }
}
