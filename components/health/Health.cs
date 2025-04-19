using Godot;
using System;

[GlobalClass]
public partial class Health : Node
{
    [Signal]
    public delegate void ReachedZeroEventHandler();

    [Export]
    public int MaxHealth { get; private set; } = 5;

    [Export]
    public int CurrentHealth { get; private set; } = 5;

    public void Increase(int amount)
    {
        int increasedHealth = CurrentHealth + amount;

        if (increasedHealth > MaxHealth)
        {
            CurrentHealth = MaxHealth;

            return;
        }

        CurrentHealth = increasedHealth;
    }

    public void Decrease(int amount)
    {
        int decreasedHealth = CurrentHealth - amount;

        if (decreasedHealth < 0)
        {
            CurrentHealth = 0;
            EmitSignal(SignalName.ReachedZero);

            return;
        }

        CurrentHealth = decreasedHealth;
    }
}
