using System.Text;

partial class Program
{
	public static void CriarArquivo()
	{
		string caminhoNovoArquivo = "contasExportadas.csv";

		using FileStream fluxoDoArquivo = new(caminhoNovoArquivo, FileMode.Create);

        string contaComoString = "456, 7895, 4785.40, Gustavo Santos";

        Encoding encoding = Encoding.UTF8;
        byte[] bytes = encoding.GetBytes(contaComoString);

        fluxoDoArquivo.Write(bytes, 0, bytes.Length);
    }

    public static void CriarArquivoComWriter()
    {
        string caminhoNovoArquivo = "contasExportadas.csv";

        using FileStream fluxoDeArquivo = new(caminhoNovoArquivo, FileMode.Create);
        using StreamWriter escritor = new(fluxoDeArquivo);

        escritor.Write("456,65465,456.0,Pedro");
    }

    static void TestaEscrita()
    {
        string caminhoNovoArquivo = "teste.txt";

        using FileStream fluxoDeArquivo = new(caminhoNovoArquivo, FileMode.CreateNew);
        using StreamWriter escritor = new(fluxoDeArquivo);

        for (int i = 0; i < 1000000; i++) // 
        {
            escritor.WriteLine($"Linha {i}");
            escritor.Flush(); // Força a escrita do buffer para o arquivo, garantindo que os dados sejam salvos imediatamente
            Console.WriteLine($"Linha {i} foi escrita no arquivo. Tecle enter...");
            Console.ReadLine(); 
        }
    }
}
