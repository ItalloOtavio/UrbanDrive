using System.Text;
using UrbanDrive.App;

// Program.cs so prepara o console e abre o menu. As telas ficam em MenuConsole
// e as regras de negocio nas classes de UrbanDrive.Models.
Console.OutputEncoding = Encoding.UTF8;
Console.InputEncoding = Encoding.UTF8;

MenuConsole menu = new MenuConsole(Console.In, Console.Out);
menu.Executar();
