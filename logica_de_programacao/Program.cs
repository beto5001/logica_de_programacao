decimal precoHamburguer = 12;
decimal precoBatataFrita = 7;
decimal refrigerante = 5;

Dictionary<string, decimal> cardapio = new Dictionary<string, decimal>()
{
    {"1", precoHamburguer},
    {"2", precoBatataFrita},
    {"3", refrigerante}
};

decimal total = 0M;
bool pedindo = true;

do
{
    ExibirMenu();

    cardapio.TryGetValue(Console.ReadKey().KeyChar.ToString(), out decimal valorItem);
    bool flowControl = ValidarOpcaoDigitada(valorItem);
    if (!flowControl) continue;

    AtribuirQuantidade();
    total += valorItem;

    pedindo = ValidarContinuidadeDoPedido();
    Fim();

} while (pedindo);


foreach (var item in cardapio)
{
    Console.WriteLine($"Item: {item.Key}, Preço: R$ {item.Value}");
}

Console.WriteLine($"O valor total da conta é: R$ {total}");
Console.WriteLine("Obrigado pela preferência! Volte sempre!");

static void AtribuirQuantidade()
{
    int quantidade = 0;

    do
    {
        Console.WriteLine();
        Console.WriteLine("Digite a quantidade desejada: ");
        string input = Console.ReadLine();
        if (!int.TryParse(input, out quantidade) || quantidade <= 0)
        {
            Console.WriteLine("Quantidade inválida. Tente novamente.");
            continue;
        }
        break;
    } while (true);
}

static bool ValidarOpcaoDigitada(decimal valorItem)
{
    if (valorItem == 0)
    {
        Console.WriteLine();
        Console.WriteLine("Opção inválida. Tente novamente.");
        return false;
    }

    return true;
}

static void ExibirMenu()
{
    Console.WriteLine("Escolha o item utilizando o teclado numérico: ");
    Console.WriteLine("1: Hambúrguer: R$ 12,00");
    Console.WriteLine("2: Batata frita: R$ 7,00");
    Console.WriteLine("3: Refrigerante: R$ 5,00");
}

static bool ValidarContinuidadeDoPedido()
{
    bool pedindo;
    Console.WriteLine();
    Console.WriteLine("Digite 's' para continuar ou 'n' para finalizar o pedido: ");
    string decisao = Console.ReadKey().KeyChar.ToString().ToLower();

    pedindo = decisao == "s";
    return pedindo;
}

static void Fim()
{
    Console.WriteLine();
}