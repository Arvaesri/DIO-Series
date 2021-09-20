using System;
using DIO.Series.Classes;

namespace DIO.Series
{
    class Program
    {
        static SerieRepositorio repositorioSerie = new SerieRepositorio();
        static FilmeRepositorio repositorioFilme = new FilmeRepositorio();
        static void Main(string[] args)
        {
            Console.WriteLine("Digite o Menu Desejado: ");
            Console.WriteLine("1 - Menu de Séries: ");
            Console.WriteLine("2 - Menu de Filmes: ");
            Console.WriteLine();

            int menuSelecionado = int.Parse(Console.ReadLine());
            
            switch (menuSelecionado)
            {
                case 1:
                    MenuSeries();
                    break;
                case 2:
                    MenuFilmes();
                    break;
                default:
                    throw new ArgumentOutOfRangeException("Digite uma das opções (1 ou 2)");
            }
                


        }



        private static void InserirSerie()
            {
                Console.WriteLine("Nova Série");

                foreach (int i in (Enum.GetValues(typeof(Genero))))
                {
                    Console.WriteLine("{0} - {1}", i,Enum.GetName(typeof(Genero),i));
                    Console.WriteLine();
                }
                Console.WriteLine("Digite o genêro entre as opções acima: ");
                int entradaGenero = int.Parse(Console.ReadLine());

                Console.WriteLine("Digite o Titulo da Série: ");
                string entradaTitulo = Console.ReadLine();

                Console.WriteLine("Digite o Ano da Série: ");
                int entradaAno = int.Parse(Console.ReadLine());

                Console.WriteLine("Digite a Descrição da Série: ");
                string entradaDescricao = Console.ReadLine();
            
                Serie novaSerie = new Serie(Id: repositorioSerie.ProximoId(),genero: (Genero)entradaGenero,Titulo: entradaTitulo,Ano: entradaAno, Descricao: entradaDescricao);

                repositorioSerie.Insere(novaSerie);
            }        
        
        private static void InserirFilme()
            {
                Console.WriteLine("NovoFilme");

                foreach (int i in (Enum.GetValues(typeof(Genero))))
                {
                    Console.WriteLine("{0} - {1}", i,Enum.GetName(typeof(Genero),i));
                    Console.WriteLine();
                }
                Console.WriteLine("Digite o genêro entre as opções acima: ");
                int entradaGenero = int.Parse(Console.ReadLine());

                Console.WriteLine("Digite o Titulo do Filme: ");
                string entradaTitulo = Console.ReadLine();

                Console.WriteLine("Digite o Ano do Filme: ");
                int entradaAno = int.Parse(Console.ReadLine());

                Console.WriteLine("Digite a Descrição do Filme: ");
                string entradaDescricao = Console.ReadLine();
            
                Filme novoFilme = new Filme(Id: repositorioFilme.ProximoId(),genero: (Genero)entradaGenero,Titulo: entradaTitulo,Ano: entradaAno, Descricao: entradaDescricao);

                repositorioFilme.Insere(novoFilme);
            }

        private static void ListarSeries()
            {
                Console.WriteLine("Listar Séries");

                var lista = repositorioSerie.Lista();

                if(lista.Count == 0)
                {
                    Console.WriteLine("Nenhuma Série Cadastrada");
                    Console.WriteLine();
                    return;
                }

                foreach (var serie in lista)
                {
                    var excluido = serie.retornaExcluido();
                    Console.WriteLine("#ID {0}: - {1} - {2} ", serie.retornaId(),serie.retornaTitulo(),(excluido ? "*Excluido*" : ""));
                    Console.WriteLine();
                }
            }

        private static void ListarFilmes()
            {
                Console.WriteLine("Listar Filmes");

                var lista = repositorioFilme.Lista();

                if(lista.Count == 0)
                {
                    Console.WriteLine("Nenhuma Filme Cadastrado");
                    Console.WriteLine();
                    return;
                }

                foreach (var filme in lista)
                {
                    var excluido = filme.retornaExcluido();
                    Console.WriteLine("#ID {0}: - {1} - {2} ", filme.retornaId(),filme.retornaTitulo(),(excluido ? "*Excluido*" : ""));
                    Console.WriteLine();
                }
            }            

        private static void AtualizarSerie()
        {
            Console.WriteLine("Digite o Id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());
            Console.WriteLine();
            foreach (int i in (Enum.GetValues(typeof(Genero))))
            {
                Console.WriteLine("{0} - {1}", i,Enum.GetName(typeof(Genero),i));
                Console.WriteLine();
            }
            Console.WriteLine("Digite o genêro entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o Titulo da Série: ");
            string entradaTitulo = Console.ReadLine();

            Console.WriteLine("Digite o Ano da Série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a Descrição da Série: ");
            string entradaDescricao = Console.ReadLine();
        
            Serie atualizaSerie = new Serie(Id: indiceSerie,genero: (Genero)entradaGenero,Titulo: entradaTitulo,Ano: entradaAno, Descricao: entradaDescricao);
            repositorioSerie.Atualiza(indiceSerie,atualizaSerie);
        }
        
        private static void AtualizarFilme()
        {
            Console.WriteLine("Digite o Id do Filme: ");
            int indiceFilme = int.Parse(Console.ReadLine());
            Console.WriteLine();
            foreach (int i in (Enum.GetValues(typeof(Genero))))
            {
                Console.WriteLine("{0} - {1}", i,Enum.GetName(typeof(Genero),i));
                Console.WriteLine();
            }
            Console.WriteLine("Digite o genêro entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o Titulo do Filme: ");
            string entradaTitulo = Console.ReadLine();

            Console.WriteLine("Digite o Ano do Filme: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a Descrição do Filme: ");
            string entradaDescricao = Console.ReadLine();
        
            Filme atualizaFilme = new Filme(Id: indiceFilme,genero: (Genero)entradaGenero,Titulo: entradaTitulo,Ano: entradaAno, Descricao: entradaDescricao);
            repositorioFilme.Atualiza(indiceFilme,atualizaFilme);
        }
    
        private static void ExcluirSerie()
        {
            Console.WriteLine("Digite o ID: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            var serie = repositorioSerie.RetornaPorId(indiceSerie);
            serie.Excluir();
            Console.WriteLine("Série Excluida");
            Console.WriteLine();
            
        }
        
        private static void ExcluirFilme()
        {
            Console.WriteLine("Digite o ID: ");
            int indiceFilme = int.Parse(Console.ReadLine());

            var filme = repositorioFilme.RetornaPorId(indiceFilme);
            filme.Excluir();
            Console.WriteLine("Filme Excluido");
            Console.WriteLine();
            
        }
        
        private static void VisualizarSerie()
        {
            Console.WriteLine("Digite o ID: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            var serie = repositorioSerie.RetornaPorId(indiceSerie);
            Console.WriteLine(serie);
            Console.WriteLine();
        }
        
        private static void VisualizarFilme()
        {
            Console.WriteLine("Digite o ID: ");
            int indiceFilme = int.Parse(Console.ReadLine());

            var filme = repositorioFilme.RetornaPorId(indiceFilme);
            Console.WriteLine(filme);
            Console.WriteLine();
        }
        
        public static string ObterOpcaoUsuario() 
            {
            Console.WriteLine("______DIO Séries______");
            Console.WriteLine();
            Console.WriteLine("Informe a opção desejada:");
            Console.WriteLine("1 - Listar Séries");
            Console.WriteLine("2 - Inserir Séries");
            Console.WriteLine("3 - Atualizar Séries");
            Console.WriteLine("4 - Excluir Série");
            Console.WriteLine("5 - Visualizar Série");
            Console.WriteLine("C - Limpar Tela");
            Console.WriteLine("F - Opções Para Filmes");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
            }
    
        public static string ObterOpcaoUsuarioFilmes()
        {
            Console.WriteLine("______DIO Filmes______");
            Console.WriteLine();
            Console.WriteLine("Informe a opção desejada:");
            Console.WriteLine("1 - Listar Filmes");
            Console.WriteLine("2 - Inserir Filme");
            Console.WriteLine("3 - Atualizar Filme");
            Console.WriteLine("4 - Excluir Filme");
            Console.WriteLine("5 - Visualizar Filme");
            Console.WriteLine("C - Limpar Tela");
            Console.WriteLine("F - Opções Para Series");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    
        private static void MenuSeries()
        {
            string opcaoUsuario = ObterOpcaoUsuario();
            while(opcaoUsuario.ToUpper()!="X")
            {
                switch(opcaoUsuario)
                {
                    case "1":
                        ListarSeries();
                        break;
                    case "2":
                        InserirSerie();
                        break;
                    case "3":
                        AtualizarSerie();
                        break;
                    case "4":
                        ExcluirSerie();
                        break;
                    case "5":
                        VisualizarSerie();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    case "F":
                        MenuFilmes();
                        break; 
                    default:
                        throw new ArgumentOutOfRangeException();                                           


                }
                opcaoUsuario = ObterOpcaoUsuario();
            }
        }

        private static void MenuFilmes()
        {
            string opcaoUsuarioFilmes = ObterOpcaoUsuarioFilmes();
            while(opcaoUsuarioFilmes.ToUpper()!="X")
            {
                switch(opcaoUsuarioFilmes)
                {
                    case "1":
                        ListarFilmes();
                        break;
                    case "2":
                        InserirFilme();
                        break;
                    case "3":
                        AtualizarFilme();
                        break;
                    case "4":
                        ExcluirFilme();
                        break;
                    case "5":
                        VisualizarFilme();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    case "F":
                        MenuSeries();
                        break; 
                    default:
                        throw new ArgumentOutOfRangeException();                                           


                }
                opcaoUsuarioFilmes = ObterOpcaoUsuarioFilmes();
            }
        }
    
    }
}
