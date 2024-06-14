using Godot;
using System;

public partial class Quit : Node2D
{
	public override void _Process(double delta)
	{
		if (Input.IsActionPressed("Escape"))
		{
			GetTree().ChangeSceneToFile("res://scenes/views/MainMenu.tscn");
		}
	}
}
