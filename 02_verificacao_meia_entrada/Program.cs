int idadeDoCliente = 0;
bool menorDeIdade = false;
int maiorIdade = 18;
bool estudande = false;
decimal precoFinalExibicao = 0M;
decimal precoInteira = 40;
decimal divisorMeiaEntrada = 2;
decimal precoMeiaEntrada = precoInteira / divisorMeiaEntrada;



Console.WriteLine("Preço da entrada inteira: " + precoInteira);
Console.WriteLine("Preço da meia entrada: " + precoMeiaEntrada);

estudande = VerificarSeTemCarteiraDeEstudante();
idadeDoCliente = VerificarIdadeDoCliente();

menorDeIdade = idadeDoCliente < maiorIdade;
precoFinalExibicao = menorDeIdade || estudande ? precoMeiaEntrada : precoInteira;

Console.WriteLine("Preço final: " + precoFinalExibicao);

static int VerificarIdadeDoCliente()
{
    Console.WriteLine("Digite sua idade: ");
    string input = Console.ReadLine();

    if (!int.TryParse(input, out int idade) || idade < 0)
    {
        Console.WriteLine();
        Console.WriteLine("Idade inválida. Tente novamente.");
        throw new ArgumentException("Idade inválida. Tente novamente.");
    }

    return idade;
}

static bool VerificarSeTemCarteiraDeEstudante()
{
    Console.WriteLine("Possui carteira de estudante?");
    Console.WriteLine("Digite 's' para Sim e 'n' para Não");
    string respostaCarteiraDeEstudante = Console.ReadKey().KeyChar.ToString();
    Console.WriteLine();
    if (respostaCarteiraDeEstudante != "s" && respostaCarteiraDeEstudante != "n")
    {
        Console.WriteLine("Opção inválida. Tente novamente.");
        throw new ArgumentException("Opção inválida. Tente novamente.");
    }

    return respostaCarteiraDeEstudante.Equals('s');
}