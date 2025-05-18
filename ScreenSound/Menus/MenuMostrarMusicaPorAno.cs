//using ScreenSound.Banco;
//using ScreenSound.Menus;

//internal class MenuMostrarMusicaPorAno : Menu
//{
//    public override void Executar()
//    {
//        base.Executar();

//        ExibirTituloDaOpcao("Exibindo todas as músicas de um certo ano");
//        Console.Write("Digite um ano para buscar músicas: ");
//        int yearToGetMusicas = int.Parse(Console.ReadLine());

//        ExibirTituloDaOpcao($"Músicas do Ano: {yearToGetMusicas}");

//        var musicas = MusicaDal.GetManyBy(m => m.AnoLancamento == yearToGetMusicas);

//        if (!musicas.Any())
//        {
//            Console.WriteLine("Nenhuma música encontrada para esse ano.");
//        }
//        else
//        {
//            foreach (var item in musicas)
//            {
//                Console.WriteLine(item.Nome); // ou outro formato que quiser
//            }
//        }

//        Console.WriteLine("\nDigite uma tecla para voltar ao menu principal");
//        Console.ReadKey();
//        Console.Clear();
//    }
//}
