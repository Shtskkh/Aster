using Godot;
using System;

public partial class MainCharacter : CharacterBody2D
{
	[Export]
	private int speed = 100;

	private Vector2 currentVelocity;
	private Vector2 lastDirection;

	private AnimationPlayer animationPlayer;

	public override void _Ready()
	{
		base._Ready();
		animationPlayer = GetNode<AnimationPlayer>("AnimationPlayer");
	}

	public override void _PhysicsProcess(double delta)
	{
		base._PhysicsProcess(delta);
		handleInput();
		Velocity = currentVelocity;
		
		MoveAndSlide();
		UpdateAnimation();
	}

	private void handleInput()
	{
		currentVelocity = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");
		currentVelocity *= speed;

		if (currentVelocity.Length() > 0)
		{
			lastDirection = currentVelocity.Normalized();
		}
	}

	private void UpdateAnimation()
	{
		if (currentVelocity.Length() > 0)
		{
			if (currentVelocity.X > 0)
			{
				animationPlayer.Play("WalkRight");
			}
			else if (currentVelocity.X < 0)
			{
				animationPlayer.Play("WalkLeft");
			}
			else if (currentVelocity.Y < 0)
			{
				animationPlayer.Play("WalkUp");
			}
			else
			{
				animationPlayer.Play("WalkDown");
			}
		}
		else
		{
			if (lastDirection.X > 0)
			{
				animationPlayer.Play("StandRight");
			}
			else if (lastDirection.X < 0)
			{
				animationPlayer.Play("StandLeft");
			}
			else if (lastDirection.Y < 0)
			{
				animationPlayer.Play("StandUp");
			}
			else
			{
				animationPlayer.Play("StandDown");
			}
		}
	}
}
