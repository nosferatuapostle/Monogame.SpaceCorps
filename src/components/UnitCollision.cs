using System;
using Microsoft.Xna.Framework;


public class UnitCollision : Component
{
    private UnitData data;

    public UnitCollision(UnitData d)
    {
        data = d;
    }

    public override void OnAdded()
    {
        G.Events.Get<CollisionData>().Subscribe(OnCollision);
    }

    public override void OnRemoved()
    {
        G.Events.Get<CollisionData>().Unsubscribe(OnCollision);
    }

    private EventResult OnCollision(CollisionData data)
    {
        var entityData = data.Entity1.GetComponent<UnitData>();
        var otherData = data.Entity2.GetComponent<UnitData>();

        Vector2 posA = Entity.Transform.Position;
        Vector2 posB = data.Entity2.Transform.Position;

        float rA = entityData.Radius;
        float rB = otherData.Radius;

        Vector2 delta = posA - posB;

        float distSq = delta.LengthSquared();
        float minDist = rA + rB;

        if (distSq == 0)
        {
            delta = new Vector2(1, 0);
            distSq = 0.0001f;
        }

        if (distSq < minDist * minDist)
        {
            float dist = MathF.Sqrt(distSq);

            Vector2 normal = delta / dist;

            float penetration = minDist - dist;

            Vector2 correction = normal * (penetration * 0.5f);

            Entity.Transform.Position += correction;
            data.Entity2.Transform.Position -= correction;
        }
        // System.Diagnostics.Debug.Print("interacts");
        return EventResult.Continue;
    }

    public bool Interacts(Entity other)
    {
        var otherData = other.GetComponent<UnitData>();
        float radius = data.Radius + otherData.Radius;
        return Vector2.DistanceSquared(other.Transform.Position, Entity.Transform.Position) <= radius * radius;
    }

    public override void OnUpdate()
    {
        foreach (var e in G.Entt.List)
        {
            if (e == Entity)
            {
                continue;
            }
            if (e.HasComponent<UnitCollision>())
            {
                if (Interacts(e))
                {
                    G.Events.Get<CollisionData>().Trigger(new CollisionData(Entity, e));
                }
            }
        }
        base.OnUpdate();
    }
}