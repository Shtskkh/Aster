using Godot;
public partial class Enemy : CharacterBody2D
{
	private int _speed = 150;
	private bool _playerChase;
	private AnimatedSprite2D _animation;
	private Node2D _player;
	
	public override void _Ready()
	{
		_animation = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
	}

	public override void _Process(double delta)
	{
		if (_playerChase)
		{
			Position += (_player.Position - Position) / _speed;
			_animation.Play("walk");
		}
		else
			_animation.Play("idle");
	}

	private void _on_area_2d_body_entered(Node2D body)
	{
		_player = body;
		_playerChase = true;
	}

	private void _on_area_2d_body_exited(Node2D body)
	{
		_player = null;
		_playerChase = false;
	}
	
}
