using Godot;

public partial class Noobic : CharacterBody2D
{
    public const int MoveSpeed = 100;

    private AnimatedSprite2D sprite;

    private Vector2 currentInputDirection = Vector2.Zero;

    public override void _Ready()
    {
        sprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");

        sprite.Play("run_down");
    }

    public override void _Process(double delta)
    {
        
    }

    public override void _PhysicsProcess(double delta)
    {
        currentInputDirection = Input.GetVector("left", "right", "up", "down");

        Velocity = currentInputDirection * MoveSpeed;

        MoveAndSlide();
    }
}
