using Microsoft.Xna.Framework;
using MonoGame.Extended;

public record class StartMovementData(Entity Entity, Vector2 Start, Vector2 Target) : IEvent;

public class UnitMovement : Component
{
    private Vector2 target;
    public Vector2 Target
    {
        get => target;
        set
        {
            G.EventBus.Trigger(new StartMovementData(Entity, Entity.Transform.Position, value));
            target = value;
        }
    }

    public bool InMove => target != Vector2.Zero;

    private UnitValues uv;

    public UnitMovement()
    {
        target = Vector2.Zero;
    }

    private EventResult OnStartMovement(StartMovementData data)
    {
        System.Diagnostics.Debug.Print($"start position: {data.Start}, target position: {data.Target}");
        return EventResult.Continue;
    }

    public override void OnAdded()
    {
        G.EventBus.Subscribe<StartMovementData>(OnStartMovement);
        uv = Entity.GetComponent<UnitValues>();
    }

    public override void OnUpdate()
    {
        if (!InMove)
        {
            return;
        }

        var t = Entity.Transform;

        var dir = Target - t.Position;
        if (dir.Length() < 10f)
        {
            Target = Vector2.Zero;
        }

        dir.Normalize();
        t.Position += dir * uv.Speed * G.Time.Delta;
        t.Rotation = dir.ToAngle();
    }
}