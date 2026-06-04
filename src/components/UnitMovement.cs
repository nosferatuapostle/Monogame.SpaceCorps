using Microsoft.Xna.Framework;
using MonoGame.Extended;

public class UnitMovement : Component
{
    private Vector2 target;
    public Vector2 Target
    {
        get => target;
        set
        {
            G.Events.Get<StartMovementData>().Trigger(new StartMovementData(Entity, Entity.Transform.Position, value));
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
        if (data.Entity == Entity)
        {
            System.Diagnostics.Debug.Print($"start position: {data.Start}, target position: {data.Target}");            
        }
        return EventResult.Break;
    }

    public override void OnAdded()
    {
        G.Events.Get<StartMovementData>().Subscribe(OnStartMovement);
        uv = Entity.GetComponent<UnitValues>();
    }

    public override void OnRemoved()
    {
        G.Events.Get<StartMovementData>().Unsubscribe(OnStartMovement);
    }

    public override void OnUpdate()
    {
        if (!InMove)
        {
            return;
        }

        var t = Entity.Transform;

        var dir = target - t.Position;
        if (dir.Length() < 10f)
        {
            target = Vector2.Zero;
        }

        dir.Normalize();
        t.Position += dir * uv.Speed * G.Time.Delta;
        t.Rotation = dir.ToAngle();
    }
}