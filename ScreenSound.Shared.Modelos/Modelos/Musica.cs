using ScreenSound.Shared.Modelos.Modelos;

namespace ScreenSound.Modelos;

public class Musica
{
    public virtual List<MusicasArtista> MusicasArtistas { get; set; } = new();
    public virtual List<GenerosMusica> GenerosMusicas{ get; set; }
    public Musica() { }

    public Musica(string nome, int anoLancamento)
    {
        Nome = nome;
        AnoLancamento = anoLancamento;
    }
    
    public string Nome { get; set; }
    public int Id { get; set; }
    public int? AnoLancamento { get; set; }


    public void ExibirFichaTecnica()
    {
        Console.WriteLine($"Nome: {Nome}");
      
    }

    public override string ToString()
    {
        return @$"Id: {Id}
        Nome: {Nome}";
    }
}