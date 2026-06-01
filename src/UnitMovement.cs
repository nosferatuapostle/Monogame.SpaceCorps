using Microsoft.Xna.Framework;
using MonoGame.Extended;

public delegate void UnitStartMoving(StartMovintData data);

public record class StartMovintData(Unit unit, Vector2 startPosition);

public class UnitMovement
{
    public Vector2 Target;

    public bool InMove => Target != Vector2.Zero;

    public UnitMovement()
    {
        Target = Vector2.Zero;
    }

    public void Update(Unit unit)
    {
        if (!InMove)
        {
            return;
        }

        var t = unit.Transform;
        var uv = unit.Values;

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