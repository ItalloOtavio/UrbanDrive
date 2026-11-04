namespace UrbanDrive.Models.Entities;

public class Motorista
{
    public string Nome { get; private set; }
    public string CPF { get; private set; }
    public CNH Habilitacao { get; private set; }

    public Motorista(string nome, string cpf, string numeroCNH, string categoria, DateTime validadeCNH)
    {
        Nome = nome;
        CPF = cpf;

        Habilitacao = new CNH(numeroCNH, categoria, validadeCNH);
    }
}