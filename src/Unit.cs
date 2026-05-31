using Microsoft.Xna.Framework;
using MonoGame.Extended.Input;

public class Unit : GameObject
{
    public UnitValues values;
    public bool isPlayer;

    private Vector2 target;

    public Unit(UnitValues uv)
    {
        bool isPlayer = false;
        values = uv;
        target = Vector2.Zero;
    }

    public void Update(GameTime gt)
    {
        if (isPlayer)
        {
            if (Input.Mouse.WasButtonPressed(MouseButton.Right))
            {
                target = G.MouseWorldPosition;
            }
        }

        if (target != Vector2.Zero)
        {
            var dir = target - Transform.Position;
            if (dir.Length() < 10f)
            {
                target = Vector2.Zero;
            }
                
            dir.Normalize();
            Transform.Position += dir * 100f * Time.Delta;
        }
    }
}