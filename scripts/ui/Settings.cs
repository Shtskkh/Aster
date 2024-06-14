using Godot;
using Godot.Collections;

public partial class Settings : Control
{
    private ConfigHandler _config = new ConfigHandler();
    private Dictionary _videoSettings;
    private CheckBox _fullscreen;
    private OptionButton _resButton;
    private Window _window;

    private Dictionary<string, Vector2I> _resolutions = new Dictionary<string, Vector2I>
    {
        {"640x360", new Vector2I(640, 360)},
        {"1280x720", new Vector2I(1280, 720)},
        {"1920x1080", new Vector2I(1920, 1080)},
        {"2560x1440", new Vector2I(2560, 1440)},
        {"3840x2160", new Vector2I(3840,2160)}
    };
    public override void _Ready()
    {
        _window = GetWindow();
        _videoSettings = _config.GetSectionSettings("video");
        _fullscreen = GetNode<CheckBox>("VBoxContainer/FullScreen/FullScreenCheckBox");
        _resButton = GetNode<OptionButton>("VBoxContainer/Res/Resolutions");

        _AddResolutions();
        _fullscreen.ButtonPressed = _videoSettings["fullscreen"].AsBool();
    }

    private void _on_full_screen_check_box_toggled(bool toggledOn)
    {
        _config.ChangeSetting("video", "fullscreen", toggledOn);
        _window.Mode = toggledOn ? Window.ModeEnum.ExclusiveFullscreen : Window.ModeEnum.Windowed;
    }

    private void _AddResolutions()
    {
        var index = 0;
        var currentRes = GetWindow().ContentScaleSize;
        foreach (var key in _resolutions.Keys)
        {
            _resButton.AddItem(key, index);
            if (_resolutions[key] == currentRes)
                _resButton.Select(index);
            index++;
        }
    }

    private void _on_resolutions_item_selected(int index)
    {
        var resString = _resButton.GetItemText(index);
        var res = _resolutions[resString];
        _window.Size = res;
        _window.MoveToCenter();
    }
    
}
