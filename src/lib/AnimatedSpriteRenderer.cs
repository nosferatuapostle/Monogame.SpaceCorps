using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
using MonoGame.Extended.Graphics;

public class AnimatedSpriteRenderer : IRenderer
{
    private AnimatedSprite sprite;
    private Transform2 transform;

    public AnimatedSpriteRenderer(AnimatedSprite s, Transform2 t) 
    {
        sprite = s;
        sprite.Origin = new Vector2(sprite.TextureRegion.Width, sprite.TextureRegion.Height) * 0.5f;

        transform = t;

        // t.Scale *= 4f;
    }

    public void Update(GameTime gt)
    {
        sprite.Update(gt);
    }

    public void Draw(SpriteBatch sb)
    {
        sb.Draw(sprite, transform);
    } 
}