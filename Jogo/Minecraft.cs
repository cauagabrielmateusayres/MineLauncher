using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using CmlLib.Core;
using CmlLib.Core.Auth;
using CmlLib.Core.ProcessBuilder;
using Microsoft.VisualBasic;
using Spectre.Console;

internal class Minecraft
{
    private readonly MinecraftLauncher launcher = new();
    public async Task OpenMinecraft(string version, string playerName)
    {
        
        Process? game;
        var options = new MLaunchOption()
        {
            Session = MSession.CreateLegacyOfflineSession(playerName),
            MaximumRamMb = 4096
    
        };

        game = await launcher.InstallAndBuildProcessAsync(version, options);    
        AnsiConsole.Status()
            .Start($"Iniciando Jogo... {version}", ctx =>
            {
                Thread.Sleep(000);
                game.Start();
            });
        
    }
    public async Task DisplayVersions(SelectionPrompt<string> selection)
    {
        
        var versions = await launcher.GetAllVersionsAsync();
       

      

        foreach (var v in versions)
        {
            if (v.Type == "release")
            {
                selection.AddChoice(v.Name);
            }

        }
        

    }
}