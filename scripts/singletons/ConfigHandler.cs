using Godot;
using Godot.Collections;

public partial class ConfigHandler : Node
{
    private ConfigFile _config = new ConfigFile();
    private const string ConfigPath = "res://settings.ini";

    public override void _Ready()
    {
        if (!FileAccess.FileExists(ConfigPath))
        {
            _config.SetValue("video", "fullscreen", false);
            _config.SetValue("video", "height", 640);
            _config.SetValue("video", "width", 360);
            _config.Save(ConfigPath);
        }

        else
            _config.Load(ConfigPath);
    }

    public Dictionary GetSectionSettings(string section)
    {
        _config.Load(ConfigPath);
        var settings = new Dictionary();

        foreach (var key in _config.GetSectionKeys(section))
        {
            settings[key] = _config.GetValue(section, key);
        }

        return settings;

    }

    public void ChangeSetting(string section, string key, Variant value)
    {
        _config.SetValue(section, key, value);
        _config.Save(ConfigPath);
    }
}
