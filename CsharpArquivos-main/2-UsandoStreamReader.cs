using ByteBankIO;

partial class Program
{
    static void Inicial()
    {
        string enderecoDoArquivo = "contas.txt";

        using FileStream fluxoDoArquivo = new(enderecoDoArquivo, FileMode.Open);
        StreamReader leitor = new(fluxoDoArquivo); // StreamReader é uma classe que lê o fluxo do arquivo e converte em string
        //string linha = leitor.ReadLine(); // lê a primeira linha do arquivo
        //string texto = leitor.ReadToEnd(); // lê todo o arquivo e converte em string
        //int numero = leitor.Read(); // lê o primeiro byte do arquivo e converte em int

        while (!leitor.EndOfStream) // enquanto não chegar no final do arquivo
        {
            string linha = leitor.ReadLine(); // lê uma linha do arquivo
            ContaCorrente contaCorrente = ConverterStringParaContaCorrente(linha);


            var msg = $"{contaCorrente.Titular.Nome}: número {contaCorrente.Numero}, ag {contaCorrente.Agencia}, Saldo {contaCorrente.Saldo}";

            Console.WriteLine(msg); // escreve a linha no console teste
        }

        Console.ReadLine();
    }

    static ContaCorrente ConverterStringParaContaCorrente(string linha)
    {
        string[] campos = linha.Split(','); // separa a linha em campos usando a vírgula como separador

        string agencia = campos[0]; // pega o primeiro campo da linha
        string numero = campos[1]; // pega o segundo campo da linha
        string saldo = campos[2].Replace(".", ","); // pega o terceiro campo da linha
        string nomeTitular = campos[3]; // pega o quarto campo da linha

        int agenciaComoInt = Convert.ToInt32(agencia); // converte a agência para int
        int numeroComoInt = Convert.ToInt32(numero); // converte o número da conta para int
        double saldoComoDouble = Convert.ToDouble(saldo, System.Globalization.CultureInfo.GetCultureInfo("pt-BR")); // converte o saldo para double

        Cliente titular = new()
        {
            Nome = nomeTitular
        };

        ContaCorrente resultado = new(agenciaComoInt, numeroComoInt)
        {
            Titular = titular
        };

        resultado.Depositar(saldoComoDouble); // deposita o saldo na conta

        return resultado;
    }
}
