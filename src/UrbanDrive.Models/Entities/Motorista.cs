namespace UrbanDrive.Models.Entities;

public class Motorista : IImprimivel
{
    public string Nome { get; private set; }
    public string CPF { get; private set; }
    public CNH Habilitacao { get; private set; }

    public string GerarRelatorio()
    {
        return $"Motorista: {Nome} | Categoria da CNH: {Habilitacao.Categoria}";
    }
    public Motorista(string nome, string cpf, string numeroCNH, string categoria, DateTime validadeCNH)
    {
        if (string.IsNullOrWhiteSpace(nome))
        {
            throw new ArgumentException("Nome do motorista invalido!", nameof(nome));
        }

        if (string.IsNullOrWhiteSpace(cpf))
        {
            throw new ArgumentException("CPF do motorista invalido!", nameof(cpf));
        }

        Nome = nome;
        CPF = cpf;

        Habilitacao = new CNH(numeroCNH, categoria, validadeCNH);
    }
}
