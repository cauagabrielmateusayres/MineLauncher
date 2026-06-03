using System.Runtime.CompilerServices;
using CmlLib.Core;
using CmlLib.Core.Auth;
using CmlLib.Core.ProcessBuilder;
using ICSharpCode.SharpZipLib;
using Microsoft.VisualBasic;
using Spectre.Console;

class Program
{
    public static async Task Main()
    {
        var minecraft = new Minecraft();

        AnsiConsole.MarkupLine("Bem Vindo ao [#5FFF00]MinecraftLauncher![/]!\n");

        var selection = new SelectionPrompt<String>().Title("Selecione uma versão");
        await minecraft.DisplayVersions(selection);

        var version = AnsiConsole.Prompt(selection);

        AnsiConsole.WriteLine($"Versão escolhida: {version}");

        var playerName = AnsiConsole.Ask<string>("Digite seu nickName:");
        

        await minecraft.OpenMinecraft(version,playerName);
    }
}
