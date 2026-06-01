using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
using MonoGame.Extended.Graphics;

public class AnimatedSpriteRenderer : WorldRenderer<AnimatedSprite>
{
    public AnimatedSpriteRenderer(AnimatedSprite s, Transform2 t) : base(s, t)
    {
        sprite = s;
        transform = t;

        // t.Scale *= 4f;
    }

    public override void Update(GameTime gt)
    {
        sprite.Update(gt);
    }
}