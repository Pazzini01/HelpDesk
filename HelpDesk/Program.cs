using HelpDesk.Models;
using Microsoft.Win32;

Console.WriteLine("================================");
Console.WriteLine("    CENTRAL DE ATENDIMENTO");
Console.WriteLine("================================\n");

Console.WriteLine("Bem-vindo ao HelpDesk!\n");

//while do menu
List<Chamado> chamados = new List<Chamado>();
    int opcao = 0;
while (opcao != 5)
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
                AdministrarChamado();
                break;

            case 5:
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


//METODOS....
void ExibirMenu()
{
    Console.WriteLine("1 - Abrir chamado");
    Console.WriteLine("2 - Listar chamados");
    Console.WriteLine("3 - Consultar chamado");
    Console.WriteLine("4 - Administrar chamado");
    Console.WriteLine("5 - Sair");
}

void AbrirChamado()
{
    Console.WriteLine("Digite o título do chamado");
    string titulo = Console.ReadLine();
    Console.WriteLine("Digite a descrição do chamado");
    string descricao = Console.ReadLine();
    try
    {
        Chamado chamado = new Chamado(titulo, descricao);
        chamados.Add(chamado);
        Console.WriteLine("Chamado criado com sucesso!");
    }

    catch (ArgumentException ex)
    {
      Console.WriteLine("Falha na criação do chamado:" + ex.Message);
    }
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

int id = -1;
void ConsultarChamado()
{
    Console.WriteLine("Selecione o número do chamado");
    string consulta = Console.ReadLine();
    if (int.TryParse(consulta, out id))
    {
        int indice = id - 1;

        if (indice < 0 || indice >= chamados.Count)
        {
            Console.WriteLine("Chamado não encontrado!");
        }
        else
        {
            Chamado chamado = chamados[indice];
            Console.WriteLine($"Titulo:\n{chamado.Titulo}");
            Console.WriteLine($"Descrição:\n{chamado.Descricao}");
            Console.WriteLine($"Status:\n{chamado.Condicao}\n");
            Console.WriteLine("Histórico:\n");
            foreach (Historico registro in chamado.Historico)
            {

                Console.WriteLine($"{registro.DataHora.ToString("dd/MM/yyyy HH:mm")} - {registro.Descricao}");
            }
           
        }
    }
    else
    {
        Console.WriteLine("Digite um número válido!");
    }
    
}


void AdministrarChamado()
{
    Console.WriteLine("Selecione o número do chamado");
    string consulta = Console.ReadLine();

    if (int.TryParse(consulta, out id))
    {
        int indice = id - 1;

        if (indice < 0 || indice >= chamados.Count)
        {
            Console.WriteLine("Chamado não encontrado!");
        }
        else
        {
            Chamado chamado = chamados[indice];

            Console.WriteLine($"Título: {chamado.Titulo}");
            Console.WriteLine($"Descrição: {chamado.Descricao}");
            Console.WriteLine($"Condição atual: {chamado.Condicao}");

            Console.WriteLine("\nSelecione a nova condição:");
            Console.WriteLine("1 - Aberto");
            Console.WriteLine("2 - Em andamento");
            Console.WriteLine("3 - Concluído");

            string novaOpcao = Console.ReadLine();

            switch (novaOpcao)
            {
                case "1":
                    chamado.AlterarCondicao("Aberto");
                    Console.WriteLine("Condição atualizada com sucesso!");
                    break;

                case "2":
                    chamado.AlterarCondicao("Em andamento");
                    Console.WriteLine("Condição atualizada com sucesso!");
                    break;

                case "3":
                    chamado.AlterarCondicao("Concluído");
                    Console.WriteLine("Condição atualizada com sucesso!");
                    break;

                default:
                    Console.WriteLine("Condição inválida!");
                    break;
            }
        }
    }
    else
    {
        Console.WriteLine("Digite um número válido!");
    }
}

void Sair()
{
    Console.WriteLine("Fechando aplicação...");
}