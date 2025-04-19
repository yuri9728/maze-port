using Godot;

public partial class Noobic : CharacterBody2D
{
    public const int MoveSpeed = 100;

    private AnimatedSprite2D sprite;

    private Vector2 currentInputDirection = Vector2.Zero;

    public override void _Ready()
    {
        sprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
    }

    public override void _Process(double delta)
    {
        currentInputDirection = Input.GetVector("left", "right", "up", "down");

        if (currentInputDirection == Vector2.Zero)
        {
            sprite.Stop();
            return;
        }

        sprite.Play($"run_{GetPrimaryDirection(currentInputDirection)}");
    }

    public override void _PhysicsProcess(double delta)
    {
        Velocity = currentInputDirection * MoveSpeed;

        MoveAndSlide();
    }

    private static string GetPrimaryDirection(Vector2 direction)
    {
        if (Mathf.Abs(direction.X) > Mathf.Abs(direction.Y))
        {
            return direction.X > 0 ? "right" : "left";
        }
        else
        {
            return direction.Y > 0 ? "down" : "up";
        }
    }
}
