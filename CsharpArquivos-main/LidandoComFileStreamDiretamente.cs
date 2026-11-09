using System;

partial class Program
{
	public Program() { }

    static void EscreverBuffer(byte[] buffer, int bytesLidos)
    {
        UTF8Encoding utf8 = new(); //Não quebra pq os bytes lidos são convertidos em string usando UTF8Encoding, que tem mais de 256 combinações pelo mecanismo de associação de bytes
        string textoUtf8 = utf8.GetString(buffer, 0, bytesLidos); // converte o buffer em string 
        Console.WriteLine(textoUtf8);


        //ASCIIEncoding aSCIIEncoding = new(); //Quebra pq o ASCIIEncoding só tem 256 combinações, então quando ele encontra um byte que não tem representação no ASCII ele quebra
        //string textoASCII = aSCIIEncoding.GetString(buffer, 0, bytesLidos); // converte o buffer em string
        //Console.WriteLine(textoASCII);


        //foreach (byte meuByte in buffer)
        //{
        //    Console.Write(meuByte); // escreve o valor do byte
        //    Console.Write(" ");
        //}
    }

    string enderecoDoArquivo = "contas.txt";
    using FileStream fluxoDoArquivo = new(enderecoDoArquivo, FileMode.Open);
    //using: garante que o fluxo do arquivo seja fechado automaticamente ao final do bloco, mesmo que ocorra uma exceção. Isso é útil para liberar recursos do sistema e evitar vazamentos de memória.

    byte[] buffer = new byte[1024]; //1 KB, somente um pedaço do arquivo
    int numeroDeBytesLidos = -1;


    while (numeroDeBytesLidos != 0) // enquanto não chegar no final do arquivo
    {
        numeroDeBytesLidos = fluxoDoArquivo.Read(buffer, 0, buffer.Length); // lê o arquivo e coloca no buffer

        Console.WriteLine($"Bytes lidos: {numeroDeBytesLidos}"); // escreve o número de bytes lidos
        EscreverBuffer(buffer, numeroDeBytesLidos);
    }


    fluxoDoArquivo.Close(); // fecha o fluxo do arquivo
}
