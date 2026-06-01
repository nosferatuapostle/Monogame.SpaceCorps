using Microsoft.Xna.Framework;
using MonoGame.Extended.Input;

public class Unit : Entity
{
    public bool isPlayer;

    private UnitMovement movement;

    public Unit(UnitValues uv)
    {
        AddComponent(uv);
        movement = new UnitMovement();
        AddComponent(movement);
    }

    public override void Update()
    {
        if (isPlayer)
        {
            if (G.Input.Mouse.WasButtonPressed(MouseButton.Right))
            {
                new StartMovintData(this, Transform.Position);
                movement.Target = G.MouseWorldPosition;
            }
        }

        base.Update();
    }
}