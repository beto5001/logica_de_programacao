class Program
{
    static void Main(string[] args)
    {
        string enderecoDoArquivo = "contas.txt";
        FileStream fluxoDoArquivo = new(enderecoDoArquivo, FileMode.Open);
        
        byte[] buffer = new byte[1024]; //1 KB, somente um pedaço do arquivo
        int numeroDeBytesLidos = -1; 


        while (numeroDeBytesLidos != 0) // enquanto não chegar no final do arquivo
        {
            numeroDeBytesLidos = fluxoDoArquivo.Read(buffer, 0, buffer.Length); // lê o arquivo e coloca no buffer
        }

            
        EscreverBuffer(buffer);
        Console.ReadLine();
    }

    static void EscreverBuffer(byte[] buffer)
    {
        foreach (byte meuByte in buffer)
        {
            Console.Write(meuByte); // escreve o valor do byte
            Console.Write(" ");
        }
    }
}
