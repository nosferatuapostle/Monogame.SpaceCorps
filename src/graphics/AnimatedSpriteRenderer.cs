using Microsoft.Xna.Framework;
using MonoGame.Extended;
using MonoGame.Extended.Graphics;

public class AnimatedSpriteRenderer : WorldRenderer<AnimatedSprite>
{
    public AnimatedSpriteRenderer(AnimatedSprite s, Transform2 t) : base(s, t) {}

    public override void Update(GameTime gt)
    {
        sprite.Update(gt);
    }
}