using Microsoft.Xna.Framework;
using MonoGame.Extended;
using MonoGame.Extended.Input;

public record class FireRedPixelData(Transform2 Transform, Vector2 Direction) : IEvent;

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
            if (G.Input.Mouse.WasButtonPressed(MouseButton.Left))
            {
                var dir = G.MouseWorldPosition - Transform.Position;
                if (dir != Vector2.Zero)
                {
                    var t = new Transform2();
                    t.Position = Transform.Position;
                    t.Scale *= 4;

                    G.EventBus.Trigger(new FireRedPixelData(t, dir));
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