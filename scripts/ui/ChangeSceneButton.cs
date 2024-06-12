using Godot;
using System;

public partial class ChangeSceneButton : Button
{
    [Export(PropertyHint.File, "*.tscn")] public string GameScene = string.Empty;
    
    public override void _Pressed()
    {
        if (GameScene == string.Empty)
            return;
        GetTree().ChangeSceneToFile(GameScene);
    }
}
