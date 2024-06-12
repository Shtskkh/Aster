using Godot;
using System;

public partial class SettingsHandler : Node
{
    private ConfigHandler _config = new ConfigHandler();
    public override void _Ready()
    {
        var window = GetWindow();
        var videoSettings = _config.GetSectionSettings("video");
        var fullScreen = videoSettings["fullscreen"].AsBool();

        window.Mode = fullScreen ? Window.ModeEnum.ExclusiveFullscreen : Window.ModeEnum.Windowed;
    }
}
