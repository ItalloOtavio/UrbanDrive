namespace UrbanDrive.Models.Entities;

public class Locacao
{
    public Motorista Motorista { get; private set; }
    public Veiculo Veiculo { get; private set; }
    public int Dias { get; private set; }

    public Locacao(Motorista motorista, Veiculo veiculo, int dias)
    {
        if (motorista == null)
        {
            throw new ArgumentNullException(nameof(motorista), "Motorista obrigatorio!");
        }

        if (veiculo == null)
        {
            throw new ArgumentNullException(nameof(veiculo), "Veiculo obrigatorio!");
        }

        if (dias <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(dias), "Quantidade de dias invalida! Deve ser maior que zero.");
        }

        if (!motorista.Habilitacao.EstaValida())
        {
            throw new InvalidOperationException("CNH vencida! O motorista nao pode alugar um veiculo.");
        }

        Motorista = motorista;
        Veiculo = veiculo;
        Dias = dias;
    }
}
