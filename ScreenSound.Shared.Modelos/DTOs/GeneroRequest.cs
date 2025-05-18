using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenSound.Shared.Modelos.DTOs
{
    public record GeneroRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
