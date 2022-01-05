using System;

namespace DIO.Carros
{
    class Program
    {
        static CarroRepositorio repositorio = new CarroRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() !="X")
            {
                 switch (opcaoUsuario)
                 {
                     case "1":
                        ListarCarro();
                        break;
                    case "2":
                        InserirCarro();
                        break;
                    case "3":
                        AtualizarCarro();
                        break;
                    case "4":
                        ExcluirCarro();
                        break;
                    case "5":
                        VisualizarCarro();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    
                    default:
                        throw new ArgumentOutOfRangeException();    
                 }

                 opcaoUsuario = ObterOpcaoUsuario();
            }

            Console.WriteLine("Obrigado por utilizar nossos serviços.");
            Console.ReadLine();
        }

        private static void ListarCarro()
        {
            Console.WriteLine("Listar carros");
            var lista = repositorio.Lista();
            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhum carro cadastrado.");
                return;
            }
            foreach (var carro in lista)
            {
                var excluido = carro.retornaExcluido();
                if(!excluido)
                {
                    Console.WriteLine("#ID {0}: - {1}", carro.retornaId(), carro.retornaMarca());
                }
            }
        }
        private static void InserirCarro()
        {
            Console.WriteLine("Inserir novo carro");
            
            foreach (int i in Enum.GetValues(typeof(Cor)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Cor), i));
            }
            Console.WriteLine("Digite a cor entre as opções acima: ");
            int entradaCor =int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a marca do carro: ");
            string entradaMarca =Console.ReadLine();

            Console.WriteLine("Digite o ano do carro: ");
            int entradaAno =int.Parse(Console.ReadLine());

            Console.WriteLine("Digite as características do carro: ");
            string entradaDescricao = Console.ReadLine();

            Carro novoCarro = new Carro(id: repositorio.ProximoId(),
                                         cor:    (Cor)entradaCor,
                                         marca:     entradaMarca,
                                         ano:        entradaAno,
                                         descricao:  entradaDescricao);
            
            repositorio.Insere(novoCarro);
        }
        private static void AtualizarCarro()
        {
            Console.WriteLine("Digite o id do carro");
            int indiceCarro = int.Parse(Console.ReadLine());
            
            foreach (int i in Enum.GetValues(typeof(Cor)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Cor), i));
            }
            Console.WriteLine("Digite a cor entre as opções acima: ");
            int entradaCor =int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a marca do carro: ");
            string entradaMarca =Console.ReadLine();

            Console.WriteLine("Digite o ano do carro: ");
            int entradaAno =int.Parse(Console.ReadLine());

            Console.WriteLine("Digite as características do carro: ");
            string entradaDescricao = Console.ReadLine();

            Carro atualizaCarro = new Carro(id: indiceCarro,
                                         cor:    (Cor)entradaCor,
                                         marca:     entradaMarca,
                                         ano:        entradaAno,
                                         descricao:  entradaDescricao);
            
            repositorio.Atualiza(indiceCarro, atualizaCarro);
        }

        private static void ExcluirCarro()
        {
            Console.WriteLine("Digite o id do carro: ");
            int indiceCarro = int.Parse(Console.ReadLine());

            repositorio.Exclui(indiceCarro);
        }

        private static void VisualizarCarro()
        {
            Console.WriteLine("Digite o id do carro: ");
            int indiceCarro = int.Parse(Console.ReadLine());

            var carro = repositorio.RetornaPorID(indiceCarro);

            Console.WriteLine(carro);
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("DIO Carros a seu dispor!!!");
            Console.WriteLine("Informe a opção desejada");

            Console.WriteLine("1- Listar Carros");
            Console.WriteLine("2- Inserir novo Carro");
            Console.WriteLine("3- Atualizar Carro");
            Console.WriteLine("4- Excluir Carro");
            Console.WriteLine("5- Visualizar Carro");
            Console.WriteLine("C- Limpar Tela");
            Console.WriteLine("X- Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
