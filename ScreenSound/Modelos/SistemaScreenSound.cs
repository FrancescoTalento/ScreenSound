//using ScreenSound.Banco;
//using ScreenSound.Menus;
//using ScreenSound.Modelos;

//namespace ScreenSound
//{
//    internal class SistemaScreenSound
//    {
//        private readonly Dictionary<int, Menu> opcoes = new();
//        private readonly ArtistaDal _artistaDal;
//        private readonly MusicasArtistasDal _musicasArtistasDal;
//        private readonly MusicaDal _musicaDal; 
//        public SistemaScreenSound(ArtistaDal artistaDal, MusicasArtistasDal musicasArtistasDal, MusicaDal musicaDal)
//        {
          
//            this._artistaDal = artistaDal;
//            _musicasArtistasDal = musicasArtistasDal;
//            _musicaDal = musicaDal;
//            InicializarMenus();
//        }

//        private void InicializarMenus()
//        {
//            opcoes.Add(1, new MenuRegistrarArtista().SetDependencies(_artistaDal));
//            opcoes.Add(2, new MenuRegistrarMusica().SetDependencies(_artistaDal, musicaDal: _musicaDal));
//            opcoes.Add(3, new MenuMostrarArtistas().SetDependencies(_artistaDal));
//            opcoes.Add(4, new MenuMostrarMusicas().SetDependencies(_artistaDal, _musicasArtistasDal));
//            opcoes.Add(5, new MenuMostrarMusicaPorAno().SetDependencies(musicaDal: _musicaDal));
//            opcoes.Add(-1, new MenuSair());
//        }

//        public void Iniciar()
//        {
//            ExibirMenu();
//        }

//        private void ExibirMenu()
//        {
//            while (true)
//            {
//                ExibirLogo();
//                Console.WriteLine("\nDigite 1 para registrar um artista");
//                Console.WriteLine("Digite 2 para registrar a música de um artista");
//                Console.WriteLine("Digite 3 para mostrar todos os artistas");
//                Console.WriteLine("Digite 4 para exibir todas as músicas de um artista");
//                Console.WriteLine("Digite 5 para exibir todas as músicas de um Ano especifico");
//                Console.WriteLine("Digite -1 para sair");

//                Console.Write("\nDigite a sua opção: ");
//                if (!int.TryParse(Console.ReadLine(), out int opcaoEscolhidaNumerica))
//                {
//                    Console.WriteLine("Entrada inválida.");
//                    continue;
//                }

//                if (opcoes.TryGetValue(opcaoEscolhidaNumerica, out Menu? menu))
//                {
//                    menu.Executar();
//                    if (opcaoEscolhidaNumerica == -1) break;
//                }
//                else
//                {
//                    Console.WriteLine("Opção inválida.");
//                }
//            }
//        }

//        private void ExibirLogo()
//        {
//            Console.Clear();
//            Console.WriteLine(@"
//░██████╗░█████╗░██████╗░███████╗███████╗███╗░░██╗  ░██████╗░█████╗░██╗░░░██╗███╗░░██╗██████╗░
//██╔════╝██╔══██╗██╔══██╗██╔════╝██╔════╝████╗░██║  ██╔════╝██╔══██╗██║░░░██║████╗░██║██╔══██╗
//╚█████╗░██║░░╚═╝██████╔╝█████╗░░█████╗░░██╔██╗██║  ╚█████╗░██║░░██║██║░░░██║██╔██╗██║██║░░██║
//░╚═══██╗██║░░██╗██╔══██╗██╔══╝░░██╔══╝░░██║╚████║  ░╚═══██╗██║░░██║██║░░░██║██║╚████║██║░░██║
//██████╔╝╚█████╔╝██║░░██║███████╗███████╗██║░╚███║  ██████╔╝╚█████╔╝╚██████╔╝██║░╚███║██████╔╝
//╚═════╝░░╚════╝░╚═╝░░╚═╝╚══════╝╚══════╝╚═╝░░╚══╝  ╚═════╝░░╚════╝░░╚═════╝░╚═╝░░╚══╝╚═════╝░
//");
//            Console.WriteLine("Boas vindas ao Screen Sound 3.0!");
//        }
//    }
//}
