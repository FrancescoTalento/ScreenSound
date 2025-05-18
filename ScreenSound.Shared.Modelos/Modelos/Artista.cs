using ScreenSound.Shared.Modelos.Modelos;

namespace ScreenSound.Modelos;
//using Banco;

public class Artista 
{
    public virtual List<MusicasArtista> MusicasArtistas { get; set; } = new();
    
    public Artista(string nome, string bio)
    {
        Nome = nome;
        Bio = bio;
        FotoPerfil = "https://cdn.pixabay.com/photo/2016/08/08/09/17/avatar-1577909_1280.png";
       // Inicializar();

    }

    public string Nome { get; set; }
    public string FotoPerfil { get; set; }
    public string Bio { get; set; }
    public int Id { get; set; }

    

    //private void Inicializar()
    //{
    //    MusicasArtistasDal musicasArtistasDal = new MusicasArtistasDal(new ScreenSoundContext());
    //}
    public override string ToString()
    {
        return $@"Id: {Id}
            Nome: {Nome}
            Foto de Perfil: {FotoPerfil}
            Bio: {Bio}";
    }
}