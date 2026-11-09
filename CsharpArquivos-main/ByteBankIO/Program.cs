partial class Program
{
    static void Main(string[] args)
    {
        string enderecoDoArquivo = "contas.txt";

        using FileStream fluxoDoArquivo = new(enderecoDoArquivo, FileMode.Open);
        StreamReader leitor = new(fluxoDoArquivo); // StreamReader é uma classe que lê o fluxo do arquivo e converte em string
        //string linha = leitor.ReadLine(); // lê a primeira linha do arquivo
        //string texto = leitor.ReadToEnd(); // lê todo o arquivo e converte em string
        //int numero = leitor.Read(); // lê o primeiro byte do arquivo e converte em int

        while(!leitor.EndOfStream) // enquanto não chegar no final do arquivo
        {
            string linha = leitor.ReadLine(); // lê uma linha do arquivo
            Console.WriteLine(linha); // escreve a linha no console
        }

        Console.ReadLine();
    }
}
