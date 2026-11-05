using System.Text;

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

        fluxoDoArquivo.Close(); // fecha o fluxo do arquivo

        Console.ReadLine();
    }

    static void EscreverBuffer(byte[] buffer)
    {
        UTF8Encoding utf8 = new(); //Não quebra pq os bytes lidos são convertidos em string usando UTF8Encoding, que tem mais de 256 combinações pelo mecanismo de associação de bytes
        string textoUtf8 = utf8.GetString(buffer); // converte o buffer em string
        Console.WriteLine(textoUtf8);


        ASCIIEncoding aSCIIEncoding = new(); //Quebra pq o ASCIIEncoding só tem 256 combinações, então quando ele encontra um byte que não tem representação no ASCII ele quebra
        string textoASCII = aSCIIEncoding.GetString(buffer); // converte o buffer em string
        Console.WriteLine(textoASCII);


        //foreach (byte meuByte in buffer)
        //{
        //    Console.Write(meuByte); // escreve o valor do byte
        //    Console.Write(" ");
        //}
    }
}
