using HelpDesk.Models;

Console.WriteLine("================================");
Console.WriteLine("    CENTRAL DE ATENDIMENTO");
Console.WriteLine("================================\n");

Console.WriteLine("Bem-vindo ao HelpDesk!\n");

//while do menu
List<Chamado> chamados = new List<Chamado>();
    int opcao = 0;
while (opcao != 4)
{
    ExibirMenu();

    string entrada = Console.ReadLine();

    if (int.TryParse(entrada, out opcao))
    {
        switch (opcao)
        {
            case 1:
                AbrirChamado();
                break;

            case 2:
                ListarChamado();
                break;

            case 3:
                ConsultarChamado();
                break;

            case 4:
                Sair();
                break;

            default:
                Console.WriteLine("Opção inválida!\n");
                break;
        }
    }
    else
    {
        Console.WriteLine("Digite um número válido!\n");
    }

}
//while do menu FINAL....


//METODOS....
void ExibirMenu()
{
    Console.WriteLine("1 - Abrir chamado");
    Console.WriteLine("2 - Listar chamados");
    Console.WriteLine("3 - Consultar chamado");
    Console.WriteLine("4 - Sair");
}

void AbrirChamado()
{
    Console.WriteLine("Digite o título do chamado");
    string titulo = Console.ReadLine();
    Console.WriteLine("Digite a descrição do chamado");
    string descricao = Console.ReadLine();
    Chamado chamado = new Chamado();
    chamado.AlterarTitulo(titulo);
    chamado.AlterarDescricao(descricao);
    chamados.Add(chamado);
    Console.WriteLine("Chamado criado com sucesso!");
}

void ListarChamado()
{

    if (chamados.Count == 0)
    {
        Console.WriteLine("Não existem chamados abertos.");
    }

    else
    {
        Console.WriteLine("Lista de chamados:\n");

        int contador = 1;

        foreach (Chamado chamado in chamados)
        {
            Console.WriteLine($"Chamado {contador}");
            Console.WriteLine($"Título: {chamado.Titulo}");
            Console.WriteLine($"Descrição: {chamado.Descricao}\n");

            contador++;
        }
    }
}

void ExibirDadosChamado(int protocolo, string chamado)
{
    Console.WriteLine($"Chamado: {chamado}\nProtocolo: {protocolo}");
}

void ConsultarChamado()
 {
   //não decidi ainda oq essa função vai fazer
 }

void Sair()
 {
  Console.WriteLine("Fechando aplicação...");
 }

//FINAL METODOS...