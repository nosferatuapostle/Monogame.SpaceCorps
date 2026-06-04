using Microsoft.Xna.Framework;
using MonoGame.Extended;

public record class StartMovementData(Entity Entity, Vector2 Start, Vector2 Target);
public record class FireRedPixelData(Transform2 Transform, Vector2 Direction);
public record class CollisionData(Entity Entity1, Entity Entity2);

public record class UnitHoverEvent(Entity Unit, bool IsHovered);