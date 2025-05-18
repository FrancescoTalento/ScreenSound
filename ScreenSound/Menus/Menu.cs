using ScreenSound.Banco;
using ScreenSound.Modelos;

namespace ScreenSound.Menus;

internal class Menu
{
    protected ArtistaDal ArtistaDal{ get; set; }
    protected MusicaDal MusicaDal{ get; set; }
    protected MusicasArtistasDal MusicasArtistasDal{ get; set; }

    public void ExibirTituloDaOpcao(string titulo)
    {
        int quantidadeDeLetras = titulo.Length;
        string asteriscos = string.Empty.PadLeft(quantidadeDeLetras, '*');
        Console.WriteLine(asteriscos);
        Console.WriteLine(titulo);
        Console.WriteLine(asteriscos + "\n");
    }

    public Menu SetDependencies(ArtistaDal artistaDal = null, MusicasArtistasDal musicasArtistasDal = null, MusicaDal musicaDal = null)
    {
        ArtistaDal = artistaDal;
        MusicaDal = musicaDal;
        MusicasArtistasDal = musicasArtistasDal;
        return this;
    }
    public virtual void Executar()
    {
        Console.Clear();
    }
}
