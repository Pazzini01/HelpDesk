using HelpDesk.Models;

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
            Console.WriteLine(chamado.Titulo);
            Console.WriteLine(chamado.Descricao);
            Console.WriteLine(chamado.Condicao);
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
            // Recupera o chamado escolhido pelo usuário
            Chamado chamado = chamados[indice];

            // Exibe os dados atuais
            Console.WriteLine($"Título: {chamado.Titulo}");
            Console.WriteLine($"Descrição: {chamado.Descricao}");
            Console.WriteLine($"Condição atual: {chamado.Condicao}");

            // Apresenta as opções de condição
            Console.WriteLine("\nSelecione a nova condição:");
            Console.WriteLine("1 - Aberto");
            Console.WriteLine("2 - Em andamento");
            Console.WriteLine("3 - Concluído");

            // Lê a escolha do usuário
            string novaOpcao = Console.ReadLine();

            // Converte o texto para número
            if (int.TryParse(novaOpcao, out int condicao))
            {
                switch (condicao)
                {
                    case 1:
                        chamado.AlterarCondicao("Aberto");
                        break;

                    case 2:
                        chamado.AlterarCondicao("Em andamento");
                        break;

                    case 3:
                        chamado.AlterarCondicao("Concluído");
                        break;

                    default:
                        Console.WriteLine("Condição inválida!");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Digite um número válido!");
            }
        }
    }

}
void Sair()
{
    Console.WriteLine("Fechando aplicação...");
}