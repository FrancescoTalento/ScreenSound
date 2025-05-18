//using ScreenSound.Banco;
//using ScreenSound.Modelos;

//namespace ScreenSound.Menus;

//internal class MenuRegistrarMusica : Menu
//{
//    public override void Executar() // ArtistaDal MusicaDal
//    {
//        base.Executar();
//        ExibirTituloDaOpcao("Registro de músicas");
//        Console.Write("Digite o artista cuja música deseja registrar: ");
//        string nomeDoArtista = Console.ReadLine()!;
//        Artista artistaToGet = ArtistaDal.GetByName(nomeDoArtista);
//        if (artistaToGet is not null)
//        {
//            Console.Write("Agora digite o título da música: ");
//            string tituloDaMusica = Console.ReadLine()!;

//            Console.Write("Agora digite o ano de lancamento da música: ");
//            int anoLancamentoDaMusica = int.Parse(Console.ReadLine()!);
//            MusicaDal.Add(new Musica(tituloDaMusica,anoLancamentoDaMusica), artistaToGet.Id);
//            Console.WriteLine($"A música {tituloDaMusica}, do ano {anoLancamentoDaMusica}, made by {nomeDoArtista} foi registrada com sucesso!");
            
//            Console.Clear();
//        }
//        else
//        {
//            Console.WriteLine($"\nO artista {nomeDoArtista} não foi encontrado!");
//            Console.WriteLine("Digite uma tecla para voltar ao menu principal");
//            Console.ReadKey();
//            Console.Clear();
//        }
//    }
//}
