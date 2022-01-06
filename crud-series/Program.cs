using System;
using crud_series.Classes;


namespace crud_series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = obterOpcaoUsuario();
            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
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
                    case "L":
                        Console.Clear();
                        break;
                    default:
                    throw new ArgumentOutOfRangeException();
                }
            }
        }
           private static void ListarSeries()
		{
			System.Console.WriteLine("Listar séries");

			var lista = repositorio.Lista();

			if (lista.Count == 0)
			{
				System.Console.WriteLine("Nenhuma série cadastrada.");
				return;
			}

			foreach (var serie in lista)
			{  
                var excluido = serie.retornaExcluir();
				System.Console.WriteLine("#ID {0}: - {1} {2}", serie.retornaId(), serie.retornaTitulo(), (excluido ? "*Excluído*" : ""));
			}
		}
         private static void InserirSerie()
		{
			System.Console.WriteLine("Inserir nova série");
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                {
                    Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
                }
                System.Console.Write("Digite o gênero entre as opções acima: ");
                int entradaGenero = int.Parse(Console.ReadLine());

                System.Console.Write("Digite o Título da Série: ");
                string entradaTitulo = Console.ReadLine();

                System.Console.Write("Digite o Ano de Início da Série: ");
                int entradaAno = int.Parse(Console.ReadLine());

                System.Console.Write("Digite a Descrição da Série: ");
                string entradaDescricao = Console.ReadLine();

                Series novaSerie = new Series(id: repositorio.ProximoId(),
                                            genero: (Genero)entradaGenero,
                                            titulo: entradaTitulo,
                                            ano: entradaAno,
                                            descricao: entradaDescricao);

                repositorio.Insere(novaSerie);
            }
        }
          private static void AtualizarSerie()
		{
			System.Console.Write("Digite o id da série: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				System.Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			System.Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			System.Console.Write("Digite o Título da Série: ");
			string entradaTitulo = Console.ReadLine();

			System.Console.Write("Digite o Ano de Início da Série: ");
			int entradaAno = int.Parse(Console.ReadLine());

			System.Console.Write("Digite a Descrição da Série: ");
			string entradaDescricao = Console.ReadLine();

			Series atualizarSerie = new Series(id: indiceSerie,
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);

			repositorio.Atualizar(indiceSerie, atualizarSerie);
		}
          private static void ExcluirSerie()
		{
			System.Console.Write("Digite o id da série: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			repositorio.Excluir(indiceSerie);
		}

        private static void VisualizarSerie()
		{
			System.Console.Write("Digite o id da série: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			var serie = repositorio.RetornaPorId(indiceSerie);

			System.Console.WriteLine(serie);
		}
        
        private static string obterOpcaoUsuario()
        {
            System.Console.WriteLine();
            System.Console.WriteLine("Séries disponíveis!");
            System.Console.WriteLine("Escolha a opção desejada:");

            System.Console.WriteLine("1 - Listar Séries");
            System.Console.WriteLine("2 - Inserir nova Série");
            System.Console.WriteLine("3 - Atualizar Série");
            System.Console.WriteLine("4 - Excuir Série");
            System.Console.WriteLine("5 - Visualizar Série");
            System.Console.WriteLine("L - Limpar Série");
            System.Console.WriteLine("X - Excluir Série");
            System.Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            System.Console.WriteLine();
            return opcaoUsuario;
        }
    }
}