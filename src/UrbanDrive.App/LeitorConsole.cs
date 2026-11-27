using System.Globalization;

namespace UrbanDrive.App;

// Entrada digitada que nao pode ser convertida (texto no lugar de numero, data em formato errado...).
public class EntradaInvalidaException : Exception
{
    public EntradaInvalidaException(string mensagem) : base(mensagem)
    {
    }
}

// A entrada acabou (Ctrl+Z / fim do arquivo redirecionado): o menu encerra.
public class FimDaEntradaException : Exception
{
    public FimDaEntradaException() : base("Fim da entrada.")
    {
    }
}

// Le e converte o que o usuario digita. Nao tem regra de negocio: as regras (placa obrigatoria,
// diaria positiva, CNH valida...) ficam nas classes de UrbanDrive.Models.
public class LeitorConsole
{
    private readonly TextReader entrada;
    private readonly TextWriter saida;

    public LeitorConsole(TextReader entrada, TextWriter saida)
    {
        this.entrada = entrada;
        this.saida = saida;
    }

    public string LerTexto(string rotulo)
    {
        saida.Write($"{rotulo}: ");
        string? linha = entrada.ReadLine();

        if (linha == null)
        {
            throw new FimDaEntradaException();
        }

        return linha.Trim();
    }

    public int LerInteiro(string rotulo)
    {
        string texto = LerTexto(rotulo);

        if (!int.TryParse(texto, NumberStyles.Integer, CultureInfo.InvariantCulture, out int valor))
        {
            throw new EntradaInvalidaException($"\"{texto}\" não é um número inteiro válido.");
        }

        return valor;
    }

    // Aceita virgula ou ponto como separador decimal (150,50 ou 150.50).
    public double LerDecimal(string rotulo)
    {
        string texto = LerTexto(rotulo);

        if (!double.TryParse(texto.Replace(',', '.'), NumberStyles.Float, CultureInfo.InvariantCulture, out double valor))
        {
            throw new EntradaInvalidaException($"\"{texto}\" não é um valor numérico válido.");
        }

        return valor;
    }

    public DateTime LerData(string rotulo)
    {
        string texto = LerTexto($"{rotulo} (dd/mm/aaaa)");

        if (!DateTime.TryParseExact(texto, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime data))
        {
            throw new EntradaInvalidaException($"\"{texto}\" não é uma data válida no formato dd/mm/aaaa.");
        }

        return data;
    }
}
