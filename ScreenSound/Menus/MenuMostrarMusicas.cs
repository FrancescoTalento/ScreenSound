//using ScreenSound.Banco;
//using ScreenSound.Modelos;

//namespace ScreenSound.Menus;

//internal class MenuMostrarMusicas : Menu
//{
//    public override void Executar() // ArtistaDal MusicasArtistasDall
//    {
//        base.Executar();
//        ExibirTituloDaOpcao("Exibir detalhes do artista");
//        Console.Write("Digite o nome do artista que deseja conhecer melhor: ");
//        string nomeDoArtista = Console.ReadLine()!;
//        Artista artistaToGet = ArtistaDal.GetByName(nomeDoArtista);
//        if (artistaToGet is not null)
//        {
//            var Discoteria = MusicasArtistasDal.GetMusicasByArtista(artistaToGet.Id);

//            Console.WriteLine("\nDiscografia:");
//            foreach (var item in Discoteria)
//            {
//                Console.WriteLine($"Nome:{item.Nome} -- Ano:{item.AnoLancamento}");
//            }
//            Console.WriteLine("\nDigite uma tecla para voltar ao menu principal");
//            Console.ReadKey();
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
