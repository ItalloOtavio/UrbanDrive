using UrbanDrive.Models;
using UrbanDrive.Models.Entities;

namespace UrbanDrive.Tests;

public class CarroEletricoTests
{
    [Fact]
    public void Construtor_DeveDefinirNivelBateria()
    {
        var carro = new CarroEletrico(1, "ABC1234", "Modelo E", 150, 4, 35);

        Assert.Equal(35, carro.NivelBateria);
    }

    [Fact]
    public void Recarregar_DeveColocarBateriaEm100()
    {
        var carro = new CarroEletrico(1, "ABC1234", "Modelo E", 150, 4, 35);

        carro.Recarregar();

        Assert.Equal(100, carro.NivelBateria);
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(101)]
    public void NivelBateria_ForaDoIntervalo_DeveLancarExcecao(int nivel)
    {
        Assert.Throws<ArgumentOutOfRangeException>(
            () => new CarroEletrico(1, "ABC1234", "Modelo E", 150, 4, nivel));
    }

    [Fact]
    public void CarroEletrico_DeveSerCarroEIEletrico()
    {
        var carro = new CarroEletrico(1, "ABC1234", "Modelo E", 150, 4, 50);

        Assert.IsAssignableFrom<Carro>(carro);
        Assert.IsAssignableFrom<IEletrico>(carro);
    }
}