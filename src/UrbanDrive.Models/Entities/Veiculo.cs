using UrbanDrive.Models;
namespace UrbanDrive.Models.Entities;

public abstract class Veiculo : IImprimivel
{
    private int id;
    private string placa = "";
    private string modelo = "";
    private double valorBaseDiaria;
    private List<string> historicoManutencoes = new List<string>();

    public int Id
    {
        get { return id; }
        set
        {
            if (value <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(Id), "Id invalido! Deve ser maior que zero.");
            }

            id = value;
        }
    }

    public string Placa
    {
        get { return placa; }
        set
        {
            if (value == null || value.Trim() == "")
            {
                throw new ArgumentException("Placa invalida!");
            }

            placa = value;
        }
    }

    public string Modelo
    {
        get { return modelo; }
        set
        {
            if (value == null || value.Trim() == "")
            {
                throw new ArgumentException("Modelo invalido!");
            }

            modelo = value;
        }
    }

    public double ValorBaseDiaria
    {
        get { return valorBaseDiaria; }
        set
        {
            if (value <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(ValorBaseDiaria), "Valor da diaria invalido! Deve ser maior que zero.");
            }

            valorBaseDiaria = value;
        }
    }

    public IReadOnlyList<string> HistoricoManutencoes
    {
        get { return historicoManutencoes.AsReadOnly(); }
    }

    protected Veiculo(int id, string placa, string modelo, double valorBaseDiaria)
    {
        Id = id;
        Placa = placa;
        Modelo = modelo;
        ValorBaseDiaria = valorBaseDiaria;

        ConfiguradorSistema.RegistrarVeiculoCriado();
    }

        public string GerarRelatorio()
    {
        return $"Modelo: {Modelo} | Placa: {Placa} | Diária: R$ {ValorBaseDiaria:F2}";
    }
    public virtual double CalcularAluguel(int dias)
    {
        if (dias <= 0)
        {
            throw new ArgumentOutOfRangeException(
                nameof(dias), "A quantidade de dias deve ser maior que zero.");
        }

        return ValorBaseDiaria * dias;
    }

    public string RealizarManutencao()
    {
        string registro = $"Manutencao geral realizada no veiculo {Modelo} ({Placa}).";
        historicoManutencoes.Add(registro);
        return registro;
    }

    public string RealizarManutencao(string pecaSubstituida)
    {
        if (string.IsNullOrWhiteSpace(pecaSubstituida))
        {
            throw new ArgumentException("Nome da peca substituida invalido!", nameof(pecaSubstituida));
        }

        string registro = $"Manutencao realizada no veiculo {Modelo} ({Placa}) com substituicao da peca: {pecaSubstituida}.";
        historicoManutencoes.Add(registro);
        return registro;
    }
}