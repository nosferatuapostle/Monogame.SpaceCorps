using Microsoft.Xna.Framework;
using MonoGame.Extended;
using MonoGame.Extended.Input;

public class Unit : Entity
{
    public bool isPlayer;

    private UnitMovement movement;
    private UnitData data;

    public Unit(UnitValues uv)
    {
        movement = new UnitMovement();
        data = new UnitData{ Radius = 12f };

        AddComponent(uv);
        AddComponent(movement);
        AddComponent(data);
        AddComponent(new UnitCollision(data));
    }

    public override void Update()
    {
        if (isPlayer)
        {
            if (G.Input.Mouse.WasButtonPressed(MouseButton.Left))
            {
                var dir = G.MouseWorldPosition - Transform.Position;
                if (dir != Vector2.Zero)
                {
                    var t = new Transform2();
                    t.Position = Transform.Position;
                    t.Scale *= 3;

                    G.Events.Get<FireRedPixelData>().Trigger(new FireRedPixelData(t, dir));
                }
            }
            if (G.Input.Mouse.WasButtonPressed(MouseButton.Right))
            {
                movement.Target = G.MouseWorldPosition;
            }
        }

        base.Update();
    }
}

