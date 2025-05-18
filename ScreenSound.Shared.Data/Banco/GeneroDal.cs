using ScreenSound.Banco;
using ScreenSound.Shared.Modelos.DTOs;
using ScreenSound.Shared.Modelos.Extensions;
using ScreenSound.Shared.Modelos.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenSound.Shared.Data.Banco
{
    public class GeneroDal
    {
        private readonly ScreenSoundContext _context;
        
        public GeneroDal(ScreenSoundContext context)
        {
            _context = context;
        }

        public IEnumerable<GeneroRequest> ListarItens()
        {
            var generos = _context.Generos.Select(g => g.ToOutput()).ToList();
            return generos;
        }

        public GeneroRequest GetById(int generoId)
        {
            var genero = _context.Generos.FirstOrDefault(g => g.Id == generoId);
    
            return genero?.ToOutput();

        }
        public GeneroRequest GetByName(string name) 
        {
            var genero = _context.Generos.FirstOrDefault(g => g.Nome.Replace(" ", "").Equals(name.Replace(" ","")));

            return genero?.ToOutput(); ;
        }

        public bool Add(GeneroRequest generoToAdd)
        {
            Genero generoExists = _context.Generos.FirstOrDefault(g => g.Nome.Replace(" ", "").Equals(generoToAdd.Name.Replace(" ","")));

            if (generoExists is not null) return false;

            var genero = generoToAdd.ToEntity();
            _context.Generos.Add(genero);
            _context.SaveChanges();
            return true;
        }

        public bool Update(GeneroRequest generoRequest, int idGenero)
        {
            var generoToUpdate = _context.Generos.FirstOrDefault(g => g.Id == idGenero);    
            if(generoToUpdate is null) return false;

            generoToUpdate.Nome =  generoRequest.Name;
            _context.SaveChanges(); 
            return true;
            
        }

        public bool Delete(int id)
        {
            var genero = _context.Generos.FirstOrDefault(g => g.Id == id);

            if(genero is null) return false;
            _context.Remove(genero);
            _context.SaveChanges();
            return true;
        }


    }
}
