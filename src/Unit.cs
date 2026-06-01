using Microsoft.Xna.Framework;
using MonoGame.Extended.Input;

public class Unit : GameObject
{
    public UnitValues Values;
    public bool isPlayer;

    private UnitMovement movement;

    public Unit(UnitValues uv)
    {
        Values = uv;
        movement = new UnitMovement();
    }

    public void Update(GameTime gt)
    {
        if (isPlayer)
        {
            if (G.Input.Mouse.WasButtonPressed(MouseButton.Right))
            {
                new StartMovintData(this, Transform.Position);
                movement.Target = G.MouseWorldPosition;
            }
        }

        movement.Update(this);
    }
}