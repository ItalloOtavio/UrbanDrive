
namespace UrbanDrive.Models.Entities;

public class CNH
{
    public string Numero { get; private set; }
    public string Categoria { get; private set; }
    public DateTime DataValidade { get; private set; }

    public CNH(string numero, string categoria, DateTime dataValidade)
    {
        Numero = numero;
        Categoria = categoria;
        DataValidade = dataValidade;
    }

    public bool EstaValida()
    {
        return DataValidade >= DateTime.Today;
    }
}
